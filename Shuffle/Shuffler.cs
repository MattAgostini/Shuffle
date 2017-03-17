using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    public class Shuffler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shuffler"/> class.
        /// </summary>
        public Shuffler() { }

        /// <summary>
        /// Creates a randomized sequence of size a using numbers 1-a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <returns></returns>

        public int[] Randomize(int a)
        {
            int[][] jaggedArray = new int[2][];
            int[] numberArray = new int[a];

            for (int i = 0; i < a; i++)
            {
                numberArray[i] = i + 1;
            }

            Random rng = new Random();
            for (int i = a - 1; i > 0; i--)
            {
                int rand = rng.Next(i + 1);
                int temp = numberArray[rand];
                numberArray[rand] = numberArray[i];
                numberArray[i] = temp;
            }

            return numberArray;
        }

        public int[] Randomize(int a, Random rng)
        {
            int[] numberArray = new int[a];
            for (int i = 0; i < a; i++)
            {
                numberArray[i] = i + 1;
            }

            for (int i = a - 1; i > 0; i--)
            {
                int rand = rng.Next(i + 1);
                int temp = numberArray[rand];
                numberArray[rand] = numberArray[i];
                numberArray[i] = temp;
            }

            return numberArray;
        }

        public int[][] RandomizeHuge(int a)
        {
            HugeList hugeList = new HugeList(a);
            hugeList.Shuffle();
            return hugeList.jaggedArray;
        }

        public bool IsValid(string input)
        {
            int number;
            if (Int32.TryParse(input, out number)) 
            {
                if (number < 0) return false;
                else return true;
            }
            else return false;
        }
    }
}
