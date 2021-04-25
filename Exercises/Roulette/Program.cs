using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


namespace Ex7Roulette
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Random ran = new Random();
            var r = new Random();
            string[] colors = { "Red", "Black" };
            int[] columns1 = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
            int[] columns2 = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
            int[] columns3 = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
            string guess;
            string streetGuess;
            int attempts = 0;
            int bet;
            int money = 500;
            int[] streets = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36};
                            //0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,  11, 12, 13, 14, 15, 16,....
                               /*  int[] street2 = {4, 5, 6};

            int[] street3 = { 7, 8, 9 };
            int[] street4 = { 10, 11, 12 };
            int[] street5 = { 13, 14, 15};
            int[] street6 = { 16, 17, 18};
            int[] street7 = { 19, 20, 21 };
            int[] street8 = { 22, 23, 24};
            int[] street9 = { 25, 26, 27 };
            int[] street10 = { 28, 29, 30 };
            int[] street11 = { 31, 32, 33 };
            int[] street12 = { 34, 35, 36 };
          */




            while (money != 0)
            {
                Console.WriteLine("Roulette Roller for MSSA!\n");
                Console.WriteLine("Money:$" + money + "                  Attempts: " + attempts);
                Console.WriteLine("Type in any off the following letters below:");
                Console.WriteLine("a.Even    b.Odd    c.1 to 18    d.19 to 36");
                Console.WriteLine("e.Red     f.Black  g.1st 12     h.2nd 12");
                Console.WriteLine("i.3rd 12  j. Column1   k. Column2  l. Column3");
                Console.WriteLine("m.street  n. double row  o. split  p. corner");
                Console.WriteLine("q. Conclude Game.");
                //Console.WriteLine("m. );
                guess = (Console.ReadLine());
                //guess verifier
                guess.ToLower();
                bool check = guess == "a" || guess == "b" || guess == "c" || guess == "d" || guess == "e" || guess == "f" || guess == "g" || guess == "h" || guess == "i" || guess == "j" || guess == "k" || guess == "l" || guess == "m" || guess == "n" || guess == "o" || guess == "p" || guess == "q";
                if (check == false)
                {
                    Console.WriteLine("You did not enter the correct input value");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else if (check == true)
                {
                bet:                                       
                    
                    Console.WriteLine("Enter an amount to bet");
                    bet = Convert.ToInt32(Console.ReadLine());
                    //verifies the bet
                    if (bet > money)
                    {
                        Console.WriteLine("You dont have enough money!");
                        Console.WriteLine("Press enter to try again.");
                        Console.ReadKey();
                        goto bet;
                    }
                    else if (bet <= money)
                    {
                        money -= bet;
                        int roll = ran.Next(0, 37);
                        string ranColor = colors[r.Next(colors.Length)];
                        bool even = roll % 2 == 0;
                        if ((((guess == "a") && (even == true))) || (((guess == "b") && (even == false))) || ((guess == "e") && (ranColor == "Red") || (guess == "f") && (ranColor == "Black")))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");
                            cash.Load();
                            cash.Play();
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 2;
                            attempts++;
                            Console.ReadKey();
                        }
                        else if ((guess == "c") && ((roll > 0) && (roll < 19)))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");
                            cash.Load();
                            cash.Play();
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 2;
                            attempts++;
                            Console.ReadKey();
                        }
                        else if ((guess == "d") && ((roll > 18) && (roll < 37)))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");
                            cash.Load();
                            cash.Play();
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 2;
                            attempts++;
                            Console.ReadKey();
                        }
                        else if ((guess == "g") && (roll > 0 && roll < 13) || (guess == "h") && (roll > 12 && roll < 25) || (guess == "i") && (roll > 24 && roll < 37))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");
                            cash.Load();
                            cash.Play();
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 3;
                            attempts++;
                            Console.ReadKey();
                        }
                        else if (guess == "j" && (Array.IndexOf(columns1, roll) >= 0)) 
                        {
                            
                                Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                                Console.WriteLine("You won! +$" + bet * 2 + "!");
                                System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");
                                cash.Load();
                                cash.Play();
                                Console.WriteLine("<Press enter to continue>");
                                money += bet * 3;
                                attempts++;
                                Console.ReadKey();
                        }
                        else if (guess == "k" && (Array.IndexOf(columns2, roll) >= 0))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");

                            cash.Load();
                            cash.Play();
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 3;
                            attempts++;
                            Console.ReadKey();
                        }
                        else if (guess == "l" && (Array.IndexOf(columns3, roll) >= 0))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");
                            cash.Load();
                            cash.Play();
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 3;
                            attempts++;
                            Console.ReadKey();
                        }
                        //else if (guess == "m" && (Array.IndexOf(street1, roll) >= 0))
                        //{

                        //    Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                        //    Console.WriteLine("You won! +$" + bet * 2 + "!");
                        //    System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");
                        //    cash.Load();
                        //    cash.Play();
                        //    Console.WriteLine("<Press enter to continue>");
                        //    money += bet * 5;
                        //    attempts++;
                        //    Console.ReadKey();
                        //}
                        else if (guess == "m")
                        {
                            
                                Console.WriteLine("Choose your street: ");
                                Console.WriteLine("Street 1: 1-3, Street 2: 4-6, Street 3: 7-9, Street 4: 10-12, Street 5: 13-15, Street 6: 16-18, Street 7: 19-21, Street 8: 22-24, Street 9: 25-27, Street 10: 28-30");
                                Console.WriteLine("Street 11: 31-33, Street 12: 34-36");
                                streetGuess = (Console.ReadLine());
                                streetGuess.ToLower();
                                //guess2.Trim();
                                bool check2 = streetGuess == "street1" || streetGuess == "2" || streetGuess == "3" || streetGuess == "4" || streetGuess == "5" || streetGuess == "6" || streetGuess == "7" || streetGuess == "8" || streetGuess == "9" || streetGuess == "10" || streetGuess == "11" || streetGuess == "12";
                                switch(check2 == true)
                            {
                                case 1
                            }
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            /* if (check2 == false)
                                {
                                    Console.WriteLine("You did not enter the correct input value");
                                    Console.ReadKey();
                                    Console.Clear();
                                    continue;

                                }
                                if (check2 == true && guess2 == "street1" && (Array.IndexOf(streets, roll) <= 2))
                                {
                                    Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                                    Console.WriteLine("You won! +$" + bet * 2 + "!");
                                    SoundPlayer soundPlayer = new System.Media.SoundPlayer(@"cash.wav");
                                    System.Media.SoundPlayer cash1 = soundPlayer;
                                    cash1.Load();
                                    cash1.Play();
                                    Console.WriteLine("<Press enter to continue>");
                                    money += bet * 3;
                                    attempts++;
                                    Console.ReadKey();
                                continue;
                                       //return LosingMethod();
                                }
                              //  else*/




                            

                          /*  Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            System.Media.SoundPlayer cash = new System.Media.SoundPlayer(@"cash.wav");
                            cash.Load();
                            cash.Play();
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 5;
                            attempts++;
                            Console.ReadKey(); */
                        }
                        else
                        {
                                Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                                Console.WriteLine("You lost! -$" + bet + "!");

                            //morty voice
                           System.Media.SoundPlayer morty = new System.Media.SoundPlayer(@"morty.wav.wav");
                            morty.Load();
                            morty.Play();
                            //player.Play();
                            // var myPlayer = new System.Media.SoundPlayer();
                            // myPlayer.SoundLocation = @"C:\Users\willc\Downloads\morty.wav"; C:\Users\willc\MSSA2021\ISTA322\Exercises\Ex7Roulette\bin\Debug\netcoreapp3.1\morty.wav
                            // myPlayer.PlaySync();
                            Console.WriteLine("<Press enter to continue>");
                                attempts++;
                                Console.ReadKey();
                                if (money == 0)
                                {
                                    Console.WriteLine("You are out of money.");
                                    Console.WriteLine("<Press enter to continue>");
                                    Console.ReadKey();
                                
                                }
                        }
                            
                    }
                        
                }
            }
                Console.Clear();
        }
    }
    
}
