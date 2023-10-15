using System;
using System.Threading;

namespace Multithreading
{
    class Multithread
    {
        static void Main(string[] args)
        {
            ThreadStart childref = new ThreadStart(CallToChild);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            Thread.Sleep(2000);
            Console.WriteLine("In Main: Aborting the Child thread");
            childThread.Abort();

        }
        public static void CallToChild()
        {
            try
            {
                Console.WriteLine("Child thread starts");

                // do some work, like counting to 10
                for (int counter = 0; counter <= 10; counter++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(counter);
                }

                Console.WriteLine("Child Thread Completed");

            }
            catch (ThreadAbortException e) {
                Console.WriteLine("Thread Abort Exception");
            } finally {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }


    }
}