using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{

    public class Program
    {

        static void Main(string[] args)
        {
            // Getting user input
            Console.WriteLine("Please input a number.");
            Shuffler shuffler = new Shuffler();
            Int32 number;
            String s = Console.ReadLine();
            if (shuffler.IsValid(s)) // Generate a randomly generated list on success
            {
                Int32.TryParse(s, out number);
                if (number > 1000000000)
                {
                    int[][] hugeArray = shuffler.RandomizeHuge(number);
                    int counter = 0;
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine(hugeArray[counter][i % 1000000000]);
                        if ((i % 1000000000) == 0 && i != 0)
                        {
                            counter++;
                        }
                    }
                }
                else
                {
                    int[] numberArray = shuffler.Randomize(number);

                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine(numberArray[i]);
                    }
                }



                Console.ReadLine();
            }
            else { Console.WriteLine("Invalid input."); } // Input failed
        }
    }
}

