using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_to_100
{
    /// <summary>
    /// Task:
    /// 1. Take inputs and determine if it is valid based on http://www.wikihow.com/Count-to-99-on-Your-Fingers
    /// 2. If it is, then decode the inputs into the number represented by the digits on the hand.
    /// 
    /// Formal Inputs and Outputs:
    /// 0111011100 -> 37
    /// 1010010000 -> Invalid
    /// 0011101110 -> 73
    /// 0000110000 -> 55
    /// 1111110001 -> Invalid
    /// </summary>

    class Program
    {

        static bool IsValid(int[] values)
        {
            //iterates through first 3 (0,1,2) fingers.
            for (int i = 0; i < 2; i++)
            {
                //Checks if i is less than or equal to 2 (left middlefinger; last finger that can influence if counting is invalid)
                if (i <= 2 && values[i] == 1)
                {
                    //If we find a finger between 0 and 2 in the array and the finger[i] is equal to 1, and then the finger[i+1] is 0
                    if (values[i+1] == 0)
                    {
                        //We return false because the counting is invalid
                        return false;
                    }
                }
            }
            //Same logic here, we just iterate 'Backwards' from fingers[9] to fingers[7] where the same rules applies for counting.
            for (int i = 9; i > 7; i--)
            {
                if (i >= 7 && values[i] == 1)
                {
                    if (values[i-1] == 0)
                    {
                        return false;
                    }
                }
            }
            // If none of the values/fingers break the rules we return true
            return true;
        }
        
        static int FingerToDec(int[] values)
        {
            int result = 0;
            int[] leftHand = new int[5];
            int[] rightHand = new int[5];

            for (int i = 0; i < 5; i++)
            {
                leftHand[i] = values[i];
                rightHand[i] = values[5 + i];
            }

            Array.Reverse(leftHand);

            if (leftHand[0] == 1)
            {
                result += 50;
            }
            if (rightHand[0] == 1)
            {
                result += 5;
            }

            for (int i = 1; i < 5; i++)
            {
                if (leftHand[i] == 1)
                {
                    result += 10;
                }
                if (rightHand[i] == 1)
                {
                    result += 1;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            List<int[]> fingerArrayList = new List<int[]>();

            fingerArrayList.Add(new[] {0, 1, 1, 1, 0, 1, 1, 1, 0, 0});
            fingerArrayList.Add(new[] {1, 0, 1, 0, 0, 1, 0, 0, 0, 0});
            fingerArrayList.Add(new[] {0, 0, 1, 1, 1, 0, 1, 1, 1, 0});
            fingerArrayList.Add(new[] {0, 0, 0, 0, 1, 1, 0, 0, 0, 0});
            fingerArrayList.Add(new[] {1, 1, 1, 1, 1, 1, 0, 0, 0, 1});

            foreach (var f in fingerArrayList)
            {
                string fArray = String.Join("", f.Select(n => n.ToString()).ToArray());
                
                Console.WriteLine("{0} -> {1}", fArray.ToString(), IsValid(f) ? FingerToDec(f).ToString() : "Invalid");
            }
        }
    }
}
