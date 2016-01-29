using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Refactoring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load users from data file
            List<User> users = FileManager.LoadJsonFile<User>(@"Data/Users.json");

            // Load products from data file
            List<Product> products = FileManager.LoadJsonFile<Product>(@"Data/Products.json");

            var tusc = new Tusc(users, products);
            tusc.Start();
        }
    }
}
