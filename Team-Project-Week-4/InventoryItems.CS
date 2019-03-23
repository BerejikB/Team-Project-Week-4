using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    public class NoItems : Exception { }
    public class NoMoney : Exception { }
    public class PlanetBroke : Exception { }
    public class PlayerBoughtItem : Exception { }
    public class PlanetNoItems : Exception { }
    public class Item
    {
        public string name;
        public double price;
        public int volume;
        public int Playerquantity;
        public int Planetquantity;
        public Item()
         {}
        public double PlanetMoney;
        

        public Item(string name, double price, int volume, int Playerquantity, int Planetquantity)
        {
            this.name = name;
            this.price = price;
            this.volume = volume;
            this.Playerquantity = Playerquantity;
            this.Planetquantity = Planetquantity;
            this.PlanetMoney = PlanetMoney;

        }
    }

   public class InventoryItems
    {
        public static readonly Item Beer = new Item()
        {
            name = "Beer",
            price = 100,
            volume = 1,
            Playerquantity = 0,
            Planetquantity = 0,
        };
        public static readonly Item Goat = new Item()
        {
            name = "Goat",
            price = 400,
            volume = 2,
            Playerquantity = 0,
            Planetquantity = 0,
        };
        public static readonly Item Gold = new Item()
        {
            name = "Gold",
            price = 5000,
            volume = 5,
            Playerquantity = 0,
            Planetquantity = 0,
        };
        public static readonly Item SandWiches = new Item()
        {
            name = "Sandwiches",
            price = 80,
            volume = 1,
            Planetquantity = 0,
            Playerquantity = 0,

        };
        public static readonly Item Water = new Item()
        {
            name = "Water",
            price = 30,
            volume = 1,
            Playerquantity = 0,
            Planetquantity = 0,
        };
        public static readonly Item ConsumerElectronics = new Item() 
        {
            name = "ConsumerElectronics",
            price = 10000,
            volume = 50,
            Playerquantity = 0,

        };
        public static readonly Item IndustrialComponents = new Item()
        {
             name = "IndustrialComponents",
            price = 50000,
            volume = 200,
            Playerquantity = 0,
            Planetquantity = 0,

        };
        public static readonly Item RawIron = new Item()
        {
            name = "Raw Iron",
               price = 6000,
             volume = 500,
            Playerquantity = 0,
            Planetquantity = 0,

        };
        public static readonly Item NuclearMaterial = new Item()
        {
            name = "NuclearMaterial",
                price = 12000,
            volume = 500,
            Playerquantity = 0,
            Planetquantity = 0,

        };
        public static readonly Item HazardousWaste = new Item()
        {
            name = "Hazardous Waste",
            price = 37,
            volume = 2,
            Playerquantity = 0,
            Planetquantity = 0,
        };    
    }

    public class Market
    {
        public int GlobalPlanetIndex;
               
        string localeconomy;
        double localvalueMultiplier;

        public Random Rando = new Random();
        public int r = 0;
        public int numSold = 0;
        public List<Item> allItemsSold = new List<Item>() { InventoryItems.Beer, InventoryItems.Goat, InventoryItems.Gold, InventoryItems.SandWiches, InventoryItems.Water, InventoryItems.ConsumerElectronics, InventoryItems.IndustrialComponents, InventoryItems.RawIron, InventoryItems.NuclearMaterial, InventoryItems.HazardousWaste };
        public List<Item> PlayerInventory = new List<Item>() { InventoryItems.Beer, InventoryItems.Goat, InventoryItems.Gold, InventoryItems.SandWiches, InventoryItems.Water, InventoryItems.ConsumerElectronics, InventoryItems.IndustrialComponents, InventoryItems.RawIron, InventoryItems.NuclearMaterial, InventoryItems.HazardousWaste };
        public  bool PlayerBought = false;
        public void PrintItemsSold()
        {
            Console.WriteLine("Your Inventory:");
            foreach (var item in PlayerInventory)
            {
                
                Console.WriteLine($"{item.name}: {item.Playerquantity}");
            }

        }


        public void GenerateItemsSold()
        {
            for (int x = 9; x >= 0; x--)
            {
                int itemno = Rando.Next(0, 30);
                int planetmoney = Rando.Next(0, 3719);
                allItemsSold[0].PlanetMoney = planetmoney;
                allItemsSold[x].Planetquantity = itemno;
                Console.WriteLine(allItemsSold[x].name);
            }

        }




        public void PlanetMarket(double valueMultiplier, string economy)
        {
            localeconomy = economy;
            localvalueMultiplier = valueMultiplier;
            GenerateItemsSold();
            
        }
        public void AddLootBox(int randoItem, int randoItemNo)

        {
            for (int i = 0; i < randoItemNo; i++)
            {

                PlayerInventory[randoItem].Playerquantity ++ ;
            }


        }
        public void SelectItem(Player boi )
        {
           
            double playerspeechmult = boi.playerSpeech;
            playerspeechmult *= .02;
            Console.Clear();
            PrintItemsSold();
            Console.WriteLine();
            Console.WriteLine($"Current Wallet   ${ boi.playerMoney} You have {PlayerInventory[r].Playerquantity} {PlayerInventory[r].name} ");
            Console.WriteLine($"Your Speech skill will give a {playerspeechmult}% bonus.");
            Console.WriteLine($"The Planet's Economy is {localeconomy} ");
            Console.WriteLine($"Planet has ${allItemsSold[0].PlanetMoney}. Planet has {allItemsSold[r].Planetquantity} {allItemsSold[r].name}s which sells for ${allItemsSold[r].price * localvalueMultiplier}");
            Console.WriteLine("Press Right arrow to buy, press Left arrow to Sell, press Up and Down arrow to select");
            Console.WriteLine($"{allItemsSold[r].name} Selected");
            ConsoleKeyInfo userinputboi;
            userinputboi = Console.ReadKey(true);

            try
            {

            switch (userinputboi.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        Console.WriteLine($"{allItemsSold[r].name} Selected");
                        r--;
                        SelectItem(boi);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        r++;
                        SelectItem(boi);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {

                        BuyItem(boi);
                        //SelectItem(boi);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        SellItem(boi);
                       // SelectItem(boi);
                    }
                    break;

                }

            }

            catch (Exception) { r = 0; SelectItem(boi); }
          

        }

        public void BuyItem(Player boi)
        {
            try
            {
                PlayerBought = true;
                if (boi.playerMoney <= allItemsSold[r].price)
                { throw new NoMoney { }; }
                if (allItemsSold[r].Planetquantity <= 0)
                { throw new PlanetNoItems { }; }

                double itemprice = allItemsSold[r].price;
                double playerspch = boi.playerSpeech;
                double playermult = playerspch *= .02;
                double addin = playermult *= itemprice;
                double finalprice = itemprice -= addin;
                finalprice *= localvalueMultiplier;
                PlayerInventory[r].Playerquantity++;
                allItemsSold[r].Planetquantity--;
                boi.playerMoney -= finalprice;
                allItemsSold[0].PlanetMoney += finalprice;

                Console.WriteLine($"{numSold} {allItemsSold[r].name} Bought");
                numSold = 0;
                SelectItem(boi);


            }
            catch (PlanetNoItems)
            {
                
                allItemsSold[r].Planetquantity = 0;
                //boi.playerMoney += allItemsSold[r].price;
                SelectItem(boi);
            }
            catch (NoMoney)
            {
                //PlayerInventory[r].Playerquantity--;
                //allItemsSold[r].Planetquantity++;
                //boi.playerMoney = 0;
                SelectItem(boi);
            }

        }

        public void SellItem(Player boi)
        {
            try
            {
                if (PlayerBought == true)
                { throw new PlayerBoughtItem { }; }
                if (PlayerInventory[r].Playerquantity <= 0)
                { throw new NoItems { }; }
                if (allItemsSold[0].PlanetMoney <= allItemsSold[r].price)
                { throw new PlanetBroke { }; }

                double itemprice = allItemsSold[r].price;
                double playerspch = boi.playerSpeech;
                double playermult = playerspch *= .02;
                double addin = playermult *= itemprice;
                double finalprice = itemprice += addin;
                finalprice *= localvalueMultiplier;
                boi.playerMoney += finalprice;
                PlayerInventory[r].Playerquantity--;
                allItemsSold[r].Planetquantity++;
                allItemsSold[0].PlanetMoney -= finalprice;
                Console.WriteLine($"{numSold}{allItemsSold[r].name} Sold");
                numSold = 0;
                SelectItem(boi);


            }
            catch (PlanetBroke)
            {

                SelectItem(boi);


            }
            catch (NoItems)
            {
                PlayerInventory[r].Playerquantity = 0;
                //allItemsSold[r].Planetquantity--;
                //boi.playerMoney -= allItemsSold[r].price;
                SelectItem(boi);
            }
            catch (PlayerBoughtItem)
            {
                Console.WriteLine("A Planet will not buy back items it just sold to you.");
                Console.ReadKey();
                SelectItem(boi);
            }
            
           
        }

       

    }
}
