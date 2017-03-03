using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaprekar_Numbers
{
    class Program
    {
        static List<int> KaprekarsFromRange(int from, int to)
        {
            List<int> kaprekars = new List<int>();

            for (int i = from; i < to; i++)
            {
                if (isKaprekar(i))
                {
                    kaprekars.Add(i);
                }
            }

            return kaprekars;
        }

        static bool isKaprekar(int num)
        {

            int numSquared = Square(num);

            if (numSquared < 10)
            {
                return false;
            }

            char[] digits = numSquared.ToString().ToCharArray();
            char[] firstHalf = new char[digits.Length / 2];
            char[] secondHalf = new char[digits.Length - firstHalf.Length];

            Array.Copy(digits, 0, firstHalf, 0, firstHalf.Length);
            Array.Copy(digits, digits.Length / 2, secondHalf, 0, secondHalf.Length);

            int first = Convert.ToInt32(new string(firstHalf));
            int second = Convert.ToInt32(new string(secondHalf));

            if (first + second == num)
            {
                return true;
            }

            return false;

        }

        static int Square(int num)
        {
            return (int)Math.Pow(num, 2);
        }

        static void Main(string[] args)
        {
            List<int> kaprekas = KaprekarsFromRange(1, 50);

            foreach (int k in kaprekas.ToArray())
            {
                Console.WriteLine(k);
            }
        }



        
    }
}
