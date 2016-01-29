using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    internal static class UserInterface
    {
        internal static void DisplayTuscWelcomeMessage()
        {
            Console.WriteLine("Welcome to TUSC");
            Console.WriteLine("---------------");
        }

        internal static void DisplayUserWelcomeMessage(User user)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Login successful! Welcome " + user.Name + "!");
            Console.ResetColor();
        }

        internal static void DisplayInvalidPasswordMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("You entered an invalid password.");
            Console.ResetColor();
        }

        internal static void DisplayInvalidUserMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("You entered an invalid user.");
            Console.ResetColor();
        }

        internal static void DisplayUserBalance(User user)
        {
            // Show balance 
            Console.WriteLine();
            Console.WriteLine("Your balance is " + user.Balance.ToString("C"));
        }

        internal static void DisplayUserPurchase(User user, Product product, int quantity)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You bought " + quantity + " " + product.Name);
            Console.WriteLine("Your new balance is " + user.Balance.ToString("C"));
            Console.ResetColor();
        }

        internal static void DisplayQuantityLessThanZeroMessage()
        {
            // Quantity is less than zero
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Purchase cancelled");
            Console.ResetColor();
        }

        internal static void DisplayPurchaseChoiceInfo(User user, Product product)
        {
            Console.WriteLine();
            Console.WriteLine("You want to buy: " + product.Name);
            Console.WriteLine("Your balance is " + user.Balance.ToString("C"));
        }

        internal static void DisplayUserInsufficientQuantityMessage(Product product)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Sorry, " + product.Name + " is out of stock");
            Console.ResetColor();
        }

        internal static void DisplayUserInsufficientFundsMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("You do not have enough money to buy that.");
            Console.ResetColor();
        }

        internal static string PromptForUserName()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Username:");
            return Console.ReadLine();
        }

        internal static string PromptForPassword()
        {
            Console.WriteLine("Enter Password:");
            return Console.ReadLine();
        }

        internal static int PromptForNumber(string message)
        {
            Console.WriteLine(message);
            var enteredString = Console.ReadLine();
            return Convert.ToInt32(enteredString);
        }

        internal static void WaitForUserInputBeforeClosing()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter key to exit");
            Console.ReadLine();
        }
    }
}
