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

        public string shipName;
        public int shipHealth = 8;
        public double engineLevel = 6;
        public string shipStatus = "In Working Order";
        public double warpVelocity;

        public Player boi;
       
        public Ship()
        {
        }

       

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
                boi.isDead = true;
                
            }

        }

        public void AgeCalculator(int x, int y)
        {
            boi.playerAge += TimeToTravel(x, y);
        }

        public double TimeToTravel(int x, int y)
        {

            WarpFactor();
            double lightYearTravelTime = 1 / warpVelocity;
            double travelTime = Math.Round(lightYearTravelTime * TravelDistance(x, y), 12 - boi.playerPiloting);
            return travelTime;
        }

        public double TravelDistance(int x, int y)
        {
            int diffX = boi.playerLocation.playerX - x;
            int diffY = boi.playerLocation.playerY - y;

            if (diffX >= 0)
            {
                int newX = diffX;
            }
            else
            {
                int newX = -1 * diffX;
            }

            if (diffX >= 0)
            {
                int newX = diffX;
            }
            else
            {
                int newX = -1 * diffX;
            }

            
            double distanceToTravel = Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2));
            return distanceToTravel;
        }

        public void WarpFactor()
        {

            var W = engineLevel;
            double x = W - 9;
            double powerU = -1 / (1000 * Math.Pow(x, 2));
            double u = Math.Pow(Math.E, powerU);
            double A = 0.03658749373;
            double n = 1.7952294708;
            double PastWarpNine = (u * x) * A * Math.Pow(-1 * Math.Log(Math.E) * (10 - W), n);
            double BelowWarpNine = 10 / 3.0;
            double regularWarpVelocity = Math.Pow(W, BelowWarpNine);
            double highWarpVelocity = Math.Pow(W, BelowWarpNine + PastWarpNine);

            if (x <= 0)
            {
                warpVelocity = regularWarpVelocity;
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
                            if (boi.playerMoney >= 10000)
                            {
                                boi.playerMoney -= 10000;
                                ++shipHealth;
                                Console.WriteLine("Ship Repaired");
                                Console.ReadKey();
                            }
                            else { Console.WriteLine("Not enough Money"); Console.ReadKey(); }
	{

                            }
                        }
                        break;
                    case ConsoleKey.N:
                        {
                        }
                        break;


                }
            }
        }

        public void DamageShip()
        {
            if (shipHealth > 1)
            {
                --shipHealth;
            }
            else
            {
                Console.WriteLine($"{shipName} has been destroyed. Game Over.");
            }

        }

        public void UpgradeShip()
        {


            Console.Clear();

            Console.WriteLine("Are you sure you want to upgrade your engine for $50,000?");
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
                            if (boi.playerMoney < 100000)
                            {
                                boi.playerMoney -= 100000;
                                ++engineLevel;
                                Console.WriteLine("Ship Upgraded!");

                                Console.ReadKey();

                            }

                            else { Console.WriteLine("Not enough money"); Console.ReadKey(); }

                        }
                        break;
                    case ConsoleKey.N:
                        {
                        }
                        break;


                }
            }
        }

        public void CalculateFuel()
        {
            //TODO: Fuel
            //LY/FuelUnit

        }
    }
}

    



﻿