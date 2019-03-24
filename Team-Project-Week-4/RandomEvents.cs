using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    class RandomEvents
    {
        Player boi;
        Ship shipo;
        Market playerItems;
        public RandomEvents(Player Boi, Ship Shipo, Market PlayerItems)
        {
            this.boi = Boi;
            this.shipo = Shipo;
            this.playerItems = PlayerItems;
        }

       
        Random rnd = new Random();
        public void NumOfEvents()
        {
            
            int eventNum = rnd.Next(3, 5);

            do
            {
                eventNum--;
            }
            while (eventNum > 0);

        }

        public void EventType(Player boi, Ship Shipo, Market PlayerItems)
        {
            //switch statement for random selection of event
            int eventType = rnd.Next(1, 5);
            switch (eventType)
            {
                case 1:
                    {
                        LootBox(PlayerItems);
                        break;
                    }
                case 2:
                    {
                        Raid(boi, shipo);
                        break;
                    }
                case 3:
                    {
                        Malfunction(Shipo);
                        break;
                    }
                case 4:
                    {
                        Wormhole(boi);
                        break;
                    }
            }
        }

        public void DistressCall()
        {
            Console.Clear();
            Console.WriteLine("");
        }
        public void LootBox(Market playerItems)
        {
            //distress call method
            //if distress call is answered, get free repair, or upgrade if no need for repairs, or free beer
            int randoItem = rnd.Next(0, 10);
            int randoItemNo = rnd.Next(1, 8);
            Console.Clear();
            Console.WriteLine("You ship computer detects the debris of a destroyed ship");
            Console.ReadKey();
            Console.WriteLine($"You manage to find {randoItemNo} {playerItems.PlayerInventory[randoItem].name} in salvage");
            Console.ReadKey();
            playerItems.AddLootBox(randoItem, randoItemNo);

        }

        public void Raid(Player boi, Ship ship)
        {
            //distress call method
            //if distress call is answered, dialogue for hiding in a secret compartment while your ship gets damaged, robbed
            Console.Clear();
            Console.WriteLine("Your warp has been interdicted!");
            Console.ReadKey();
            Console.WriteLine("You ship computer alerts you to small boarding vessles approaching");
            Console.ReadKey();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1) Defend yourself 2) Try to flee");
            ConsoleKeyInfo userKey;
            userKey = Console.ReadKey(true);



            switch (userKey.Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.Clear();
                        int defenceChance = rnd.Next(0, 12);

                        if (boi.playerSecurity >= defenceChance)

                        {
                            Console.WriteLine("With your superior tactics, and knowledge of each and every passageway, nook and cranny of your ship, you manage to repel the boarding party");
                            Console.ReadKey();
                        }
                        else {  Console.WriteLine("The boarders overwhelmed you........"); boi.isDead = true;
                            Console.ReadKey();
                        }
                                          
                          
                          
                        
                    }
                    break;

                case ConsoleKey.D2:
                    {

                        Console.WriteLine("You manage to get back into warp, but due to the forced and sudden startup of yous systems, you have damaged your ship badly. ");
                        shipo.DamageShip(boi);
                        shipo.DamageShip(boi);
                        Console.ReadKey();
                    }
                    break;

            }
        }


        public void Malfunction(Ship shipo)
        {
            Console.Clear();
            Console.WriteLine("You somehow managed to run straight into a space rock.");
            Console.ReadKey();
            Console.WriteLine("Your ship computer scolds you");
            Console.ReadKey();
            Console.WriteLine("You should probably fix the damage at the next planet you arrive at");
            shipo.DamageShip(boi);
            Console.ReadKey();
            //dialogue with switch statement for determining type of malfunction from small set of options
            //drops ship health 
            //notify that repairs can be made at the nearest planet
        }

        public void Wormhole(Player boi)
        {
            boi.playerLocation.playerX = rnd.Next(2, 119);
            boi.playerLocation.playerY = rnd.Next(4, 25);
            boi.playerX = boi.playerLocation.playerX;
            boi.playerY = boi.playerLocation.playerY;
            Console.Clear();
            Console.WriteLine("Your ship computer informs you that somehow you managed to run right into a wormhole....");
            Console.ReadKey();
            Console.WriteLine("You emerge on the otherside unharmed.");
            Console.ReadKey();

        }

        //this.boi.playerLocation.playerX = LocationX;
        //this.boi.playerLocation.playerY = LocationY;
    }


}
