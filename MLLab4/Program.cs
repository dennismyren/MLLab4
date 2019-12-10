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
            Console.WriteLine(RetrieveData()[0]);
        }

        private string[] RetrieveData()
        {
            string[] raw = System.IO.File.ReadAllLines(@"..\..\..\city 1.txt");
            return raw;
        }
    }
}
