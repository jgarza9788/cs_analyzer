using System;

namespace Demo.LearnByDoing.General
{
    /// <summary>
    /// Implemented using algorithm in https://youtu.be/q6RicK1FCUs
    /// </summary>
    public class TowerOfHanoiProgram
    {
        public static void Main(string[] args)
        {
            const int disks = 3;
            const int tower1 = 1;
            const int tower2 = 2;
            const int tower3 = 3;

            PrintHanoiSteps(disks, tower1, tower2, tower3);
        }

        private static void PrintHanoiSteps(int disks, int tower1, int tower2, int tower3)
        {
            if (disks > 0)
            {
                // Move disks from tower 1 to tower 2 using tower 3
                PrintHanoiSteps(disks - 1, tower1, tower3, tower2);
                // Move a disk in the first tower to the last one.
                Console.WriteLine("Tower {0} => Tower {1}", tower1, tower3);
                // Move all disks from tower2 to tower3
                PrintHanoiSteps(disks - 1, tower2, tower1, tower3);
            }
        }
    }
}
