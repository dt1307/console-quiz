using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuizBackend
{
    // generate random number using System.Cryptography
    class Randomizer
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        // generates the number
        public static int GetRandomNumber(int maxValue)
        {
            byte[] randomByte = new byte[1];
            _generator.GetBytes(randomByte);
            double asciValueOfRandomChar = Convert.ToDouble(randomByte[0]);
            double multiplier = Math.Max(0, (asciValueOfRandomChar / 255d) - 0.00000000001d);
            double randomValueInRange = Math.Floor(multiplier * maxValue);
            return (int)(1 + randomValueInRange);
        }

        // generates a set of unique random numbers
        public static List<int> GetListOfRandomNumbers(int amount, int maxValue)
        {
            var result = new List<int>();
            while (result.Count() < amount)
            {
                int rnd = GetRandomNumber(maxValue);
                if (!result.Contains(rnd))
                {
                    result.Add(rnd);
                }
            }

            return result;
        }

    }
}
