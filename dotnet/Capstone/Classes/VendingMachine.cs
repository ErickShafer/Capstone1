using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        //"Global" Variables
        static string path = @"C:\";
        static string fullpath = Path.GetFullPath(Path.Combine(path, @"..\..\"));
        decimal Bank = 0m;
        public decimal Wallet = 0m;
        public decimal dollarValue = 0m;
        public decimal quarterValue = 0m;
        public decimal dimeValue = 0m;
        public decimal nickelValue = 0m;


        Dictionary<string, Slot> Inventory = new Dictionary<string, Slot>();
        string errorMessege = "Your Input Is Invalid";
        
        /// <summary>
        /// returns error messege
        /// </summary>
        public void Error()
        {
            Console.WriteLine(errorMessege);
        }
        public void Start()
        {
            //StreamReader to update vendingmachine parameters
            using (StreamReader sr = new StreamReader(@"C:\Users\erickshafer\workspaces\week-4-pair-exercises-c-team-5\19_Capstone\dotnet\etc\VendingMachine.txt"))
            {

                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine().Replace("|", ", ");
                    string[] product = line.Split(", ");
                    //write dictionary values
                    if (product[3] == "Gum")
                    {

                        Item foodProduct = new Gum(product[1], decimal.Parse(product[2]));
                        Slot foodSlot = new Slot(foodProduct, 5);
                        Inventory.Add(product[0], foodSlot);
                    }
                    else if (product[3] == "Chip")
                    {
                        Item foodProduct = new Chip(product[1], decimal.Parse(product[2]));
                        Slot foodSlot = new Slot(foodProduct, 5);
                        Inventory.Add(product[0], foodSlot);
                    }
                    else if (product[3] == "Drink")
                    {
                        Item foodProduct = new Drink(product[1], decimal.Parse(product[2]));
                        Slot foodSlot = new Slot(foodProduct, 5);
                        Inventory.Add(product[0], foodSlot);
                    }
                    else if (product[3] == "Candy")
                    {
                        Item foodProduct = new Candy(product[1], decimal.Parse(product[2]));
                        Slot foodSlot = new Slot(foodProduct, 5);
                        Inventory.Add(product[0], foodSlot);
                    }
                }
            }
        }
        //Prints list of items by slot, in order
        public void Display()
        {

            string header =
            "Slot".PadRight(6) +
            "Name".PadRight(21) +
            "Price".PadRight(8) +
            "Inventory".PadRight(10);
            Console.Write(header);
            Console.WriteLine();
            foreach (var item in Inventory)
            {
                string display =
                $"{item.Key.PadRight(6)}" +
                $"{item.Value.Item.Name.PadRight(21)}" +
                $"{item.Value.Item.Price.ToString().PadRight(8)}" +
                $"{item.Value.DisplayCount.ToString().PadRight(10)}";
                Console.WriteLine(display);
            }
            Console.ReadKey();
        }
        //Updates Wallet, measure of customer money input
        public void Feed(string moneyEntered)
        {
            if (moneyEntered == "1")
            {
                Wallet += 1;
            }
            else if (moneyEntered == "2")
            {
                Wallet += 5;
            }
            else if (moneyEntered == "3")
            {
                Wallet += 10;
            }
            else
            {
                Error();
            }
        }
        //Updates wallet, item count.
        public void Purchase(string itemSelect)
        {

            try
            {

                Console.WriteLine($"Your Item Costs {Inventory[itemSelect].Item.Price}");
                if ((Wallet >= Inventory[itemSelect].Item.Price) &&
                    (Inventory[itemSelect].Count > 0))
                {
                    Console.WriteLine($"{Inventory[itemSelect].Item.GetSound()}");
                    Wallet -= Inventory[itemSelect].Item.Price;
                    Inventory[itemSelect].Count--;
                    PurchaseLog();
                }
                else
                {
                    if (Wallet < Inventory[itemSelect].Item.Price)
                    {
                        throw new PriceRangeException();
                    }
                }

            }
            catch (Exception e)
            {
                Error();
            }



        }
        public void EndTransaction()
        {

            //Counts out change in smallest return values possible

            //empty Wallet



            while (Wallet > 0)
            {
                if (Wallet >= 1)
                {
                    Wallet = Wallet - 1.0M;
                    dollarValue++;
                }
                else if (Wallet >= 0.25M)
                {
                    Wallet -= 0.25M;
                    quarterValue++;
                }
                else if (Wallet >= 0.10M)
                {
                    Wallet -= 0.10M;
                    dimeValue++;
                }
                else if (Wallet >= 0.05M)
                {
                    Wallet -= 0.05M;
                    nickelValue++;
                }
                else
                {

                }
            }

            ChangeLog();
        }
        public void SalesReport()
        {
            decimal oldSalesAmount = 0.0M;
            List<int> oldItemCounts = new List<int>();
            using (StreamReader sr = new StreamReader(fullpath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if ((!line.Equals("")) && line.Contains("|"))
                    {
                        string[] lineAr = line.Split("|");
                        oldItemCounts.Add(int.Parse(lineAr[lineAr.Length - 1]));
                    }
                    else if ((!line.Equals("")) && line.Contains("Total transaction value is "))
                    {
                        string[] lineAr = line.Split(" ");
                        oldSalesAmount = decimal.Parse(lineAr[lineAr.Length - 1]);
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(fullpath, false))
            {
                for (int i = 0; i < productData.Count; i++)
                {
                    sw.WriteLine($"{productData[i].Substring(3, productData[i].Length - 7)}|{(5 - Inventory[productData[i].Substring(0, 2)].Count) + oldItemCounts[i]}");
                }

                sw.WriteLine();
                sw.WriteLine("Total transaction value is " + (oldSalesAmount + VMBank.Sales));
            }
        }
        public void FeedMoneyLog()
        {

            using (StreamWriter sw = new StreamWriter(fullpath, true))
            {
                sw.WriteLine($"{File.GetCreationTime(fullpath)} FEED MONEY: ${enteredAmount} ${tempWallet.Value} ");
            }

        }
        public void PurchaseLog()
        {
            using (StreamWriter sw = new StreamWriter(fullpath, true))
            {
                sw.WriteLine($"{File.GetCreationTime(fullpath)} {itemChosen} {Inventory[itemChosen].Item.Name} ${enteredAmount} ${enteredAmount - Inventory[itemChosen].Item.Price}");
            }
        }
        public void ChangeLog()
        {
            using (StreamWriter sw = new StreamWriter(fullpath, true))
            {
                sw.WriteLine($"{File.GetCreationTime(fullpath)} GIVE CHANGE ${enteredAmount - Inventory[itemChosen].Item.Price} ${tempWallet.Value}");
            }
        }
    }

}


