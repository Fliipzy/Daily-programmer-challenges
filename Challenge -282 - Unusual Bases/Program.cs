using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unusual_Bases
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Tuple<string, string>[] pairs =
            {
                Tuple.Create("10", "3"),
                Tuple.Create("10", "16"), Tuple.Create("10", "32"),
                Tuple.Create("10", "9024720"),
                Tuple.Create("F", "10"),
                Tuple.Create("F", "1"),
                Tuple.Create("F", "111111"),
                Tuple.Create("F", "100000"),
                Tuple.Create("F", "10110110100111001")
            };
   
            foreach (var pair in pairs)
            {
                string result = string.Empty;

                if (pair.Item1 == "10")
                {
                    result = DecToFib(Convert.ToInt32(pair.Item2));
                }
                else if (pair.Item1 == "F")
                {
                    result = FibToDec(pair.Item2).ToString();
                }

                Console.WriteLine(result);
            }
            
        }

        static string DecToFib(int decValue)
        {
            int i = 0;
            while (decValue >= Fibonacci(i))
            {
                i++;
            }
            char[] charArray = new char[i];

            int counter = 0;
            int tempVal = decValue;
            for (int j = i-1; j > 0; j--)
            {
                if (tempVal >= Fibonacci(j))
                {
                    tempVal -= Fibonacci(j);
                    charArray[counter] = '1';
                }
                else
                {
                    charArray[counter] = '0';
                }
                counter++;
            }
            string result = new string(charArray);
            return result;
        }

        static int FibToDec(string fibValue)
        {
            int val = 0;
            char[] charArray = fibValue.ToCharArray();
            Array.Reverse(charArray);

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == '1')
                {
                    val += Fibonacci(i);
                }
            }

            return val;
        }

        static int Fibonacci(int n)
        {
            int a = 1;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
