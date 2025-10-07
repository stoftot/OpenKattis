namespace Biased_Standings;
using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int numberOfTestCases = int.Parse(Console.ReadLine()!);
        
        var testCases = new List<Dictionary<string, int>>();
        for (int t = 0; t < numberOfTestCases; t++)
        {
            Console.ReadLine();
            int numberOfTeams = int.Parse(Console.ReadLine()!);
            var teamsAndWantedPosition = new Dictionary<string, int>();
            for (int i = 0; i < numberOfTeams; i++)
            {
                var input = Console.ReadLine()!.Split(' ');
                teamsAndWantedPosition[input[0]] = int.Parse(input[1]);
            }
            testCases.Add(teamsAndWantedPosition);
        }
        
        //print dictionaries
        foreach (var list in testCases.Select(testCase => testCase.ToList()))
        {
            list.Sort((a, b) => a.Value.CompareTo(b.Value));
            Console.WriteLine(CalulateBaddnessScore(list));
        }
        
        return;

        BigInteger CalulateBaddnessScore(IEnumerable<KeyValuePair<string, int>> teams)
        {
            BigInteger baddnessScore = 0;
        
            for (int i = 0; i < teams.Count(); i++)
            {
                baddnessScore += Math.Abs(teams.ElementAt(i).Value - (i + 1));
            }
            return baddnessScore;
        }
    }
}