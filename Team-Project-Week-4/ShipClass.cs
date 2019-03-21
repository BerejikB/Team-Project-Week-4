using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Project_Week_4;

namespace Team_Project_Week_4
{

    public class Ship
    {
        Player Boi;

        GameManager GameWorld;
        Player boi;
        public Ship(Player boi)
        {
            this.Boi = boi;
        }

        public string shipName;
        public int shipHealth = 8;
        public double engineLevel = 6;
        public string shipStatus = "In Working Order";
        public double warpVelocity;


        public void ShipStatus()
        {
            CalculateShipStatus();
            Console.WriteLine($"Ship Name: {shipName}" +
                              $"\nShip Status: {shipStatus}" +
                              $"\nHealth: {shipHealth}" +
                              $"\nCapable of Warp Factor {engineLevel}");
        }

        public void NameShip()
        {
            while (true)
            {
                Console.WriteLine("Name your new ship");
                string userInput = Console.ReadLine();
                Console.WriteLine($"Are you sure you want to name your ship {userInput}? " +
                    $"\n1. Yes \n2. No");
                string confirmation = Console.ReadLine();
                if (confirmation == "1")
                {
                    shipName = userInput;
                    break;
                }
            }

        }

        public void CalculateShipStatus()
        {
            if (shipHealth == 10)
            {
                shipStatus = "In Perfect Condition";
            }
            else if (shipHealth < 10 && shipHealth > 5)
            {
                shipStatus = "In Working Order";
            }
            else if (shipHealth <= 5 && shipHealth >= 3)
            {
                shipStatus = "In Need of Repairs";
            }
            else if (shipHealth < 3 && shipHealth > 0)
            {
                shipStatus = "Critical";
                if (engineLevel > 3)
                {
                    engineLevel = 3;
                }
            }
            else if (shipHealth == 0)
            {
                shipStatus = "Destroyed";
                //TODO: add Player is dead
            }

        }

        public void AgeCalculator()
        {
            if (shipStatus == "In Perfect Condition" || shipStatus == "In Working Order")
            {
                Console.Clear();
                Console.WriteLine($"Current ship engine level is {engineLevel}");
                Console.WriteLine("Are you sure you want to upgrade your engine for $100000? Y/N");
                ConsoleKeyInfo userinputboi;
                userinputboi = Console.ReadKey(true);


                switch (userinputboi.Key)
                {
                    case ConsoleKey.Y:
                        {
                            Boi.playerMoney -= 100000;
                            ++engineLevel;
                            Console.WriteLine("Ship Upgraded!");

                            Console.ReadKey();

                        }
                        break;
                    case ConsoleKey.N:
                        {
                        }
                        break;


                }
            }
        }
       
        public void RepairShip()
        {
            if (shipStatus != "In Perfect Condition")
            {
                Console.Clear();
                Console.WriteLine($"Current ship health level is {shipHealth}/10");
                Console.WriteLine("Are you sure you want to repair your ship (+1 health) for $10000? Y/N");
                ConsoleKeyInfo userinputboi;
                userinputboi = Console.ReadKey(true);


                switch (userinputboi.Key)
                {
                    case ConsoleKey.Y:
                        {
                            Boi.playerMoney -= 10000;
                            ++shipHealth;
                            Console.WriteLine("Ship Repaired");
                            Console.ReadKey();

                        }
                        break;
                    case ConsoleKey.N:
                        {
                        }
                        break;


                }
            }
        }


        public void UpgradeShip()
        {


            Console.Clear();

            Console.WriteLine("Are you sure you want to upgrade your engine for $50,000?");
            if (shipStatus == "In Perfect Condition" || shipStatus == "In Working Order")
            {

                ConsoleKeyInfo userinputboi;

                userinputboi = Console.ReadKey(true);



                switch (userinputboi.Key)

                {
                    case ConsoleKey.Y:

                        {
                            Boi.playerMoney -= 100000;
                            ++shipHealth;
                            Console.WriteLine("Engine Upgraded");
                            Console.ReadKey();

                        }
                        break;
                    case ConsoleKey.N:
                        {
                        }
                        break;


                }

            }
        }
        

    }
}


﻿