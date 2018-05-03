using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab1
{
    class TrapMethod
    {

        private double Xfirst;
        private double Xend;
        private double step;
        private Func<double, double> f;
        private int threads;
        private Thread[] threadsArr;
        public double[] rezults;
        private double lengthAtThread;
        private int counter=-1;
        //private delegate double MyFunction(double x);

        public double Integral { get; private set; }
       

        public TrapMethod()
        {

        }
        public TrapMethod(double Xfirst, double Xend, double step, Func<double, double> f)
        {
            this.Xfirst = Xfirst;
            this.Xend = Xend;
            this.step = step;
            this.f = f;

            Integral = TrapIntegral(Xfirst, Xend, step, f);
        }

       
        static public double TrapIntegral(double Xfirst, double Xend, double step, Func<double, double> f)
        {
            double f1;
            double f2;
            double sum=0;
            for (double i = Xfirst; i < Xend; i += step)
            {
                f1 = f(i);
                f2 = f(i + step);

                sum += (f1 + f2) / 2.0 * step;
            }
            return sum;
        }

       public double MultiTrapIntegral(double Xfirst, double Xend, double step, Func<double, double> f,int threads)
        {
            UpdateData(Xfirst, Xend, step, f, threads);
            double zona = Xend - Xfirst;
            int steps =Convert.ToInt32(zona / step);
            int stepsAtThread = steps / threads;
            lengthAtThread = stepsAtThread * step;

            threadsArr = new Thread[threads];
            rezults = new double[threads];

            for(int i=0;i<threads;i++)
            {
                threadsArr[i] = new Thread(FunctionForThread);
            }
            for (int i = 0; i < threads; i++)
            {
                threadsArr[i].Start();
            }
            
            for (int i = 0; i < threads; i++)
            {
                threadsArr[i].Join();
            }

            double rezult=0;

            for (int i = 0; i < threads; i++)
            {
                rezult += rezults[i];
            }
            return rezult;

        }


        private void FunctionForThread()
        {
            int counter = ++this.counter;
            //Console.WriteLine(counter);
            double rezult;
            double XfirstTh;
            double XendTh;
            if (counter == (threads - 1))
            {
                XfirstTh = Xfirst + counter * lengthAtThread;
                XendTh = Xend;
            }
            else
            {
                XfirstTh = Xfirst + counter * lengthAtThread;
                XendTh = Xfirst + (counter + 1) * lengthAtThread;
            }
            //Console.WriteLine(XfirstTh+" "+ XendTh);   
            rezult = TrapIntegral(XfirstTh, XendTh, step, f);
            //Console.WriteLine(counter);
            rezults[counter] = rezult;
        }


        private void UpdateData(double Xfirst, double Xend, double step, Func<double, double> f, int threads)
        {
            this.Xfirst = Xfirst;
            this.Xend = Xend;
            this.step = step;
            this.f = f;
            this.threads = threads;
        }
    }

    

     
    


}
