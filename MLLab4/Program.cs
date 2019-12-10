using System;

namespace MLLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            StateHandler sh = new StateHandler(RetrieveData());
            char end = 'F';
            sh.Learn(end);
            Console.WriteLine($"This is all the shortest paths to {end}.");
            foreach (var c in sh.lc)
            {
                Console.WriteLine($"Path of {c} : {sh.GetSequence(c)}");
            }
            //Console.WriteLine($"Path of {start} : {sh.GetSequence(start)}");
        }

        private string[] RetrieveData()
        {
            string[] raw = System.IO.File.ReadAllLines(@"..\..\..\city 1.txt");
            return raw;
        }
    }
}
