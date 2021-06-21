using System;
namespace Main.SeventyFive.TwoPointers
{
    public class BestTimeToBuyAndSellStock
    {
        public static void Execute()
        {
            Console.WriteLine(MaxProfit(new int[]{7, 1, 5, 3, 6, 4}));
        }

        public static int MaxProfit(int[] prices)
        {
            var l = 0;
            var r = 1;

            var maxProfit = 0;

            while (r < prices.Length)
            {
                if (prices[r] - prices[l] > 0)
                {
                    var profit = prices[r] - prices[l];
                    maxProfit = Math.Max(maxProfit, profit);
                }
                else
                {
                    l = r;
                }

                r += 1;
            }

            return maxProfit;
        }
    }
}
