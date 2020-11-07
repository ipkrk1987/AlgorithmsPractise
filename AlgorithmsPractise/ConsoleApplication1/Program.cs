using ProgramingQuestions;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static int moves = 0;
        static void Main(string[] args)
        {
            ProgramingQuestions.TowersOfHanoi hanoi = new ProgramingQuestions.TowersOfHanoi();
            hanoi.inputMethod+= Console.ReadLine;
            hanoi.outputMethod += Console.WriteLine;
        }


   
    }
}
