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

        public var PlanetList =  new List<Planets>

        public void SetEarthLoc(PlanetGen Planets)
        {
           this.PlanetLocation = Planets;
           this.EarthX = PlanetLocation.EarthX;
           this.EarthY = PlanetLocation.EarthY;
        }

        public void DrawEarth()  
            {                
                Console.SetCursorPosition(EarthX, EarthY);
                Console.Write('O');
            }



        public void PlanetGenerator()
        {
            PlanetGen NewPlanet = new PlanetGen();
            NewPlanet.name = NewPlanet.NamePlanet();
            NewPlanet.economy = NewPlanet.DeterminePlanetStatus().condition;
            NewPlanet.valueMultiplier = NewPlanet.DeterminePlanetStatus().valueMultiplier;
                       
        }

       
    }
}
