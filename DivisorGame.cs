using System;
using System.Linq;

namespace Main
{
    /// <summary>
    /// https://leetcode.com/problems/divisor-game/submissions/
    /// </summary>
    public static class DivisorGame
    {
        public enum Winner
        {
            Alice,
            Bob
        }

        public static void Execute()
        {
            var winner = DivisorGameImpl(3, true);
            Console.WriteLine($"{winner} wins");
        }

        public static Winner DivisorGameImpl(int N, bool isAliceGo)
        {
            if (N <= 0)
            {
                return !isAliceGo ? Winner.Alice : Winner.Bob;
            }

            var available = Enumerable.Range(1, N).Where(i => i < N && N % i == 0).ToArray();

            if (available.Length == 0)
            {
                return !isAliceGo ? Winner.Alice : Winner.Bob;
            }

            var gameWinner = DivisorGameImpl(N - available[0], !isAliceGo);

            return gameWinner;
        }
    }
}
