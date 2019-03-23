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
        public RandomEvents(Player boi, Ship shipo)
        {
            this.boi = boi;
            this.Shipo = shipo;
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

        public void EventType(Player boi, Ship Shipo)
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
            int randoMoney = rnd.Next(7, 5000);
            Console.Clear();
            Console.WriteLine("You ship computer detects the debris of a destroyed ship");
            Console.ReadKey();
            Console.WriteLine($"You manage to find ${randoMoney} in salvage");
            boi.playerMoney += randoMoney;
            Console.ReadKey();

        }

        public void Raid()
        {
            //distress call method
            //if distress call is answered, dialogue for hiding in a secret compartment while your ship gets damaged, robbed
            Console.WriteLine("Your warp has been interdicted!");
            Console.ReadKey();
            Console.WriteLine("You ship computer alerts you to small boarding vessles approaching");
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
                        if (boi.playerSecurity >= defenceChance) ;
                        { Console.WriteLine("With your superior tactics, and knowledge of each and every passageway, nook and cranny of your ship, you manage to repel the boarding party"); }
                        else{ Console.WriteLine("The boarders overwhelmed you........"); boi.isDead = true; }
                    }
                    break;

                case ConsoleKey.D2:
                    {

                        
                    }
                    break;

            }
        }


        public void Malfunction()
        {
            //dialogue with switch statement for determining type of malfunction from small set of options
            //drops ship health 
            //notify that repairs can be made at the nearest planet
        }

        public void Wormhole()
        {
            //random generator for x and y coordinates
            //setCursor to these new x and y coordinates
            //prompts dialogue to inform you of wormhole event

        }

        //this.boi.playerLocation.playerX = LocationX;
        //this.boi.playerLocation.playerY = LocationY;
    }


}
