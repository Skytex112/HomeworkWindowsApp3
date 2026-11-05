using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreads3_Homework.Objects
{
    internal class ClassTask2
    {

        private int number = 10;
        private string text = "Hello";

        private void Print() { Console.WriteLine(text); }
        private void Show() { Console.WriteLine(number); }
    }
}
