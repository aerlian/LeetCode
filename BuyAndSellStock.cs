using System;
namespace Main
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    /// </summary>
    public static class BuyAndSellStock
    {
        public static void Execute()
        {           
            //Console.WriteLine($"Profit:{MaxProfit(new[] { 7, 1, 5, 3, 6, 4 })}");
            Console.WriteLine($"Profit:{MaxProfit(new[] { 7, 6, 4, 3, 1 })}");
        }

        public static int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
            {
                return 0;
            }

            var maxDiff = 0;

            for(var i = 0; i < prices.Length - 1; i++)
            {
                for (var j = i + 1; j < prices.Length; j++)
                {
                    var diff = prices[j] - prices[i];

                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }
            }

            return maxDiff;
        }
    }
}
