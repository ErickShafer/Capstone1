using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        
        VendingMachine test = new VendingMachine();
        
       
        [TestMethod]
        public void TestingDictionary()
        {
        test.Start();
        //Assert.AreEqual(3.05, Inventory[0].Item.Price, "The Inventory does not contain the correct price for A1");
        //Assert.AreEqual(5, Inventory[3].Count, "The Inventory does not have the correct count.");
        }
    [TestMethod]
        public void Testingsound()
        {
            Item testCandy = new Candy("dumdum", 0.05m);
            Item testGum = new Gum("gumgum", 0.05m);
            Item testDrink = new Drink("pepsi", 0.05m);
            Item testChip = new Chip("walkers", 0.05m);
            
            Assert.AreEqual("Munch munch, yum!", testCandy.GetSound());
            Assert.AreEqual("Crunch crunch, yum!", testChip.GetSound());
            Assert.AreEqual("Glug glug, yum!", testDrink.GetSound());
            Assert.AreEqual("Chew chew, yum!", testGum.GetSound());
        }
        [TestMethod]
        public void TestWallet()
        {
            //assert wallet updates with imput
            //test.Purchase();
            //assert wallet will not accept negative numbers, or strings, or numbers with too many sig-figs.
        }
        [TestMethod]
        public void TestingChange()
        {
            //Assert Wallet Values after the EndTransaction Method is 0
            test.EndTransaction();
            Assert.AreEqual(0, test.WalletValue, "Endtransaction is not emptying the wallet.");
        }
        [TestMethod]
        public void TestPurchase()
        {
            //assert purchase removes the price from the wallet
            //assert purchase removes one from item count
            //assert purcase will not purchase an item that has no count
            //assert purchase will not allow purchase without enough money
        }

    }
}
