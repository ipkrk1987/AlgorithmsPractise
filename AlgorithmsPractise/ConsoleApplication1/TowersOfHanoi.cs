using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    static class TowersOfHanoi
    {
        static int moves = 0;
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            SolveTowersOfHanoi(n, "T1", "T3", "T2");
            Console.WriteLine(moves);
            Console.ReadKey();

        }


        static void SolveTowersOfHanoi(int pegs, string from, string to, string auxillary)
        {
            if (pegs == 1)
            {
                Console.WriteLine(String.Format("MOVE {0} {1}", from, to));
                moves++;
            }
            else
            {
                //Move all pegs to Auxillary using to as auxillary.
                SolveTowersOfHanoi(pegs - 1, from, auxillary, to);
                //Move last peg  of from tower to to tower.
                Console.WriteLine(String.Format("MOVE {0} {1}", from, to));
                moves++;
                // Move all from auxillary to from...using to as auxiallry
                if (pegs > 2)
                    SolveTowersOfHanoi(pegs - 1, auxillary, from, to);
                else // The last peg should move from auxillary to to.
                    SolveTowersOfHanoi(pegs - 1, auxillary, to, from);
            }


        }
    }
}
