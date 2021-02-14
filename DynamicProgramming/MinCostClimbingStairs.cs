using System;
using System.Collections.Generic;

namespace Main.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/min-cost-climbing-stairs/
    /// </summary>
    public class MinCostClimbingStairs
    {
        public static void Execute()
        {
            //var outcome = Math.Min(MinCostClimbingStairsImpl(new int[] { 10, 15, 20 }, 0, 0),
            //                        MinCostClimbingStairsImpl(new int[] { 10, 15, 20 }, 1, 0));

            var outcome = Math.Min(MinCostClimbingStairsImpl(new int[] { 0, 0, 1, 1}, 0, 0),
                                    MinCostClimbingStairsImpl(new int[] { 0, 0, 1, 1}, 1, 0));

            Console.WriteLine(outcome);
        }

        private static Dictionary<string, int> costCache = new Dictionary<string, int>();

        public static int MinCostClimbingStairsImpl(int [] cost, int current, int priceSoFar)
        {
            if (current >= cost.Length)
            {
                return priceSoFar;
            }

            if (costCache.TryGetValue($"{current}|{priceSoFar}", out var price)) {
                return price;
            }

            var outcome = Math.Min(MinCostClimbingStairsImpl(cost, current + 1, priceSoFar + cost[current]),
                                    MinCostClimbingStairsImpl(cost, current + 2, priceSoFar + cost[current]));

            costCache.Add($"{current}|{priceSoFar}", outcome);

            return outcome;
        }
    }
}
