using System;

namespace ProgramingQuestions
{
    static class TowersOfHanoi
    {

        public class Tower
        {
            public int index { get; private set; }
            Stack<int> tower = new Stack<int>();
            public Tower(int index)
            {
                this.index = index;
            }

            public void Add(int n)
            {
                if (tower.Any() && tower.Peek() < n)
                    throw (new Exception("Cant stack a larger disk on smaller"));

                tower.Push(n);

            }

            public int Remove()
            {
                return tower.Pop();
            }

            public void GetElements()
            {
                var list = string.Join(",", tower.Reverse().ToList());
                Console.WriteLine($" tower {index } contains {list}");
            }
            public bool Any()
            {
                return tower.Any();

            }

            public int count()
            {
                return tower.Count;

            }
        }

        public static void MoveFromThisToThat(this Tower t1, Tower t2)
        {
            var s = t1.Remove();

            t2.Add(s);


        }

        static int moves = 0;

        public static void Solve()
        {
            Console.WriteLine("Please enter initial number of disks");
            int n = Convert.ToInt32(Console.ReadLine());
            Tower[] towers = new Tower[3] { new Tower(1), new Tower(2), new Tower(3) };
            for (int i = n; i > 0; i--)
                towers[0].Add(i);

            SolveTowersOfHanoifor3(towers[0], towers[2], towers[1]);
            while (n > 3)
            {
                if (n % 2 == 0)
                {
                    towers[0].MoveFromThisToThat(towers[1]);
                    SolveTowersOfHanoifor3(towers[2], towers[1], towers[0]);

                }
                else
                {
                    towers[0].MoveFromThisToThat(towers[1]);
                    SolveTowersOfHanoifor3(towers[2], towers[1], towers[0]);

                }

                n--;
            }




            //int a = 3; 
            while (towers[1].count() != n)
                //{
                //    if (a % 2 == 0)
                //    {
                //        towers[0].MoveFromThisToThat(towers[1]);
                //        SolveTowersOfHanoi(towers[2], towers[1], towers[0]);
                //    }
                //    else
                //    {
                //        towers[0].MoveFromThisToThat(towers[2]);
                //        SolveTowersOfHanoi(towers[0], towers[2], towers[1]);

                //    }
                //    a++;
                //}


                //Console.WriteLine(moves);
                Console.ReadKey();

        }

        /*** 
       * T1| T2| A
       * 3,2,1|  |
       * 3,2 | 1|
       * 3|1|2
       * 3||2,1
       * |3|2,1
       * 1|3|2
       * 1|3,2|
       * |3,2,1|
       * **/
        private static void SolveTowersOfHanoifor3(Tower from, Tower to, Tower aux)
        {
            from.MoveFromThisToThat(to);
            from.MoveFromThisToThat(aux);

            GetStatus(from, to, aux);
            to.MoveFromThisToThat(aux);
            from.MoveFromThisToThat(to);

            GetStatus(from, to, aux);
            aux.MoveFromThisToThat(from);
            aux.MoveFromThisToThat(to);
            GetStatus(from, to, aux);

            from.MoveFromThisToThat(to);

            GetStatus(from, to, aux);





        }

        private static void GetStatus(Tower t1, Tower t2, Tower a)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
            t1.GetElements();
            t2.GetElements();
            a.GetElements();
        }
        static void SolveTowersOfHanoi2(int pegs, string from, string to, string auxillary)
        {
            if (pegs == 1)
            {
                Console.WriteLine(String.Format("MOVE {0} {1}", from, to));
                moves++;
            }
            else
            {
                //Move all pegs to Auxillary using to as auxillary.
                SolveTowersOfHanoi2(pegs - 1, from, auxillary, to);
                //Move last peg  of from tower to to tower.
                Console.WriteLine(String.Format("MOVE {0} {1}", from, to));
                moves++;
                // Move all from auxillary to from...using to as auxiallry
                if (pegs > 2)
                    SolveTowersOfHanoi2(pegs - 1, auxillary, from, to);
                else // The last peg should move from auxillary to to.
                    SolveTowersOfHanoi2(pegs - 1, auxillary, to, from);
            }


        }
    }

}
