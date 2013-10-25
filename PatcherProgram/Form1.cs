using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //declare variables
        public string[] CRDSFileArray = {};
        public string[] WLMFileArray = {};
        public string[] Empty = {};
        public string[,] Empty2 = {};
        public string filePath;
        public decimal valueToAdd = 0M;
        public decimal ramanShift = 4155.25000M;
        public decimal pfreq = 0M;
        public int numberOfColumnsCRDS = 6;
        public int numberOfShots = 4;
        public int onCol;
        public int offCol;
        public List<string> linesToWrite = new List<string>();
        public bool cutZeros = false;

        private void numberOfColumns_ValueChanged(object sender, EventArgs e)
        {
            numberOfColumnsCRDS = (int) numberOfColumns.Value;
        }

        private void valueToAddUpDown_ValueChanged(object sender, EventArgs e)
        {
            valueToAdd = valueToAddUpDown.Value;
        }

        private void ramanShiftUpDown_ValueChanged(object sender, EventArgs e)
        {
            ramanShift = ramanShiftUpDown.Value;
        }

        private void numberOfShotsUpDown_ValueChanged(object sender, EventArgs e)
        {
            numberOfShots = (int)numberOfShotsUpDown.Value;
        }

        private void buttonCRDS_Click(object sender, EventArgs e)
        {
            CRDSFileArray = openFile(false);
        }//end button click

        private void button2_Click(object sender, EventArgs e)
        {
            WLMFileArray = openFile(true);
        }//end WLM open button

        /// <summary>
        /// Creates open file dialog and reads a .txt or .dat file into memory.
        /// </summary>
        /// <param name="WLM">
        /// Boolean value to indicate if this is to read in a WLM file or not. 
        /// </param>
        /// <returns>
        /// Returns a string[] of the tab and return delimited values in the text file.
        /// </returns>
        private string[] openFile(bool WLM)
        {
            var opener = new OpenFileDialog();
            if (String.IsNullOrEmpty(filePath))
            {
                opener.InitialDirectory = "X:\\tcodd\\HRCRDS Data\\NO3";
            }//end if
            else
            {
                opener.InitialDirectory = filePath;
            }
            if (WLM)
            {
                opener.Filter = "Text|*.txt|All Files|*.*";
                opener.Title = "Select a WLM File";
            }
            else
            {
                opener.Filter = "DAT|*.dat|All Files|*.*";
                opener.Title = "Select a CRDS File";
            }

            opener.ShowDialog();

            if (String.IsNullOrEmpty(opener.FileName))
            {
                return Empty;
            }

            filePath = opener.FileName;

            using (StreamReader openFile = new StreamReader(filePath))
            {
                //this copies the WLM file into a string array
                string[] file = new string[] {};
                string line;
                while ((line = openFile.ReadLine()) != null)//says read until no more lines
                {
                    file = file.Concat(line.Split(new char[] { '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
                }//end while
                return file;
            }//end StreamReader
        }

        private void patchButton_Click(object sender, EventArgs e)
        {
            if (WLMFileArray.Length == 0 || CRDSFileArray.Length == 0)
            {
                MessageBox.Show("Please make sure you have loaded both a CRDS and WLM file.", "Error!");
                return;
            }

            //this replaces the last timing point with a 500 so the last segment is read
            int endOfFileMarker = numberOfShots * 400;
            string endOfFileMarkerS = Convert.ToString(endOfFileMarker);
            WLMFileArray[WLMFileArray.Length - 2] = endOfFileMarkerS;

            decimal calFreqAdj;

            //this adds the Value to Add and subtracts the Raman Shift
            //this is for user input RamanShift values
            if (!CalcRamanShift.Checked)
            {
                for (int var = 1; var < WLMFileArray.Length; var += 5)
                {
                    calFreqAdj = Convert.ToDecimal(WLMFileArray[var]) + valueToAdd - ramanShift;
                    WLMFileArray[var] = Convert.ToString(calFreqAdj);
                }//end for loop for adding and subtracting values
            }
            //this is for User input T and P values to calculate the RamanShift
            else
            {
                decimal RS = RamanShift();
                for (int var = 1; var < WLMFileArray.Length; var += 5)
                {
                    calFreqAdj = Convert.ToDecimal(WLMFileArray[var]) + valueToAdd - RS;
                    WLMFileArray[var] = Convert.ToString(calFreqAdj);
                }//end for loop for adding and subtracting values
            }

            //creates a list of segments and then initializes them all
            var SegList = new List<Segment>();
            bool temp = true;
            int whichSeg = 0;
            while (temp)
            {
                SegList.Add(new Segment(valueToAdd, ramanShift, numberOfShots, checkBox1.Checked, cutWLMpoints.Checked, (int)numberOfColumns.Value));
                temp = SegList.Last().patchSegs(CRDSFileArray, WLMFileArray, whichSeg);
                whichSeg++;
            }
            bubbleSort(ref SegList);

            var allData = new List<Decimal[]>();

            //conditional statement to patch segments or not
            if (checkBox1.Checked)
            {
                for (int i = 0; i < SegList.Count; i++)
                {
                    for (int j = 0; j < SegList[i].patchSeg.GetLength(0); j++)
                    {
                        if (allData.Count != 0 && SegList[i].patchSeg[j, 0] < allData[allData.Count - 1][0])
                        {
                            continue;
                        }
                        decimal[] tempMat = new decimal[1 + (int)numberOfColumns.Value + 1];
                        for (int k = 0; k < tempMat.Length; k++)
                        {
                            tempMat[k] = SegList[i].patchSeg[j, k];
                        }
                        allData.Add(tempMat);
                    }
                }
            }//end checkBox if condition
            else
            {
                for (int i = 0; i < SegList.Count; i++)
                {
                    for (int j = 0; j < SegList[i].patchSeg.GetLength(0); j++)
                    {
                        decimal[] tempMat = new decimal[1 + (int)numberOfColumns.Value + 1];
                        for (int k = 0; k < tempMat.Length; k++)
                        {
                            tempMat[k] = SegList[i].patchSeg[j, k];
                        }
                        allData.Add(tempMat);
                    }
                }
            }



            for (int rowIndex = 0; rowIndex < allData.Count; rowIndex++)
            {
                if (cutWLMpoints.Checked)
                {
                    if (allData[rowIndex][0] < 0M)
                    {
                        continue;
                    }
                }
                StringBuilder line = new StringBuilder();
                if (XYOnly.Checked)
                {
                    line.Append(Convert.ToString(allData[rowIndex][0])).Append("\t");
                    line.Append(Convert.ToString(allData[rowIndex][numberOfColumnsCRDS + 1]));
                }
                else
                {
                    for (int colIndex = 0; colIndex < 1 + numberOfColumnsCRDS + 1; colIndex++)
                    {
                        line.Append(Convert.ToString(allData[rowIndex][colIndex])).Append("\t");
                    }//inner for
                }
                linesToWrite.Add(line.ToString());
            }//end line writer for


            if (String.IsNullOrEmpty(filePath))
            {
                savePatched.InitialDirectory = "V:\\tcodd\\HRCRDS Data\\NO3";//V:\\tcodd\\HRCRDS Data
            }//end if
            else
            {
                savePatched.InitialDirectory = filePath;
            }//end else
            savePatched.OverwritePrompt = true;
            savePatched.CreatePrompt = false;
            savePatched.FileName = "";
            savePatched.Filter = "Text|*.txt|All Files|*.*";
            savePatched.ShowDialog();
            filePath = savePatched.FileName;

            File.WriteAllLines(filePath, linesToWrite, Encoding.ASCII);

            Segment work = new Segment(valueToAdd, ramanShift, numberOfShots, checkBox1.Checked, cutWLMpoints.Checked, (int)numberOfColumns.Value);
            work.patchSegs(CRDSFileArray, WLMFileArray, 0);

            //The following resets all of the variables after each save
            CRDSFileArray = Empty;
            WLMFileArray = Empty;
            linesToWrite.Clear();
            pfreq = 0M;
            //Take care of static variables for Segment objects
            Segment.nnprevW = 5;
            Segment.nprev = 0;
            Segment.wLF = 8;
            Segment.pfreq = 0M;
            Segment.seg = -1;
        }//end patchButtonClick

        private static void bubbleSort(ref List<Segment> user)
        {
            bool swapped = true;
            int j = 0;
            Segment tmp;
            while (swapped == true)
            {
                swapped = false;
                j++;
                for (int i = 0; i < user.Count - j; i++)
                {
                    if (user[i].AverageFrequency > user[i + 1].AverageFrequency)
                    {
                        tmp = user[i];
                        user[i] = user[i + 1];
                        user[i + 1] = tmp;
                        swapped = true;
                    }//end if
                }//end for
            }//end while           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool temp = false;
            if (CalcRamanShift.Checked)
            {
                temp = true;
            }
            TempLabel.Enabled = temp;
            PressureLabel.Enabled = temp;
            TemperatureUpDown.Enabled = temp;
            PressureUpDown.Enabled = temp;
            RegRamanlabel.Enabled = !temp;
            ramanShiftUpDown.Enabled = !temp;
        }//end method bublleSort

        /// <summary>
        /// Calculates the H2 raman shift based on T (K) and P (atm)
        /// </summary>
        /// <returns>
        /// The H2 shift in cm^(-1) as a decimal rounded to the hundred thousandth cm^(-1).
        /// </returns>
        private decimal RamanShift()
        {
            double R = 0.082054;
            double T;
            double P;
            double beta;
            double gamma;
            double delta;
            double A0 = 0.12404;
            double a = 0.05618;
            double B0 = 0.02022;
            double b = -0.00722;
            double c = 20000;
            double VmSTP = 22.427594;
            double rho;
            double Vm;
            double ramanShift;

            //retrieve user input                  
            T = (double)TemperatureUpDown.Value;
            P = (double)PressureUpDown.Value;

            //calculate beta
            beta = R * T * B0 - A0 - (R * c * B0) / (T * T);

            //calculate gamma
            gamma = -R * T * B0 * b + A0 * a - (R * c * B0) / (T * T);

            //calculate delta
            delta = (R * b * B0 * c) / (T * T);

            //calculate Vm
            Vm = R*T/(P)+beta/(R*T)+gamma*P/(R*R*T*T)+delta*P*P/(R*R*R*T*T*T);

            //calculate rho
            rho = VmSTP / Vm;

            //calculate ramanShift value
            ramanShift = 4155.259-0.00325*rho+0.00000463*rho*rho;

            //convert to a decimal and return value to 5 decimal places
            decimal RS = (decimal)ramanShift;
            Math.Round(RS, 5);
            return RS;
        }//end method RamanShift

    }//end form1 class
}//end namespace
