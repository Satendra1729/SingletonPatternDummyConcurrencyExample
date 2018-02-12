using System;
using System.Threading;
using System.Collections.Generic;
namespace SingletonPatternChecking
{
    class Program
    {
        static object loc = new object();
        public static List<Thread> ths = new List<Thread>();
        static void Main(string[] args)
        {
            object loc = new object();
            for (int i = 0; i < 10; i++)
            {
                int j = i;
                ths.Add(new Thread(() => DummyMapperQualifierHelper.GetInstance("worker"+j.ToString(), loc)));
            }
            foreach (Thread th in ths)
                th.Start();
            Console.ReadLine(); 
        }
    }
}
