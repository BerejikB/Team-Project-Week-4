using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    public class Item
    {
        public string name;
        public int price;
        public int volume;

        public Item()
        {}

        public Item(string name, int price, int volume)
        {
            this.name = name;
            this.price = price;
            this.volume = volume;
        }
    }

   public static class InventoryItems
    {
        public static readonly Item Beer = new Item()
        {
            name = "Beer",
            price = 100,
            volume = 1
        };
        public static readonly Item Goat = new Item()
        {
            name = "Goat",
            price = 400,
            volume = 2,

        };
        public static readonly Item Gold = new Item()
        {
            name = "Gold",
            price = 5000,
            volume = 5,

        };
        public static readonly Item SandWiches = new Item()
        {
            name = "Sandwiches",
            price = 80,
            volume = 1,

        };
        public static readonly Item Water = new Item()
        {
            name = "Water",
            price = 30,
            volume = 1,
            
        };
        public static readonly Item ConsumerElectronics = new Item() 
        {
             name = "ConsumerElectronics",
                price = 10000,
            volume = 50,
            
        };
        public static readonly Item IndustrialComponents = new Item()
        {
             name = "IndustrialComponents",
               price = 50000,
            volume = 200,
            
        };
        public static readonly Item RawIron = new Item()
        {
            name = "Raw Iron",
               price = 6000,
             volume = 500,
            
        };
        public static readonly Item NuclearMaterial = new Item()
        {
            name = "NuclearMaterial",
                price = 12000,
            volume = 500,
           
        };
        public static readonly Item HazardousWaste = new Item()
        {
            name = "Hazardous Waste",
            price = 37,
            volume = 2,
        };    
    }

    public class Market
    {
        public int i = 0;
        public int numSold = 0;
        List<Item> allItemsSold = new List<Item>() { InventoryItems.Beer, InventoryItems.Goat, InventoryItems.Gold, InventoryItems.SandWiches, InventoryItems.Water, InventoryItems.ConsumerElectronics, InventoryItems.IndustrialComponents, InventoryItems.RawIron, InventoryItems.NuclearMaterial, InventoryItems.HazardousWaste };
        List<Item> PlayerInventory = new List<Item>();

        public void PrintItemsSold()
        {
            foreach (var item in allItemsSold)
            {
                Console.WriteLine(item.name);

            }
           
        }

        public void SelectItem(Player boi)
        {
            Console.Clear();
            PrintItemsSold();
            Console.WriteLine();
            Console.WriteLine($"Current Wallet{ boi.playerMoney}");
            Console.WriteLine("Press Right arrow to buy, press Left arrow to Sell, press Up and Down arrow to select");
            Console.WriteLine($"{allItemsSold[i].name} Selected");
            ConsoleKeyInfo userinputboi;
            userinputboi = Console.ReadKey(true);

            try
            {

            switch (userinputboi.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        Console.WriteLine($"{allItemsSold[i].name} Selected");
                        i--;
                        SelectItem(boi);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        i++;
                        SelectItem(boi);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        BuyItem(boi);
                        SelectItem(boi);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        SellItem(boi);
                        SelectItem(boi);
                    }
                    break;

                }

            }

            catch (Exception) { i = 0; SelectItem(boi); }
          

        }

        public void BuyItem(Player boi)
        {
            boi.playerMoney -= allItemsSold[i].price;
            PlayerInventory.Add(allItemsSold[i]);
            Console.WriteLine($"{numSold} {allItemsSold[i].name} Bought");
            numSold = 0;
        }

        public void SellItem(Player boi)
        {
            boi.playerMoney += allItemsSold[i].price;
            PlayerInventory.Remove(allItemsSold[i]);
            Console.WriteLine($"{numSold}{allItemsSold[i].name} Sold");
            numSold = 0;
        }

    }
}
