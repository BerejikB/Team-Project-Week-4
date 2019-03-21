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
        Player boi;
        public Ship(Player boi)
        {
            this.boi =  boi;
        }

        public string shipName;
        public int shipHealth = 8;
        public double engineLevel = 9;
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
        //
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
        //
        public void UpgradeShip()
        {
            if (shipStatus == "In Perfect Condition" || shipStatus == "In Working Order")
            {
                Console.Clear();
                Console.WriteLine("Are you sure you want to upgrade your engine for $50,000?");
                
                //add text menu showing upgrade difference
                //add switch statement
                boi.playerMoney -= 50000;
                ++engineLevel;
                Console.WriteLine("Ship Upgraded!");
                Console.ReadKey();

            }
        }
        //
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
        //
        public void RepairShip()
        {
            if (shipStatus != "In Perfect Condition")
            {
                ++shipHealth;
            }
        }


        //TODO: take playerPilotingMult(1-12) into account in ship speed. add certain



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

        public void AgeCalculator()
        {

        }

        public double TimeToTravel()
        {// TODO: 
            
            WarpFactor();
            double travelTime = Math.Round(TravelDistance(boi.playerLocation) / warpVelocity, 12 - boi.playerPiloting);
            return travelTime;
        }

        public double TravelDistance((int planetX, int planetY)selectedPlanet)
        {
            // TODO: Travel Distance Method

            int diffX = boi.playerLocation.playerX - selectedPlanet.planetX;
            int diffY = boi.playerLocation.playerY - selectedPlanet.planetY;
           
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

            //Pythagorean Theorem
            double distanceToTravel = Math.Sqrt(diffX + diffY);
            return distanceToTravel;
        }
    }
}

﻿