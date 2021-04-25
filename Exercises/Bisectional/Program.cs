using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cssbs_ex08
{

    class Program
    {
        //Variable to count computerCountPerCycle 
        static int computerCountPerCycle = 0;
        //Variable for  total Cycles
        static int totalCycles = 2;

        //Part-1: Implement Bisection Algorithm
        public static void ImplementBisectionAlgorithm()
        {
            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int value = 7;
            int min = 0;
            int max = list.Length;
            bisection_search(list, value, min, max);
        }

        //Part-2: Guess my number, human plays
        public static int GuessNumberHuman()
        {

            int countPerCycle = 1;
            int cyclesSum = 0;

            for (int i = 1; i <= totalCycles; i++)
            {
                //Generating random number
                Random rnd = new Random();
                int number = rnd.Next(1, 1000);

                Console.WriteLine("Cycle Number: " + i + "\n");
                countPerCycle = 1;
                while (true)
                {
                    Console.WriteLine("Guess Attempt #: " + countPerCycle + "\n");

                    while (true)
                    {
                        //Taking user input
                        Console.WriteLine("Guess the Number (Between 1 and 1000): ");
                        string number1 = Console.ReadLine();
                        try
                        {
                            //Parsing to Int
                            int guess = int.Parse(number1);
                            //Checking if Number has been guessed
                            if (guess == number)
                            {
                                Console.WriteLine("You guessed the number.");
                                break;
                            }
                            //Case for guess < number
                            else if (guess < number)
                            {
                                Console.WriteLine("Your guess was too low.");
                                countPerCycle++;
                            }
                            //Case for guess > number
                            else
                            {
                                Console.WriteLine("Your guess was too high.");
                                countPerCycle++;
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(
                                $"The value entered is not valid.");
                        }
                    }
                    break;
                }
                cyclesSum += countPerCycle;
            }

            return cyclesSum / totalCycles;
        }

        //Part-3: Guess my number, computer plays
        public static int GuessNumberComputer()
        {
            int[] list = new int[100];

            for (int i = 0; i < 100; i++)
                list[i] = i + 1;

            int sumTotalCycles = 0;

            for (int i = 1; i <= totalCycles; i++)
            {
                Console.WriteLine("Cycle Number: " + i + "\n");

                while (true)
                {
                    //Taking user input
                    Console.WriteLine("Choose a Number (Between 1 and 100): ");
                    string number = Console.ReadLine();
                    try
                    {
                        //Parsing to Int
                        int value = int.Parse(number);
                        //Validating if number is between 0 and 100
                        if (value > 0 && value < 100)
                        {
                            int min = 0;
                            int max = list.Length;
                            computerCountPerCycle = 0;
                            //Calling method for computer to guess the number 
                            bisection_search(list, value, min, max);
                            //Adding up computer Count Per Cycle
                            sumTotalCycles += computerCountPerCycle;
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(
                            $"The value entered is not valid.");
                    }
                }

            }
            return sumTotalCycles / totalCycles;
        }

        //Defining Bisection Search
        public static object bisection_search(int[] list, int value, int min, int max)
        {
            //Checking if overlapping Occured then return Nil
            if (min > max)
            {
                return "Nil";
            }
            else
            {
                //Calculating Mid Value
                int mid = (min + max) / 2;
                //Checking if value is matched with given Number
                if (value == list[mid])
                {
                    Console.WriteLine("value is equal to " + list[mid]);
                    Console.WriteLine("the value searched for ," + list[mid] + " , has been found");
                    return ++mid;
                }
                //Checking if value < given Number
                else if (value < list[mid])
                {
                    computerCountPerCycle++;
                    Console.WriteLine("value is lower than " + list[mid - 1]);
                    return bisection_search(list, value, min, mid - 1);
                }
                //Checking if value > given Number
                else
                {
                    computerCountPerCycle++;
                    Console.WriteLine("value is higher than " + list[mid - 1]);
                    return bisection_search(list, value, mid + 1, max);
                }
            }
        }
        static void Main(string[] args)
        {

            //Part One
            Console.Write("*************************Part One**************************\n");
            Console.Write("***************Implement Bisection Algorithm***************\n\n");
            ImplementBisectionAlgorithm();

            //Part Two
            Console.Write("\n\n*********************Part Two********************\n");
            Console.Write("***************Average Human guess***************\n\n");
            int humanAverageGuess = GuessNumberHuman();
            Console.Write("Average Human guesses: " + humanAverageGuess);

            //Part Three
            Console.Write("\n\n***************Part Three***************\n");
            Console.Write("***************Average Computer guess***************\n\n");
            int ComputerAverageGuess = GuessNumberComputer();
            Console.Write("Average Computer guesses: " + ComputerAverageGuess);

            Console.ReadLine();

        }

    }
}
