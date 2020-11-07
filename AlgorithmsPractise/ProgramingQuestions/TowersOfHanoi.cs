using System;
using System.Collections.Generic;
using System.Linq;
 namespace ProgramingQuestions
{
    public  class TowersOfHanoi
    {

        public Func<string> inputMethod;
        public Action<string> outputMethod;

        public int moves = 0;

        public  void Solve()
        {
            outputMethod("Please enter initial number of disks");
            int n = Convert.ToInt32(inputMethod);
            Tower[] towers = new Tower[3] { new Tower(1), new Tower(2), new Tower(3) };
            for (int i = n; i > 0; i--)
                towers[0].Add(i);

            for (int i = 0; i < 3; i++)
                outputMethod($" tower {i} contains {towers[i].GetElements()}"); 

            moveTopnPegs(n,towers[0], towers[2], towers[1]);

            for (int i = 0; i < 3; i++)
                towers[i].GetElements();

            outputMethod(moves.ToString());
            Console.ReadKey();

        }


        private  void moveTopnPegs(int n, Tower startPeg, Tower endPeg, Tower tempPeg)
        {

            if (n > 0)
            {

                moveTopnPegs(n - 1, startPeg, tempPeg, endPeg);               
                outputMethod(startPeg.moveDiskTo(endPeg));
                moves++;
                moveTopnPegs(n - 1, tempPeg, endPeg, startPeg);

            }
        }
       
     
    }

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

        public string GetElements()
        {
            var list = string.Join(",", tower.Reverse().ToList());
            return list;
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

    public static class TowerExtension
    {
        public static string moveDiskTo(this Tower t1, Tower t2)
        {
           
            if (t1.Any())
            {
                var s = t1.Remove();
                t2.Add(s);
            }

            return $"Moving disk from {t1.index} to {t2.index}";


        }
    }
}
