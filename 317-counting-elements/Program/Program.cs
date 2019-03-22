using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var molecules = new [] { "CCl2F2", "NaHCO3", "C4H8(OH)2"};

            foreach (var molecule in molecules)
            {
                PrintMolecule(molecule, GetElementCounts(molecule));
            }
        }

        private static Dictionary<string, int> GetElementCounts(string elements)
        {
            var dictionary = new Dictionary<string, int>();
            var matches = Regex.Matches(elements, @"([A-Z]{1}[a-z]?\d*)|(\(.+\)\d*)");

            foreach (var element in matches.Cast<object>().Select(x => x.ToString()))
            {
                string name;
                int index, count;

                if (!element.Contains("("))
                {
                    index = Regex.Match(element, @"\d+").Index;

                    count = index > 0 ? int.Parse(element.Substring(index)) : 1;

                    name = index > 0 ? element.Substring(0, index) : element;

                    if (dictionary.TryGetValue(name, out int temp))
                    {
                        dictionary[name] += count;
                    }
                    else
                    {
                        dictionary.Add(name, count);
                    }
                }

                else
                {
                    var groupCountMatch = Regex.Match(element, @"\d+$");
                    var subCounts = GetElementCounts(element.Substring(1, groupCountMatch.Index - 2));

                    foreach (var key in subCounts.Keys)
                    {
                        var finalValue = subCounts[key] * int.Parse(groupCountMatch.Groups[0].Value);

                        if (dictionary.TryGetValue(key, out int temp))
                            dictionary[key] += finalValue;
                        else
                            dictionary.Add(key, finalValue);
                    }

                }
                
            }

            return dictionary;
        }

        private static void PrintMolecule(string molecule, Dictionary<string, int> counts)
        {
            Console.WriteLine($"Counts for {molecule} \n");

            foreach (var key in counts.Keys)
            {
                Console.WriteLine($"{key}: {counts[key]} \n");
            }
        }
    }
}
