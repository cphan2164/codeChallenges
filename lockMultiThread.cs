using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    class lockChallenge
    {
        public static object tasks = new object();
        public static List<int> taskList = new List<int>();
        public static CountdownEvent tasksLeft;
        public static void Main(string[] args)
        {
            var start = DateTime.Now;
            Random rand = new Random(); 
            Console.WriteLine("How many tasks are to be done?");
            int tasksToDo = Convert.ToInt32(Console.ReadLine());
            tasksLeft = new CountdownEvent(tasksToDo);
            Console.WriteLine("How many workers for the tasks?");
            int workers = Convert.ToInt32(Console.ReadLine());
            
            for(int i = 0; i < tasksToDo; i++)
            {
                taskList.Add(rand.Next(4) + 1);
            }
            for (int i = 0; i < workers; i++) { 
                Thread newThread = new Thread(new ThreadStart(doTask));
                newThread.Name = String.Format("Thread{0}", i+1);
                newThread.Start();
            }

            tasksLeft.Wait();
            string time = (DateTime.Now - start).TotalSeconds.ToString("F2");
            Console.WriteLine("All tasks succesfully done in {0} seconds", time);
            Console.WriteLine("With {0} workers each task took about {1} seconds to complete", workers, (tasksToDo/float.Parse(time)));

        }
        public static void doTask()
        {
            while(taskList.Count != 0)
            {
                int lenOfTask;
                lock(tasks)
                {
                    lenOfTask = taskList[0];
                    taskList.RemoveAt(0);
                }
                Console.WriteLine("{0} is now working on a task for {1} seconds", Thread.CurrentThread.Name, lenOfTask);
                Thread.Sleep(lenOfTask * 1000);
                tasksLeft.Signal();
                Console.WriteLine("Task for {0} succesfully completed", Thread.CurrentThread.Name);
            }

        }
    }
}
