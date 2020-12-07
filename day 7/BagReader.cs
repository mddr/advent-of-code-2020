using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace day_7
{
    public class BagReader
    {
        public Dictionary<string, IEnumerable<KeyValuePair<string, int>>> Bags { get; set; }

        private List<string> AlreadyCounted { get; set; }
        private const string ShinyGoldKey = "shiny gold";
        private const string EmptyBagKey = "no other bags";
        private static readonly Regex Regex = new Regex(@"^([a-z ]+)contain ([0-9 a-z,]+)");

        public BagReader()
        {
            Bags = new Dictionary<string, IEnumerable<KeyValuePair<string, int>>>();
            AlreadyCounted = new List<string>();
        }

        public void ReadLine(string line)
        {
            if (!Regex.IsMatch(line)) return;

            var withoutDot = line.Replace(".", string.Empty);
            var split = Regex.Split(withoutDot).Where(l => !string.IsNullOrEmpty(l));
            var lineEnumerable = split as string[] ?? split.ToArray();

            var bagName = lineEnumerable
                .First()
                .Cleanup();

            var contents = lineEnumerable.Last();
            if (contents.Contains(EmptyBagKey))
            {
                Bags.Add(bagName, new List<KeyValuePair<string, int>>());
                return;
            }

            var contentsArray = contents.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var finalContents = contentsArray.Select(contentFragment => ParseContent(contentFragment)).ToList();
            Bags.Add(bagName, finalContents);
        }

        private KeyValuePair<string, int> ParseContent(string content)
        {
            var contentRegex = new Regex(@"(\d+) ([a-z ]+)");
            var contentFragments = contentRegex.Split(content).Where(c => !string.IsNullOrEmpty(c.Trim()));
            var enumerable = contentFragments as string[] ?? contentFragments.ToArray();
            var amount = int.Parse(enumerable.First());
            var name = enumerable.Last().Cleanup();

            return new KeyValuePair<string, int>(name, amount);
        }

        public int CountBagHolders(IEnumerable<string> keysToLookFor = null)
        {
            if (keysToLookFor != null && !keysToLookFor.Any())
            {
                AlreadyCounted.Clear();
                return 0;
            }
            var keys = keysToLookFor ?? new[] {ShinyGoldKey};

            var withGold = Bags
                .Where(bag =>
                {
                    var (_, pairs) = bag;
                    return pairs.Count(p => keys.Contains(p.Key)) > 0;
                })
                .Select(pair => pair.Key)
                .Where(bag => !AlreadyCounted.Contains(bag));

            var withGoldArr = withGold as string[] ?? withGold.ToArray();
            foreach (var bag in withGoldArr)
            {
                AlreadyCounted.Add(bag);
            }
            
            return withGoldArr.Count() + CountBagHolders(withGoldArr);
        }
    }
}