// See https://aka.ms/new-console-template for more information

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
foreach (var testCase in testCases)
{
    Console.WriteLine(CalculatBestBaddnessScore(testCase));
}

return;

int CalculatBestBaddnessScore(Dictionary<string, int> teamsAndWantedPosition)
{
    var bestBaddnessScore = Int32.MaxValue;
    var permutations = GetPermutations(teamsAndWantedPosition, teamsAndWantedPosition.Count);

    foreach (var perm in permutations)
    {
        var newBadnessScore = CalulateBaddnessScore(perm);
        if (newBadnessScore < bestBaddnessScore) bestBaddnessScore = newBadnessScore;
    }
    return bestBaddnessScore;
}

static IEnumerable<IEnumerable<KeyValuePair<TKey, TValue>>> GetPermutations<TKey, TValue>(
    IEnumerable<KeyValuePair<TKey, TValue>> list, int length)
{
    if (length == 1)
        return list.Select(t => new[] { t });

    return GetPermutations(list, length - 1)
        .SelectMany(t => list.Where(o => !t.Contains(o)),
            (t1, t2) => t1.Concat(new[] { t2 }));
}

int CalulateBaddnessScore(IEnumerable<KeyValuePair<string, int>> teams)
{
    int baddnessScore = 0;

    for (int i = 0; i < teams.Count(); i++)
    {
        baddnessScore += Math.Abs(teams.ElementAt(i).Value - (i + 1));
    }
    return baddnessScore;
}