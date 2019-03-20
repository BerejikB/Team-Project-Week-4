using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Project_Week_4;
/// <summary>
// TODO: 
/// </summary>
namespace ShipClass
{
    public class Ship
    {
        
        public string shipName;
        public int shipHealth = 8;
        public double engineLevel = 9;
        public string shipStatus = "In Working Order";
        public double warpVelocity;


        static void Main(string[] args)
        {
            Ship FirstShip = new Ship();
            //The Program Run Class will need to initialize the naming of the ship first, and then the status 

            FirstShip.NameShip();
            FirstShip.ShipStatus();

            PlanetGen newPlanet = new PlanetGen();

            for (int i = 0; i < 5; i++)
            {

                newPlanet.PlanetInfo();

            }
            Console.Clear();
            //newPlanet.ShowPlanetLog(newPlanet.planetLog);
            //FirstShip.TravelTo(newPlanet);
            FirstShip.plotCourse();
            

            
        }
        //
        public void ShipStatus()
        {
            CalculateShipStatus();
            Console.WriteLine($"Ship Name: {shipName}" +
                              $"\nShip Status: {shipStatus}" +
                              $"\nHealth: {shipHealth}" +
                              $"\nCapable of Warp Factor {engineLevel}");
        }
        //
        public void NameShip()
        {
            while(true)
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
                if(engineLevel>3)
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
                ++engineLevel;
            }
        }
        //
        public void DamageShip()
        {
            if(shipHealth>1)
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
            if(shipStatus != "In Perfect Condition")
            {
                ++shipHealth;
            }
        }

        //int LocationX = rnd.Next(4, Console.WindowWidth);
        //int LocationY = rnd.Next(4, Console.WindowHeight);
        //Console.SetCursorPosition(LocationX, LocationY);
        //    Console.Write('o');

        //TODO: take playerPilotingMult(1-12) into account in ship speed. add certain
        //percentage to speed capability for each skill point in piloting
        public void TravelTo(PlanetGen PlanetDestination)
        {
            while(true)
            {
                // TODO: These can't be fixed without push from brendan with PlanetGen Class updated
                PlanetDestination.ShowPlanetLog(PlanetDestination.planetLog); //need push from brendan with List<object> Planets 
                Console.WriteLine("Where would you like to go?");
                int userInput = int.Parse(Console.ReadLine());
                string selection = PlanetDestination.planetLog.ElementAt(userInput);
                Console.WriteLine($"Are you sure you want to travel to {selection}? " +
                    $"\n1. Yes \n2. No");
                string confirmation = Console.ReadLine();
                if (confirmation == "1")
                {
                    plotCourse(PlanetDestination.location);//...or something like that
                    break;
                }
            }
            // TODO: Get from Master of shared proj coordinate shit for planet
        }//Overload: this one is for selecting a planet from your planetLog, make another one to select 
        //a new set of coordinates not specified by a known planet

        public void plotCourse()
        {
            int LocationX;
            int LocationY;
            Console.WriteLine($"Please select your X and Y coordinates: ");
            Console.Write($"X = ");
            LocationX = int.Parse(Console.ReadLine());
            Console.Write($"Y = ");
            LocationY = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(LocationX, LocationY);
        }
        public void plotCourse((int , int ) planetSelectionCoords)
        {
            (int LocationX, int LocationY) = planetSelectionCoords;
            
            Console.SetCursorPosition(LocationX, LocationY);
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

        public void TimeToTravel(Player Player)
        {
            //need distance between points
            
            

        }

        public void TravelDistance(Player Player, PlanetGen Planet)
        {
            int diffX = Player.playerX - Planet.locationX;
            int diffY = Player.playerY - Planet.locationY;
            if(diffX>=0)
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
        }
    }
}

