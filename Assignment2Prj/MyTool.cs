using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Prj
{
    internal class MyTool
    {
        //adapted from website. 
        public static int[] ProduceNonrepetitiveNumber(int iLow, int iHigh, int iNum)
        {
            int[] index = new int[iHigh - iLow + 1];
            int j = 0;
            for (int i = iLow; i < iHigh + 1; i++, j++)
                index[j] = i;
            Random r = new Random();
            int[] result = new int[iNum];
            int iSite = index.Length;
            int id;
            for (int i = 0; i < iNum; i++)
            {
                id = r.Next(0, iSite - 1);
                result[i] = index[id];
                index[id] = index[iSite - 1];
                iSite--;
            }
            return result;

        }
    }
}
