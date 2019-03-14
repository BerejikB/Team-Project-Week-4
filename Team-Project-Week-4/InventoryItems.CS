using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
   public class InventoryItems
    {
        public static (int, int) Beer()
        {
            int price = 100;
            int volume = 1;
            return (price, volume);
        }
        public static (int, int) Goat()
        {
            int price = 400;
            int volume = 2;
            return (price, volume);

        }
        public  (int, int) Gold()
        {
            int price = 5000;
            int volume = 5;
            return (price, volume);
        }
        public  (int, int) Sandwiches()
        {
            int price = 80;
            int volume = 1;
            return (price, volume);
        }
        public  (int, int)  Water()
        {
            int price = 30;
            int volume = 1;
            return (price, volume);
        }
        public  (int, int) ConsumerElectronics()
        {
            int price = 10000;
            int volume = 50;
            return (price, volume);
        }
        public (int, int) IndustrialComponents()
        {
            int price = 50000;
            int volume = 200;
            return (price, volume);
        }
        public (int, int) RawIron()
        {
            int price = 6000;
            int volume = 500;
            return (price, volume);
        }
        public (int, int) NuclearMaterial()
        {
            int price = 12000;
            int volume = 500;
            return (price, volume);
        }
        public (int, int) HazardousWaste()
        {
            int price = 37;
            int volume = 2;
            return (price, volume);
        }            
    }
}
