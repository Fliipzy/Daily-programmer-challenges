using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases
{
    class Program
    {
        const string HEXCHARS = "abcdef";

        static int FindTrueValue(char c)
        {
            c = char.ToLower(c);
            if (char.IsDigit(c))
            {
                return (int) char.GetNumericValue(c)+1;
            }
            if (HEXCHARS.Contains(c))
            {
                return 10 + HEXCHARS.IndexOf(c)+1;
            }
            throw new Exception("Not a digit");
        }

        static int ToBase10(int baseNum, char[] charValues)
        {
            int result = 0;
            Array.Reverse(charValues);
            for (int i = 0; i < charValues.Length; i++)
            {
                result += (int)((FindTrueValue(charValues[i])-1)*(Math.Pow(baseNum, i)));   
            }
            return result;
        }

        static void Main(string[] args)
        {
            string[] numbers = { "1", "21", "ab3", "ff" };

            foreach (var n in numbers)
            {
                int biggestNum = 0;
                for (int i = 0; i < n.Length; i++)
                {
                    if (biggestNum < FindTrueValue(n[i]))
                    {
                        biggestNum = FindTrueValue(n[i]);
                    }
                }
                Console.WriteLine("Base " + biggestNum + " => " + ToBase10(biggestNum, n.ToCharArray()));
            }
        }
    }
}
