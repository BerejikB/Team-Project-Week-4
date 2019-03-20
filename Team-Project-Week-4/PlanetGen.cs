using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    
    public class PlanetGen
    {
        public Random rnd;
        public List<string> planetLog = new List<string>();
        public string name;
        public string condition;
        public double valueMultiplier;
        public int locx;
        public int locy;
        public string economy;

        public PlanetGen()
        {
            rnd = new Random();
        }

        public PlanetGen(Random rnd)
        {
            this.rnd = rnd;
        }

       
        public int LocX()
        {
            locx = rnd.Next(4, Console.WindowHeight);
            return locx;
        }

        public int LocY()
        {
            locy = rnd.Next(2, Console.WindowHeight);
            return locy;
        }

        public string NamePlanet()
        {
            while (true)
            {
                string testName = $"NP{PlanetNumber()}";
                if (!planetLog.Contains(testName))
                {
                    name = testName;
                    return name;
                }

            }
        }

        public int PlanetNumber()
        {
            int planetNumber = rnd.Next(1000, 10000);
            return planetNumber;
        }

        public void PlanetStatus()//Tested Passed
        {
            DeterminePlanetStatus();
            Console.WriteLine($"Planet {name} has a {condition} economy, \n\tTrade Multiplier: {valueMultiplier}X");

        }

        public int HoldEm()
        {
            int genResult = rnd.Next(5);
            return genResult;
        }

        public (string condition, double valueMultiplier) DeterminePlanetStatus()
        {

            switch (HoldEm())
            {
                case 0:
                    {
                        condition = "Desolate";
                        valueMultiplier = .5;
                        break;

                    }
                case 1:
                    {
                        condition = "Poor";
                        valueMultiplier = .75;
                        break;
                    }
                case 2:
                    {
                        condition = "Average";
                        valueMultiplier = 1.0;
                        break;
                    }
                case 3:
                    {
                        condition = "Wealthy";
                        valueMultiplier = 1.25;
                        break;
                    }
                case 4:
                    {
                        condition = "Extravagant";
                        valueMultiplier = 1.5;
                        break;
                    }

            }

            return (condition, valueMultiplier);

        }
    }
}