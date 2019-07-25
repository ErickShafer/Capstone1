using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachineUI
    {
        public void Menu()
        {
            VendingMachine test = new VendingMachine();
            test.Start();
            bool main = true;
            bool purchase = true;
            
            //introduction
            Console.WriteLine("Welcome to the Vendo-Matic 600 (By Umbrella Corp.)");
            //options
            Console.WriteLine();
            while (main)
            {
                Console.WriteLine("Main Menu - Please Select A Menu");
                Console.WriteLine();
                Console.WriteLine("1. Display Items");
                Console.WriteLine("2. Purchase Items");
                Console.WriteLine("3. Exit");
                
                string menuSelect = Console.ReadKey().ToString();
                switch (menuSelect)
                {
                    case "1":
                        test.Display();
                        break;
                    case "2":
                        {
                            while (purchase)
                            {
                                Console.WriteLine("Purchase Menu - Please Select A Menu");
                                Console.WriteLine("1. Feed Money");
                                Console.WriteLine("2. Select Product");
                                Console.WriteLine("3. Recieve Change And Exit");
                                string purchaseSelect = Console.ReadLine();
                                if (purchaseSelect == "1")
                                {
                                    Console.WriteLine("Please Insert An Amount");
                                    Console.WriteLine("1. $1.00");
                                    Console.WriteLine("2. $5.00");
                                    Console.WriteLine("3. $10.00");
                                    string moneyEntered = Console.ReadKey().ToString();
                                    test.Feed(moneyEntered);
                                    Console.WriteLine($"Your Total Amount Is {test.Wallet}");
                                }
                                else if (purchaseSelect == "2")
                                {
                                    test.Display();
                                    Console.WriteLine();
                                    Console.WriteLine($"Your Total Amount Is {test.Wallet}");
                                    Console.WriteLine("Please Select An Item, Or Press \"K\" to Return.");
                                    string itemSelect = Console.ReadLine().ToUpper();
                                    test.Purchase(itemSelect);
                                }
                                else
                                {
                                    test.EndTransaction();
                                    Console.WriteLine($"Dispensing {test.dollarValue} Dollars");
                                    Console.WriteLine($"Dispensing {test.quarterValue} Quarters");
                                    Console.WriteLine($"Dispensing {test.dimeValue} Dimes");
                                    Console.WriteLine($"Dispensing {test.nickelValue} Nickels");
                                    Console.WriteLine();
                                }
                            }
                        }
                        break;
                    case "3":
                            main = false;
                            break;
                    case "4":
                            test.SalesReport();
                            main = false;
                            break;
                    default:
                            throw new MenuSelectError();
                }
            }
            Console.WriteLine("Thank you for Using the Vendo-Matic 600 (By Umbrella Corp.) GoodBye");
            Console.ReadKey();
        }
    }
}