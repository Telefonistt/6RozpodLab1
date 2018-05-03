using System.Diagnostics;
using System;
using System.Threading;

namespace Lab1
{
    class Program
    {
        static double xFirst = -1000;
        static double xEnd = 1000;
        static double step1 = 0.001;
        static double step2 = 0.0001;
        static int threads = 3;
        static void Main()
        {

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //OneThread one = new OneThread(-1.5, 1.5);
            //sw.Stop();
            //Console.WriteLine((sw.Elapsed.Milliseconds/1000.0).ToString() + " sec");
            //Console.WriteLine((one.Time[0]/1000.0).ToString()+" sec");
            //Console.WriteLine((one.Rezult[0]).ToString());
            //Console.WriteLine((one.Rezult[1]).ToString());
            //Console.ReadKey();
            //Stopwatch stop = new Stopwatch();
            //stop.Start();
            
            TrapMethod trap = new TrapMethod();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            double multyRezult = trap.MultiTrapIntegral(xFirst, xEnd, step2, Functions.SetFunctions.xsinx, threads);
            sw.Stop();
            Console.WriteLine((sw.Elapsed).ToString() + " for "+ threads+" threads");

            sw.Restart();
            double razult = TrapMethod.TrapIntegral(xFirst, xEnd, step2, Functions.SetFunctions.xsinx);
            sw.Stop();
            Console.WriteLine((sw.Elapsed).ToString() + " for " + 1 + " threads");

            sw.Restart();
            double trueRezult = Functions.SetFunctions.sinx_xcosx(xEnd) - Functions.SetFunctions.sinx_xcosx(xFirst);
            sw.Stop();
            Console.WriteLine((sw.Elapsed).ToString() + " control");
            //TrapMethod.TrapIntegral(xFirst, xEnd, step1);
            //Console.WriteLine();
            //stop.Stop();
            //Console.WriteLine((stop.Elapsed).ToString() + " sec " + "general");



            //rezult2 = 0;

            //stop.Reset();

            //stop.Start();
            //Thread second = new Thread(new ThreadStart(TestFuncSecond));
            //second.Start();

            //TestFuncFirst((X2 + X1) / 2.0, X2);
            //second.Join();

            //stop.Stop();
            //Console.WriteLine((stop.Elapsed).ToString() + " sec " + "2 threads");
            Console.WriteLine();
            Console.WriteLine(multyRezult+" for multyThread");

            Console.WriteLine(razult+" for 1 Thread");

            Console.WriteLine(trueRezult+ " control");
            //Console.WriteLine((rezult1+rezult2).ToString());
            Console.ReadKey();
           
        }

      //static void TestFuncSecond()
      //  {
      //      DFunction del = new DFunction(FSet.xsinx);
      //      Stopwatch stop1 = new Stopwatch();

      //       double x1Temp = X1;
      //       double x2Temp = (X2+X1)/2.0;
      //       double step1Temp = 0.001;
      //       double step2Temp = 0.0001;
      //       double rezultTemp;

      //      stop1.Start();
      //      TrapMethod tr = new TrapMethod(x1Temp, x2Temp, step2Temp, del);
      //      stop1.Stop();
      //      rezultTemp = tr.Integral;
      //      rezult1 += rezultTemp;
      //      Console.WriteLine((stop1.Elapsed).ToString() + " sec "+ "second");
      //      Console.WriteLine(rezult1.ToString()+" second");
      //  }

      //  static  TestFuncFirst(double xFirst ,double xEnd, double )
      //  {
      //      Console.WriteLine(xFirst.ToString()+ xEnd.ToString());
            
            

            
      //      double step1Temp = 0.001;
      //      double step2Temp = 0.0001;
      //      double rezultTemp;

      //      stop1.Start();
      //      TrapMethod tr = new TrapMethod(xFirst, xEnd, step2Temp, del);
      //      stop1.Stop();
      //      rezultTemp = tr.Integral;
      //      Console.WriteLine(rezult2 + "!!!!!!!!");
      //      rezult2 = rezultTemp;
      //      Console.WriteLine((stop1.Elapsed).ToString() + " sec " + "first");
      //      Console.WriteLine(rezult2.ToString()+"first");
      //  }

    }
}
