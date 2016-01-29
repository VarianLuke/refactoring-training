using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    public class Tusc
    {
        private List<User> _userList;
        private List<Product> _productList;
        private User _currentUser;
        private bool _isDisplayingProductList = false;

        private const int MENU_CHOICE_EXIT = 7;

        public Tusc(List<User> userList, List<Product> productList)
        {
            _userList = userList;
            _productList = productList;
        }

        public void Start()
        {
            if (_userList == null || _productList == null)
            {
                throw new Exception("Application not started correctly.");
            }

            UserInterface.DisplayTuscWelcomeMessage();

            var loggedIn = BeginUserLogin();

            

            UserInterface.DisplayUserWelcomeMessage(_currentUser);

            UserInterface.DisplayUserBalance(_currentUser);

            ShowProductList();

            UserInterface.WaitForUserInputBeforeClosing();
        }

        private bool BeginUserLogin()
        {
            // Login
            Login:

            string enteredUserName = UserInterface.PromptForUserName();

            if (string.IsNullOrEmpty(enteredUserName))
            {
                goto Login;
            }

            // Validate Username
            var isUserNameValid = IsUserInList(enteredUserName);

            if (!isUserNameValid)
            {
                UserInterface.DisplayInvalidUserMessage();

                goto Login;
            }

            _currentUser = GetUserFromList(enteredUserName);

            string password = UserInterface.PromptForPassword();

            var isPasswordValid = ValidatePassword(password);

            if (!isPasswordValid)
            {
                UserInterface.DisplayInvalidPasswordMessage();

                goto Login;
            }

            return true;
        }

        private void ShowProductList()
        {
            _isDisplayingProductList = true;

            // Show product list
            while (_isDisplayingProductList)
            {
                // Prompt for user input
                Console.WriteLine();
                Console.WriteLine("What would you like to buy?");
                for (int i = 0; i < 7; i++)
                {
                    Product prod = _productList[i];
                    Console.WriteLine(i + 1 + ": " + prod.Name + " (" + prod.Price.ToString("C") + ")");
                }
                Console.WriteLine(_productList.Count + 1 + ": Exit");

                // Prompt for user input
                var menuChoice = UserInterface.PromptForNumber("Enter a number:");
                menuChoice = menuChoice - 1;

                // Check if user entered number that equals product count
                if (menuChoice == MENU_CHOICE_EXIT)
                {
                    SaveModifications();
                    _isDisplayingProductList = false;
                }
                else
                {
                    var product = _productList[menuChoice];

                    UserInterface.DisplayPurchaseChoiceInfo(_currentUser, product);

                    // Prompt for user input
                    Console.WriteLine();
                    int selectedQuantity = UserInterface.PromptForNumber("Enter amount to purchase:");

                    var totalPrice = product.GetPrice(selectedQuantity);

                    if (!_currentUser.HasEnoughMoney(totalPrice))
                    {
                        UserInterface.DisplayUserInsufficientFundsMessage();
                        continue;
                    }

                    // Check if quantity is less than quantity
                    if (!product.HasEnoughInventory(selectedQuantity))
                    {
                        UserInterface.DisplayUserInsufficientQuantityMessage(product);
                        continue;
                    }

                    // Check if quantity is greater than zero
                    if (selectedQuantity > 0)
                    {
                        _currentUser.Balance -= totalPrice;

                        product.Quantity -= selectedQuantity;

                        UserInterface.DisplayUserPurchase(_currentUser, product, selectedQuantity);
                    }
                    else
                    {
                        UserInterface.DisplayQuantityLessThanZeroMessage();
                    }
                }
            }
        }

        

        private void SaveModifications()
        {
            FileManager.SaveJsonFile(@"Data/Users.json", _userList);
            FileManager.SaveJsonFile(@"Data/Products.json", _productList);
        }

        private bool IsUserInList(string enteredUserName)
        {
            var userFound = _userList.FirstOrDefault(u => u.Name == enteredUserName);

            return (userFound != null);
        }
        
        private User GetUserFromList(string enteredUserName)
        {
            return _userList.FirstOrDefault(u => u.Name == enteredUserName);
        }

        private bool ValidatePassword(string password)
        {
            if (_currentUser == null)
            {
                return false;
            }

            return (password == _currentUser.Password);
        }
    }
}