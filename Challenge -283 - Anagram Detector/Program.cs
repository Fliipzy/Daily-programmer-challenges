using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            Pair<string, string>[] pairs =
            {
                Pair.Create("wisdom", "mid sow"), Pair.Create("Seth Rogan", "Gathers No"),
                Pair.Create("Reddit", "Eat Dirt"), Pair.Create("Schoolmaster", "The classroom"),
                Pair.Create("Astronomers", "Moon starer"), Pair.Create("Vacation Times", "I'm Not as Active"),
                Pair.Create("Dormitory", "Dirty Rooms")
            };

            foreach (var pair in pairs)
            {
                Console.WriteLine("{0} is{1} an anagram of {2}", pair.Item1, IsAnagram(pair) ? "" : " NOT", pair.Item2);
            }

            Console.Read();
        }



        static bool IsAnagram(Pair<string, string> pair)
        {
            string s1 = pair.Item1.ToLower().Replace(" ", "").Replace("'", "");
            string s2 = pair.Item2.ToLower().Replace(" ", "").Replace("'", "");

            if (s1.Length != s2.Length)
            {
                return false;
            }

            foreach (char c in s1)
            {
                if (!s2.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
