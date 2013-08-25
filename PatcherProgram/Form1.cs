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
        public string[] CRDSNewLine;
        public string[] WLMNewLine;
        public string[] Empty = {};
        public string[,] Empty2 = {};
        public string[] CRDSSeg;
        public string[] WLMSeg;
        //public string[,] PatchSeg;
        //public decimal[,] PatchSeg;
        public string filePath;
        public decimal valueToAdd = 0M;
        public decimal ramanShift = 4155.25000M;
        public decimal pfreq = 0M;
        public int numberOfColumnsCRDS = 6;
        //public int f = 0;
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
            CRDSopenFileDialog.Title = "Select a CRDS file";
            if (String.IsNullOrEmpty(filePath))
            {
                CRDSopenFileDialog.InitialDirectory = "V:\\tcodd\\HRCRDS Data\\NO3";
            }//end if
            else 
            {
                CRDSopenFileDialog.InitialDirectory = filePath;
            }//end else
            CRDSopenFileDialog.FileName = "";
            CRDSopenFileDialog.Filter = "DAT|*.dat|All Files|*.*";

            CRDSopenFileDialog.ShowDialog();

            filePath = CRDSopenFileDialog.FileName;

            using (StreamReader CRDSfile = new StreamReader(filePath))
            {
                //this copies the CRDS file into a string array    
                string lineC;
                while ((lineC = CRDSfile.ReadLine()) != null)//says read until no more lines are left
                {
                    char[] delimiters = new char[] { '\t', '\r' };//declares tabs and carriage returns as delimiters
                    CRDSNewLine = lineC.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);//creates array, clearing empty values
                    CRDSFileArray = CRDSFileArray.Concat(CRDSNewLine).ToArray();//need to concatenate the previous CRDSFileArray with CRDSNewLine
                }//end while
            }//end StreamReader
        }//end button click

        private void button2_Click(object sender, EventArgs e)
        {
            WLMopenFileDialog.Title = "Select a WLM file";
            if (String.IsNullOrEmpty(filePath))
            {
                WLMopenFileDialog.InitialDirectory = "V:\\tcodd\\HRCRDS Data\\NO3";
            }//end if
            else
            {
                WLMopenFileDialog.InitialDirectory = filePath;
            }//end else
            WLMopenFileDialog.FileName = "";
            WLMopenFileDialog.Filter = "Text|*.txt|All Files|*.*";

            WLMopenFileDialog.ShowDialog();

            filePath = WLMopenFileDialog.FileName;

            using (StreamReader WLMfile = new StreamReader(filePath))
            {
                //this copies the WLM file into a string array
                string lineW;
                while ((lineW = WLMfile.ReadLine()) != null)//says read until no more lines
                {
                    char[] delimitersW = new char[] { '\t', '\r' };
                    WLMNewLine = lineW.Split(delimitersW, StringSplitOptions.RemoveEmptyEntries);
                    WLMFileArray = WLMFileArray.Concat(WLMNewLine).ToArray();
                }//end while
            }//end StreamReader
        }//end WLM open button

        private void patchButton_Click(object sender, EventArgs e)
        {
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
                SegList.Add(new Segment(valueToAdd, ramanShift, numberOfShots, checkBox1.Checked, cutWLMpoints.Checked, (int) numberOfColumns.Value));
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
            
            

            for(int rowIndex = 0; rowIndex < allData.Count; rowIndex++)
            {
                if (cutWLMpoints.Checked)
                {
                    if (allData[rowIndex][0] < 0M)
                    {
                        continue;
                    }
                }
                StringBuilder line = new StringBuilder();
                for(int colIndex = 0; colIndex < 1 + numberOfColumnsCRDS + 1; colIndex++)
                {
                    line.Append(Convert.ToString(allData[rowIndex][colIndex])).Append("\t");
                }//inner for
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
            if (CalcRamanShift.Checked)
            {
                TempLabel.Enabled = true;
                PressureLabel.Enabled = true;
                TemperatureUpDown.Enabled = true;
                PressureUpDown.Enabled = true;
                RegRamanlabel.Enabled = false;
                ramanShiftUpDown.Enabled = false;
            }
            else
            {
                TempLabel.Enabled = false;
                PressureLabel.Enabled = false;
                TemperatureUpDown.Enabled = false;
                PressureUpDown.Enabled = false;
                RegRamanlabel.Enabled = true;
                ramanShiftUpDown.Enabled = true;
            }
        }//end method bublleSort

        private decimal RamanShift()
        {
            const double R = 0.082054;
            double T;
            double P;
            double beta;
            double gamma;
            double delta;
            const double A0 = 0.12404;
            const double a = 0.05618;
            const double B0 = 0.02022;
            const double b = -0.00722;
            const double c = 20000;
            const double VmSTP = 22.427594;
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
