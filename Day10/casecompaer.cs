using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
     public class casecompare : IComparer<String>
    {
        public int Compare(String x, String y)
        {
            String X = x.Trim().ToLower();
            String Y = y.Trim().ToLower();

            return X.CompareTo(Y);
        }
    }
}
