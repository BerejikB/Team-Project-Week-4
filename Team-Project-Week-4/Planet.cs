using System;
using System.Collections.Generic;

namespace ShipClass
{
    /// <summary>
    /// Need to assign coordinates to planets, work with Brendan on random planet generator pulling saved coordinates.
    /// </summary>
    public class Planet
    {
        public List<string> planetLog = new List<string>();
        private string name;
        private string condition;
        private double valueMultiplier;

        Random attributeGenerator = new Random();

        public void PlanetInfo()
        {
            NamePlanet();
            PlanetStatus();
        }
        
        private void NamePlanet()
        {
            while(true)
            {
                string testName = $"NP{PlanetNumber()}";
                if (!planetLog.Contains(testName))
                {
                    name = testName;
                    Console.WriteLine($"Planet name {name}");
                    break;
                }
                
            }

        }
        

        private int PlanetNumber()
        {
            int planetNumber = attributeGenerator.Next(1000, 10000);
            return planetNumber;
        }

        private void PlanetStatus()//Tested Passed
        {
            DeterminePlanetStatus();
            Console.WriteLine($"Planet Status: {condition}\n\t Trade Multiplier: {valueMultiplier}X");
            
        }

        private int HoldEm()
        {
            int genResult = attributeGenerator.Next(5);
            return genResult;
        }

        private void DeterminePlanetStatus()
        {
            


            switch (HoldEm())
            {
                case 0:
                    {
                        condition = "Slums";
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
                        condition = "Stable";
                        valueMultiplier = 1.0;
                        break;
                    }
                case 3:
                    {
                        condition = "Middle Class";
                        valueMultiplier = 1.25;
                        break;
                    }
                case 4:
                    {
                        condition = "Rich";
                        valueMultiplier = 1.5;
                        break;
                    }
            }
            
        }
    }
}