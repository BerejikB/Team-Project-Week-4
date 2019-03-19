using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    public class MapGen
    {
        Random rnd = new Random();
        public int LocationX = 0;
        public int LocationY = 0;

        public void GenerateMap()
        {
           // Console.Clear();
            NumOfPlanets();
            NumOfEvents();
            Console.ReadKey();

        }


        public void NumOfPlanets()
        {
            int planetNum = 0;

            for (; planetNum < 15; planetNum++)
            {
                DrawPlanet();
            }
            
              

        }

        public void NumOfEvents()
        {
            Random rnd = new Random();
            int eventNum = rnd.Next(3, 5);
            
            do
            {
                DrawEvent();
                eventNum--;
            }
            while (eventNum > 0);

        }

        public void DrawPlanet()
        {
            
            int LocationX = rnd.Next(4, Console.WindowWidth);
            int LocationY = rnd.Next(4, Console.WindowHeight);
            Console.SetCursorPosition(LocationX, LocationY);
            Console.Write('o');
        }

        public void DrawEvent()
        {
            int LocationX = rnd.Next(4, Console.WindowWidth);
            int LocationY = rnd.Next(4, Console.WindowHeight);
            Console.SetCursorPosition(LocationX, LocationY);
            Console.Write('?');
        }
    }


}
