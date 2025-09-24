using System;
using System.Threading;

namespace GraphicsConsolePractice
{
    class Program
    {
        static void Main(string[] args)
        {

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;


            using (Spinner spinner = new Spinner(centerX, centerY))
            {

                spinner.Start();
                Thread.Sleep(10000);

                spinner.Stop();
                Console.Write("Stop");
            }
                
      

        }
    }
}