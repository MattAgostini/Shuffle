using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shuffle;

namespace ShuffleTest
{
    [TestClass]
    public class ShufflerTest
    {
        
        [TestMethod]
        public void InputTest_NegativeNumber()
        {
            Shuffler shuffler = new Shuffler();
            Assert.AreEqual(false, shuffler.IsValid("-1"));
        }

        [TestMethod]
        public void InputTest_HugeNumber()
        {
            Shuffler shuffler = new Shuffler();
            Assert.AreEqual(false, shuffler.IsValid("4000000000"));
        }

        [TestMethod]
        public void InputTest_Characters()
        {
            Shuffler shuffler = new Shuffler();
            Assert.AreEqual(false, shuffler.IsValid("TestString"));
        }

        [TestMethod]
        public void InputTest_ValidInput()
        {
            Shuffler shuffler = new Shuffler();
            Assert.AreEqual(true, shuffler.IsValid("5"));
        }

        [TestMethod]
        public void RandomnessTest()
        {
            double[] occurances = {0,0,0,0,0,0};
            Shuffler shuffler = new Shuffler();
            Random rng = new Random();
            double trials = 6000000;
            double probability = 1.0/6.0;
            for (int i = 0; i < trials; i++)
            {

                shuffler = new Shuffler();
                int[] list = shuffler.Randomize(3 , rng);

                if (list[0] == 1) 
                {
                    if (list[1] == 2) { occurances[0] = occurances[0] + 1; } // 123
                    else occurances[1] = occurances[1] + 1; // 132
                }
                else if (list[0] == 2) 
                {
                    if (list[1] == 1) { occurances[2] = occurances[2] + 1; } // 213
                    else occurances[3] = occurances[3] + 1; // 231
                }
                else // list[0] == 3
                {
                    if (list[1] == 1) { occurances[4] = occurances[4] + 1; } //312
                    else occurances[5] = occurances[5] + 1; // 321
                }

            }
            // Performing the Chi-Square test
            double sum = 0;
            for (int j = 0; j < 6; j++)
            {
                sum = sum + (Math.Pow(occurances[j] - (trials*probability), 2) / (trials*probability));
            }
            Console.WriteLine(sum);
            Console.WriteLine(occurances[0]);
            Console.WriteLine(occurances[1]);
            Console.WriteLine(occurances[2]);
            Console.WriteLine(occurances[3]);
            Console.WriteLine(occurances[4]);
            Console.WriteLine(occurances[5]);

            Assert.AreEqual(true,sum < 10);
        }


    }
}

