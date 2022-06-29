using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class wordercomp : IEqualityComparer<String>
    {

        public bool Equals(string x, string y)
        {
            String X = x.Trim();
            String Y = y.Trim();
            int xx = X.Sum(ch => (int)ch * ((int)ch % 65));
            int yy = Y.Sum(ch => (int)ch * ((int)ch % 65));

            return xx == yy;
        }

        public int GetHashCode(string obj)
        {
            return 1;
        }
    }
}