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
        Ship Shipo;
        Market PlayerItems;
        public RandomEvents(Player boi, Ship shipo, Market playerItems)
        {
            this.boi = boi;
            this.Shipo = shipo;
            this.PlayerItems = playerItems;
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
                        LootBox();
                        break;
                    }
                case 2:
                    {
                        Raid();
                        break;
                    }
                case 3:
                    {
                        Malfunction();
                        break;
                    }
                case 4:
                    {
                        Wormhole();
                        break;
                    }
            }
        }

        public void DistressCall()
        {
            Console.Clear();
            Console.WriteLine("");
        }
        public void LootBox()
        {
            //distress call method
            //if distress call is answered, get free repair, or upgrade if no need for repairs, or free beer
            int randoItem = rnd.Next(0, 10);
            int randoItemNo = rnd.Next(0, 8);
            Console.Clear();
            Console.WriteLine("You ship computer detects the debris of a destroyed ship");
            Console.ReadKey();
            PlayerItems.PlayerInventory[randoItem].Planetquantity += randoItemNo;
            Console.WriteLine($"You manage to find {randoItemNo} {PlayerItems.PlayerInventory[randoItem].name} in salvage");
            Console.ReadKey();

        }

        public void Raid()
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
                        }
                        else
                                          
                          Console.WriteLine("The boarders overwhelmed you........"); boi.isDead = true;
                          
                        
                    }
                    break;

                case ConsoleKey.D2:
                    {

                        Console.WriteLine("You manage to get back into warp, but due to the forced and sudden startup of yous systems, you have damaged your ship badly. ");
                        Shipo.DamageShip();
                        Shipo.DamageShip();
                    }
                    break;

            }
        }


        public void Malfunction()
        {
            Console.Clear();
            Console.WriteLine("You somehow managed to run straight into a space rock.");
            Console.ReadKey();
            Console.WriteLine("Your ship computer scolds you");
            Console.ReadKey();
            Console.WriteLine("You should probably fix the damage at the next planet you arrive at");
            //dialogue with switch statement for determining type of malfunction from small set of options
            //drops ship health 
            //notify that repairs can be made at the nearest planet
        }

        public void Wormhole()
        {
            boi.playerLocation.playerX = rnd.Next(2, 119);
            boi.playerLocation.playerY = rnd.Next(4, 25);
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
