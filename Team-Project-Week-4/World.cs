using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    public class World
    {
        public int EarthX;
        public int EarthY;
        PlanetGen PlanetLocation;
        Random rnd = new Random();
        public List<PlanetGen> Planets = new List<PlanetGen>();

        public void SetEarthLoc(PlanetGen Planets)
        {
         int earthx = rnd.Next(4, Console.WindowWidth);
             
         int earthy = rnd.Next(4, Console.WindowHeight);
        

           this.PlanetLocation = Planets;
           this.EarthX = earthx;
           this.EarthY = earthy;
        }

        public void DrawEarth()  
            {                
                Console.SetCursorPosition(EarthX, EarthY);
                Console.Write('O');
            }

        public void PlanetGenerator()
        {
            PlanetGen EarthGen = new PlanetGen();
           SetEarthLoc(PlanetLocation);
           EarthGen.name = "Earth";
           EarthGen.economy = "Wealthy";
           EarthGen.valueMultiplier = 1.25;
           EarthGen.locx = EarthX;
           EarthGen.locy = EarthY;
           Planets.Add(EarthGen);


            for (int i = 0; i < 15; i++)
            {
            PlanetGen NewPlanet = new PlanetGen();
               
            NewPlanet.name = NewPlanet.NamePlanet();
            NewPlanet.economy = NewPlanet.DeterminePlanetStatus().condition;
            NewPlanet.valueMultiplier = NewPlanet.DeterminePlanetStatus().valueMultiplier;
            NewPlanet.locx = NewPlanet.LocX();
            NewPlanet.locy = NewPlanet.LocY();
            Planets.Add(NewPlanet);
            }
        }

        public void PrintPlanets()
        {
            foreach (var planet in Planets)
            {
                Console.WriteLine($"{Planets.IndexOf(planet)} {planet.name}");
            }
        }

       
    }
}
