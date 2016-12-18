using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ravengard_console
{
    class Ui
    {
        public int ReadKey { get; set; }
        public string Result { get; set; }
        internal void GetWelcomeScreen()
        {
            Console.WriteLine("Welcome To Ravengaard Ring Design system!");
            Console.WriteLine("What do you want to design to day?");
        }

        internal string GetProductList()
        {
            Query SQL = new Query();
            SQL.QueryMethod("ProductType_Name,ProductType_ID", "ProductType");
            Console.WriteLine("Select what kind of product you want to design: ");
            return Console.ReadLine();
        }

        internal void LoginScreen()
        {
            Console.WriteLine("New to Ravengaard or regular customer?");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create Account");
            Console.WriteLine("9. Exit");
        }

        internal void GoodByeMessage()
        {
            Console.Clear();
            Console.WriteLine("Thanks for using the ravengaard system! See you next time.");
            Console.ReadKey();
        }

        internal void InvalidOptionError()
        {
            Console.WriteLine("Option invalid, please choose a correct option");
        }

        internal void ChooseOptionMessage()
        {
            Console.Write("Please choose an option:");
        }

        internal void RingDesignOptions()
        {
            Console.WriteLine("What do you want to design first?");
            Console.WriteLine("1. Rock Type");
            Console.WriteLine("2. Rock Holder");
            Console.WriteLine("3. Ring Type");
            Console.WriteLine("4. Check Cart");
            Console.WriteLine("5. Go To Checkout");
        }

        internal void NecklaceDesignOptions()
        {
            Console.WriteLine("What do you want to design first?");
            Console.WriteLine("1. Necklace Chain");
            Console.WriteLine("2. Necklace Pendant");
            Console.WriteLine("3. Necklace Color");
            Console.WriteLine("4. Check Cart");
            Console.WriteLine("5. Go To Checkout");
        }

        internal void ShowSelectionProductMenu(int key)
        {
            switch (key)
            {

                case 1:
                    {
                        RingDesignOptions();
                        string ReadKey = Console.ReadLine();
                        BuildQuery selectedRock = new BuildQuery();
                        selectedRock.getRockInfo(int.Parse(ReadKey));

                        break;
                    }
                case 2:
                    {
                        NecklaceDesignOptions();
                        string ReadKey = Console.ReadLine();
                        break;
                    }
                case 3:
                    break;

            }
        }

        internal void CheckLoginOrCreate(int ReadKey)
        {

            Query SQL = new Query();
            switch (ReadKey)
            {
                case 1:
                    {
                        Console.WriteLine("Username/Email: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();
                        SQL.LogUserIn(username, password);

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Hi, now fill out the information required to account");
                        Console.WriteLine("Note! Your username will be your email address!");
                        Console.WriteLine("Firstname: ");
                        string createName = Console.ReadLine();
                        Console.WriteLine("Lastname: ");
                        string createLastName = Console.ReadLine();
                        Console.WriteLine("Phone Number: ");
                        string createPhoneNR = Console.ReadLine();
                        Console.WriteLine("Address: ");
                        string createAddress = Console.ReadLine();
                        Console.WriteLine("Email: ");
                        string createUsername = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string createPassword = Console.ReadLine();
                        //byte[] createPassword = Encoding.UTF8.GetBytes(Console.ReadLine());
                        if (createPassword.Length >= 8 && Regex.IsMatch(createPassword, @"^[a-zA-Z0-9_]+$"))
                        {
                            SQL.CreateUser(createName, createLastName, createPhoneNR, createAddress, createUsername, createPassword);
                            CheckLoginOrCreate(1);
                        }
                        else
                        {
                            Console.WriteLine("Password does not match criteria, needs to be at least 8 carachters long and it has to contain numbers!");
                            Console.WriteLine("Lets try this again");
                            CheckLoginOrCreate(2);
                        }


                        break;
                    }

            }
        }


    }
}
