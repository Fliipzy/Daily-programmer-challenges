using System;
using System.Text;

namespace Uuencoding
{
    class Program
    {
        static void OutputUuencoded(string fileName, string msg)
        {
            Console.WriteLine("begin 644 {0}.txt", fileName);
            Console.WriteLine("{0} \n`\nend", msg);
        }

        static string Encode(string message)
        {

            while (message.Length % 3 != 0)
            {
                message = message.Insert(message.Length, "0");
            }

            string[] cutUpBinaryString = new string[((message.Length / 3) * 4)];
            string binaryString = StringToBinary(message);
            
            for (int i = 0; i < binaryString.Length; i += 6)
            {
                cutUpBinaryString[i / 6] = binaryString.Substring(i, 6);
            }

            byte[] ASCII_values = new byte[cutUpBinaryString.Length];

            for (int i = 0; i < cutUpBinaryString.Length; i++)
            {
                ASCII_values[i] = (byte)(Convert.ToInt32(cutUpBinaryString[i].ToString(), 2) + 32);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var val in ASCII_values)
            {
                sb.Append(Encoding.ASCII.GetString(new byte[] { val }));
            }
            return sb.ToString();
        }

        static string StringToBinary(string input)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in input.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8,'0'));
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string msg = "I feel very strongly about you doing duty. Would you give me a little" +
                         " more documentation about your reading in French? I am glad you are happy" +
                         " - but I never believe much in happiness. I never believe in misery either." +
                         " Those are things you see on the stage or the screen or the printed pages," +
                         " they never really happen to you in life.";

            OutputUuencoded("fred", Encode(msg));


        }
    }
}
