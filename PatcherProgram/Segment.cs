using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Segment
    {
        //static variables used in each call to patchSeg
        public static int nprev = 0;
        public static int nnprevW = 5;
        public static int wLF = 8;
        //static int nw = 1;
        public static decimal pfreq = 0M;
        public static int seg = -1;

        //local variables for patchSeg
        string[] CRDSSeg;
        string[] WLMSeg;

        //the final patched segment
        private decimal[,] PatchSeg;
        public decimal[,] patchSeg
        {
            get { return PatchSeg; }
        }

        private decimal avgFreq;
        public decimal AverageFrequency
        {
            get { return avgFreq; }
        }

        //private variables for each Segment object
        private decimal valueToAdd;
        private decimal ramanShift;
        private int numberOfShots;
        private bool checkbox1;
        private bool cutWLMpoints;
        private int numberOfColumnsCRDS;
        private int onCol;
        private int offCol;

        public Segment(decimal vTA, decimal rS, int nOS, bool cb1, bool cWLMp, int nOC)
        {
            valueToAdd = vTA;
            ramanShift = rS;
            numberOfShots = nOS;
            checkbox1 = cb1;
            cutWLMpoints = cWLMp;
            numberOfColumnsCRDS = nOC;

            if (nOC == 6)
            {
                onCol = 4;
                offCol = 1;
            }
            else if (nOC == 4)
            {
                onCol = 3;
                offCol = 1;
            }
            else if (nOC == 2)
            {
                onCol = 2;
                offCol = 1;
            }
            else
            {
                onCol = offCol = 0;
            }//end if
        }

        public bool patchSegs(string[] CRDSFileArray, string[] WLMFileArray, int whichSeg)
        {
            for (int n = nprev; n < CRDSFileArray.Length; n += numberOfColumnsCRDS)
            {
                //Run nested for loops to patch segs, CRDS segs first
                decimal valueC = Convert.ToDecimal(CRDSFileArray[n]);
                if (valueC < -600M)
                {
                    seg++;
                }
                if(seg == whichSeg)
                {
                    CRDSSeg = CRDSFileArray.Skip(nprev).Take(n - nprev).ToArray();

                    //now run WLM for loop
                    for (int nn = wLF; nn < WLMFileArray.Length; nn += 5)
                    {
                        decimal valueW = Convert.ToDecimal(WLMFileArray[nn]);
                        if (valueW > (numberOfShots * 100 + 100))
                        {
                            WLMSeg = WLMFileArray.Skip(nnprevW).Take(nn - 3 - nnprevW).ToArray();
                            nnprevW = nn + 2;
                            wLF = nn + 5;
                            break;
                        }//end WLM if condition
                    }//end WLM for loop

                    int smaller = CRDSSeg.Length / numberOfColumnsCRDS;
                    if (WLMSeg.Length / 5 < CRDSSeg.Length / numberOfColumnsCRDS)
                    {
                        smaller = WLMSeg.Length / 5;
                    }//end smaller if loop

                    //this removes the first point of the WLM file if it is one of those jump points
                    int start = 0;
                    for (; ; )
                    {
                        if (Convert.ToDecimal(WLMSeg[1 + 5 * start]) > Convert.ToDecimal(WLMSeg[1 + 5 * (start + 1)]))
                        {
                            start++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    PatchSeg = new decimal[smaller - start, 1 + numberOfColumnsCRDS + 1];
                    for (int i = 0; i < smaller - start; i++)
                    {                            
                        PatchSeg[i, 0] = Convert.ToDecimal(WLMSeg[1 + 5 * (i + start)]);
                        
                        for (int k = 0; k < numberOfColumnsCRDS; k++)
                        {
                            PatchSeg[i, k + 1] = Convert.ToDecimal(CRDSSeg[k + (i + start) * numberOfColumnsCRDS]);
                        }
                        PatchSeg[i, 1 + numberOfColumnsCRDS] = Convert.ToDecimal(PatchSeg[i, onCol]) - Convert.ToDecimal(PatchSeg[i, offCol]);
                    }//end patchseg for

                    avgFreq = 0.0M;
                    int temp = 0;
                    for (int m = 0; m < patchSeg.GetLength(0); m++)
                    {
                        if (patchSeg[m, 0] - valueToAdd < -10000M)
                        {
                            temp++;
                            continue;
                        }
                        avgFreq += patchSeg[m, 0];
                    }
                    avgFreq = avgFreq / (patchSeg.GetLength(0) - temp);

                    pfreq = Convert.ToDecimal(WLMSeg[WLMSeg.Length - 4]);

                    //set variables for next iteration
                    n += numberOfColumnsCRDS;
                    nprev = n;
                    if (nprev >= CRDSFileArray.Length)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }//end CRDS if                
            }//end CRDS for loop
            return false;            
        }
    }
}
