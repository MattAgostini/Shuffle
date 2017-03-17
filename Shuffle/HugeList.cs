using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    /// <summary>
    /// Class to handle large lists and perform operations on them
    /// </summary>
    class HugeList
    {
        public int[][] jaggedArray = new int[3][];
        public int size;
        private const int div = 1000000000;

        /// <summary>
        /// Initializes a new instance of the <see cref="HugeList"/> class.
        /// </summary>
        /// <param name="a">a.</param>
        public HugeList(int a)
        {
            size = a;
            int[] numberArray = new int[div];
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                numberArray[i % div] = i + 1;
                if ((i % div) == 0 && i != 0)
                {
                    jaggedArray[counter] = numberArray;
                    numberArray = new int[div];
                    counter++;
                }
            }
            jaggedArray[counter] = numberArray;
        }

        /// <summary>
        /// Shuffles the list of this instance.
        /// </summary>
        public void Shuffle() {
            Random rng = new Random();
            int temp;
            for (int i = size - 1; i > 0; i--)
            {
                int rand = rng.Next(i + 1);
                temp = jaggedArray[rand / div][rand % div];
                jaggedArray[rand / div][rand % div] = jaggedArray[i / div][i % div];
                jaggedArray[i / div][i % div] = temp;
            }
        }
    }
}
