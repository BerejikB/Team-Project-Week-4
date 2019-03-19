using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{


    public class GameManager
    {

        xmlSaver save = new xmlSaver();
        xmlLoader load = new xmlLoader();
        Player boi = new Player();
        MapGen Cartographer = new MapGen();

        public string WriteCenterScreen(string textToEnter)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            return textToEnter;
        }


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

        public void StartMenu()

        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            WriteCenterScreen("------------------------------------------");
            WriteCenterScreen("|     1) New Player                      |");
            WriteCenterScreen("|     2) Map Generator NOT IMPLIMENTED   |");
            WriteCenterScreen("|     3) Load Player NOT IMPLIMENTED     |"); 
            WriteCenterScreen("|     4) Start WORK IN PROGRESS          |");
            WriteCenterScreen("|     5) Show Player Stats               |");
            WriteCenterScreen("|     6) Quit                            |");
            WriteCenterScreen("------------------------------------------");


            //User input for main menu
            int mainMenuSelect = 0;

            try
            {
                mainMenuSelect = int.Parse(Console.ReadLine());
            }
            catch (Exception) { Console.WriteLine("try again"); }

            switch (mainMenuSelect)
            {
                case 1:
                    {

                        SetAttribMenu NewPlayer = new SetAttribMenu(boi);
                        NewPlayer.TestPlayerMakerXML();
                        StartMenu();
                    }
                    break;

                case 2:
                    {
                        Console.Clear();
                        Cartographer.GenerateMap();
                        StartMenu();
                    }
                    break;

                case 3:
                    {
                        StartMenu();
                    }
           
                    break;
                case 4:
                    {
                        
                        RunLoop();
                        StartMenu();
                    }
                     break;

                case 5:
                    {
                        PrintStat();
                        Console.ReadKey();
                        StartMenu();
                    }

                    break;




                case 6:
                    {

                    }

                    break;

                default:

                    StartMenu();
                    break;

            }

        }

        public void PrintStat()
        {
            this.boi = load.LoadXML(load.SaveSlot());
            Console.WriteLine($"You are {boi.FirstName} {boi.LastName}, the {boi.Profession}");
            Console.WriteLine($"Your curent attributes are:");
            Console.WriteLine($"Wallet : ${boi.playerMoney}");
            Console.WriteLine($"Security : {boi.playerSecurity}");
            Console.WriteLine($"Speech : {boi.playerSpeech}");
            Console.WriteLine($"Maintenance : {boi.playerMaintenance}");
            Console.WriteLine($"Luck : {boi.playerLuck}");
            Console.WriteLine($"Piloting : {boi.playerPiloting}");
            Console.ReadKey();
            StartMenu();
        }
  
        public void RunLoop()
        {
            
            this.boi = load.LoadXML(load.SaveSlot());
            bool gameRunning = true;
            ConsoleKeyInfo userKey;
            int locationX = 24;
            int locationY = 24;

            while (gameRunning)
            {
                if(boi.isDead )
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    
                    WriteCenterScreen("GAME OVER");
                    WriteCenterScreen(@"      
                     _______________
                    /               \
                   /                 \
                  /                   \
                  |   XXXX     XXXX   |
                  |   XXXX     XXXX   |
                  |   XXX       XXX   |
                  |         X         |
                  \__      XXX     __/
                    |\     XXX     /|
                    | |           | |
                    | I I I I I I I |
                    |  I I I I I I  |
                     \_           _/
                      \_         _/
                        \_______/
");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ReadKey();
                    StartMenu();
                    break;

                }
                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    Console.WriteLine($" Name : {boi.FirstName}   Wallet : {boi.playerMoney}");
                    
                    Console.WriteLine($"X Coord:{locationX}   Y Coord:{locationY}");
                    userKey = Console.ReadKey(true);


                    switch (userKey.Key)
                    {
                        case ConsoleKey.LeftArrow:

                            if (locationX > 4)
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

                            if (locationY > 2)
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
                            Console.Clear();
                            save.WriteXML(boi);

                            gameRunning = false;

                            break;

                        case ConsoleKey.Backspace:
                            boi.playerMoney++;
                            break;

                        case ConsoleKey.Spacebar:
                            Cartographer.DrawPlanet();
                            break;

                    }


                    Console.SetCursorPosition(locationX, locationY);
                    



                }


            }
        }
    }
}





