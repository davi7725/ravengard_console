using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ravengard_console
{
    class Program
    {

        Ui print = new Ui();
        Query Sql = new Query();
        bool isLoggedIn = false;
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            StartMenu();
        }

        private void StartMenu()
        {
            bool isMenuRunning = true;
            string option = "";

            do
            {
                Console.Clear();
                print.LoginScreen();
                option = ChooseOption();

                switch (option)
                {
                    case "1":
                        DoLogin();
                        break;
                    case "2":
                        RegisterAccount();
                        break;
                    case "9":
                        print.GoodByeMessage();
                        isMenuRunning = false;
                        break;
                    default:
                        print.InvalidOptionError();
                        Console.ReadKey();
                        break;
                }

            } while (isMenuRunning == true);
        }

        private string ChooseOption()
        {
            print.ChooseOptionMessage();
            return Console.ReadLine().Trim();
        }

        private void DoLogin()
        {
            while (isLoggedIn == false)
            {
                Console.Clear();
                Console.WriteLine("Username/Email: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                isLoggedIn = Sql.LogUserIn(username, password);
            }

            Console.Clear();
            ShowWelcomeScreenWithProductList();
            

        }

        private void ShowWelcomeScreenWithProductList()
        {
            print.GetWelcomeScreen();
            string type = print.GetProductList();
            ShowDesignOptionsDependingOnType(type);
        }

        private void ShowDesignOptionsDependingOnType(string type)
        {
            switch (type)
            {
                case "1":
                    print.RingDesignOptions();

                    string option = ChooseOption();
                    BuildQuery selectedRock = new BuildQuery();
                    selectedRock.getRockInfo(int.Parse(type));
                    break;
                case "2":
                    print.NecklaceDesignOptions();
                    break;
                default:
                    print.InvalidOptionError();
                    break;
            }
        }

        private void RegisterAccount()
        {
            throw new NotImplementedException();
        }
    }
}
