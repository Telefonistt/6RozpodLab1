using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Functions
{
    class SetFunctions
    {
        static public double xsinx(double X)
        {

            return X * Math.Sin(X);
        }

        static public double sinx_xcosx(double X)
        {
            return -X * Math.Cos(X)+ Math.Sin(X);
        }
    }
}
