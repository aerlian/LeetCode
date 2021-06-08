using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Main
{
    public class ParseChallenges
    {
        public static void Execute()
        {
            ParseChallengesImpl();
        }

        public static void ParseChallengesImpl()
        {
            var lines = File.ReadAllLines("/Users/stephenrodgers/Documents/challenges.csv");

            var groupMap = new List<List<string>>();
            var currentList = new List<string>();

            for(var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line == $"\t")
                {
                    groupMap.Add(currentList);
                    currentList = new List<string>();
                    continue;
                }

                currentList.Add(line);
            }

            groupMap.Add(currentList);


            var output = groupMap.Select(g => $"{string.Join("|", g)}");
            File.WriteAllLines("/Users/stephenrodgers/Documents/challenges2.csv", output);
        }
    }
}
