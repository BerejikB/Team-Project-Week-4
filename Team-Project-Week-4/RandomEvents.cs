using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    class RandomEvents
    {
        public void NumOfEvents()
        {
            Random rnd = new Random();
            int eventNum = rnd.Next(3, 5);

            do
            {
                eventNum--;
            }
            while (eventNum > 0);

        }

        public void EventType()
        { }

        public void LootBox()
        { }

        public void Raid()
        { }

        public void Malfuntion()
        { }

        public void Wormhole()
        {
            //TODO: 
        }

        //this.boi.playerLocation.playerX = LocationX;
        //this.boi.playerLocation.playerY = LocationY;
    }


}
