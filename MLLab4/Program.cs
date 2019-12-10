using System;

namespace MLLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program();
        }

        public Program()
        {
            StateHandler sh = new StateHandler(RetrieveData());
        }

        private string[] RetrieveData()
        {
            string[] raw = System.IO.File.ReadAllLines(@"..\..\..\city 1.txt");
            return raw;
        }
    }
}
