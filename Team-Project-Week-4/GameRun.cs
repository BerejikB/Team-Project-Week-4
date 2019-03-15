using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{
    class GameRun
    {
        public void RunLoop()
        {
            GameManager GM = new GameManager();
            xmlLoader status = new xmlLoader();
            Menu mainmen = new Menu();
            int savenum = GM.SaveSlot();
            status.LoadXML(savenum);

            
            bool gameRunning = true;
            ConsoleKeyInfo userKey;
            int locationX = 24;
            int locationY = 24;

            while (gameRunning)
            {
                // Begin with processing input
                if (Console.KeyAvailable)
                {
                    Console.Clear();

                    Console.Write($" Name : {status.FirstName}   Wallet : {status.playerMoney}");

                    Console.SetCursorPosition(locationX, locationY);
                    Console.Write("||");
                    userKey = Console.ReadKey(true);

                    switch (userKey.Key)
                    {
                        case ConsoleKey.LeftArrow:
                           
                            if (locationX > 0)
                            {
                                
                                locationX = locationX - 1;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            
                            if (locationX < 78)
                            {
                                
                                locationX = locationX + 1;
                            }
                            break;

                        case ConsoleKey.UpArrow:
                            
                            if (locationY > 0)
                            {
                              
                                locationY = locationY - 1;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                           
                            if (locationY < 24)
                            {
                               
                                locationY = locationY + 1;
                            }
                            break;

                        case ConsoleKey.Escape:
                            
                            gameRunning = false;
                            break;
                    }
                }

                
            }
        }
    }
}

        
        

