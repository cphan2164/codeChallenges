using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Counter
    {
        private static Mutex mut = new Mutex();
        public static int counter = 0;
        public static DateTime starttime = DateTime.Now;
        public static CountdownEvent threadsRunning;
        static void Main(string[] args)
        {
            int threads;
            Console.WriteLine("How many threads should be made");
            int numOfThreads = Convert.ToInt32(Console.ReadLine());
            threadsRunning = new CountdownEvent(numOfThreads);
            for(int i = 0; i < numOfThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(randomizer));
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
            }

            threadsRunning.Wait();
            Console.WriteLine("The final count is {0}, created by {1} thread(s)", counter, numOfThreads);
            threadsRunning.Dispose();
        }

        public static void randomizer()
        {
            bool shouldTerminate = false;
            while (!shouldTerminate)
            {
                Random rand = new Random();
                int count = rand.Next(10) + 1;
                int wait = rand.Next(400) + 101;
                Console.WriteLine("{0} is requesting the mutex",
                          Thread.CurrentThread.Name);
                mut.WaitOne();

                Console.WriteLine("{0} has entered the protected area",
                                  Thread.CurrentThread.Name);
                counter += count;
                mut.ReleaseMutex();
                Console.WriteLine("{0} has released the mutex",
            Thread.CurrentThread.Name);
                Console.WriteLine("The counter has been raised by {0} and is at {1}", count, counter);
                if (DateTime.Now - starttime > TimeSpan.FromSeconds(5))
                {
                    shouldTerminate = true;
                    Console.WriteLine("{0} is being terminated", Thread.CurrentThread.Name);
                    threadsRunning.Signal();
                }
                else
                {
                    Console.WriteLine("Thread {0} is going to sleep for {1} milliseconds", Thread.CurrentThread.Name, wait);
                    Thread.Sleep(wait);
                }
            }

        }
    }
}
