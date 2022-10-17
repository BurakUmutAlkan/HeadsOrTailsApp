using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HeadsOrTailsApp.Data.Enums;

namespace HeadsOrTailsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            bool isRight = false;
            Coin flippedCoin;
            Coin userCoin;
            Random random = new Random();

            while (true)
            {
                flippedCoin = FlipCoin(random);

                Console.Write("Heads or Tails? (H/T): ");

                try
                {
                    input = Console.ReadLine().Trim().ToUpper();
                }
                catch
                {
                    OutputErrorMessage();
                }

                userCoin = ConvertStringToCoin(input);
                isRight = CompareCoins(flippedCoin, userCoin);

                if (!isRight)
                {
                    Console.WriteLine("You guessed wrong. Please try again.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Congrats! You guessed right.");
                    Console.ReadKey();
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }

        #region Methods

        private static void OutputErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter your guess as stated above. Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static Coin FlipCoin(Random random)
        {
            int randomNumber = random.Next(0, 2);

            if (randomNumber == 0)
                return Coin.Heads;
            else
                return Coin.Tails;
        }

        private static Coin ConvertStringToCoin(string input)
        {
            if (input == "H")
                return Coin.Heads;
            else
                return Coin.Tails;
        }

        private static bool CompareCoins(Coin flippedCoin, Coin userCoin)
        {
            if (userCoin == flippedCoin)
                return true;
            else
                return false;
        }

        #endregion
    }
}
