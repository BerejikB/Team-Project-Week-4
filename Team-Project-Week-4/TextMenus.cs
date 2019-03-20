using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    class TextMenus
    {
        World GameWorld;

        List<PlanetGen> Planets;

        public List<PlanetGen> thesePlanets;

        public void PrintPlanet(int i)
        {
            this.thesePlanets = Planets;
           


            Console.WriteLine($"You are at {Planets[i].name}");
            Console.WriteLine($"The economy is  {Planets[i].economy}");
            Console.WriteLine($"You are at {Planets[i].name}");



        }







    }
}
