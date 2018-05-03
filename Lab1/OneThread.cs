using System;
using System.Diagnostics;

namespace Lab1
{
    class MultiThreadTrap
    {
        public double Xfirst { get; private set; }
        public double Xend { get; private set; }
        public double[] Rezult { get; private set; } = new double[2];
        public double[] Dx { get; set; } = new double[1];
        public double[] Time { get; private set; } = new double[1];
        private double FunctionTrap(double x)
        {
            return x*Math.Sin(x);
        }

        private void Integral()
        {
            Rezult[1] = (-Xend * Math.Cos(Xend) + Math.Sin(Xend)) - (-Xfirst * Math.Cos(Xfirst) + Math.Sin(Xfirst));
        }



        public MultiThreadTrap(double Xfirst,double Xend)
        {
            this.Xfirst = Xfirst;
            this.Xend = Xend;
            Dx[0]=0.000001;
            Run();
            Integral();
        }

        private void Run(int threads)
        {
            
        }

        private void Run()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double integral = 0;
            for(double x=Xfirst,x2=Xfirst+Dx[0]; x<=Xend+0.0000001; x+=Dx[0],x2+=Dx[0])
            {
                integral += (FunctionTrap(x) + FunctionTrap(x2)) / 2.0 * (Dx[0]);
            }
            Rezult[0]= integral;
            sw.Stop();
            Time[0] = sw.Elapsed.Milliseconds;
        }
    }
}
