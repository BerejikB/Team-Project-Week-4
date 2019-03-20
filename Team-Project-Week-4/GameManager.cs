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
        World GameWorld;
       
        MapGen Cartographer = new MapGen();
        RandomEvents Events = new RandomEvents();


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
            //NumOfPlanets();
            //NumOfEvents();
            Console.ReadKey();

        }

        public void GoToSpot()
        {

            Console.Clear();
            Console.WriteLine($"Are you sure you want to travel to X:{LocationX}  Y:{LocationY}?  Y/N");
            Console.WriteLine();

            try
            {
                char userinput = char.Parse(Console.ReadLine().ToLower());

                switch (userinput)

                {
                    case 'y':
                        this.boi.playerX = LocationX;
                        this.boi.playerY = LocationY;

                        break;

                    case 'n':
                        break;

                }

            }
            catch (Exception)
            {
                Console.WriteLine($"I'm sorry {boi.FirstName}, I'm afraid I can't do that.");

            }
            
            

        }

        public void DrawEarth()
        {
            Console.SetCursorPosition(GameWorld.EarthX, GameWorld.EarthY);
            Console.Write('O');
        }


        public void DrawPlanet()
        {
            foreach (var planet in GameWorld.Planets)
            {
                //Console.SetCursorPosition(GameWorld.Planet, GameWorld.);
                Console.Write('o');
            }

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
            Console.Clear();
            this.GameWorld = load.LoadXMLWorld(load.SaveSlot());
            this.boi = load.LoadXML(load.SaveSlot());
            
            bool gameRunning = true;
            ConsoleKeyInfo userKey;
            LocationX = boi.playerX;
            LocationY = boi.playerY;

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
                    Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {boi.playerAge}  ");
                    Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}");

                    DrawEarth();
                    userKey = Console.ReadKey(true);
                    
                    switch (userKey.Key)
                    {
                        case ConsoleKey.LeftArrow:

                            if (LocationX > 4)
                            {
                                LocationX = LocationX - 1;
                            }
                            break;

                        case ConsoleKey.RightArrow:

                            if (LocationX < 78)
                            {
                                LocationX = LocationX + 1;
                            }
                            break;

                        case ConsoleKey.UpArrow:

                            if (LocationY > 2)
                            {
                                LocationY = LocationY - 1;
                            }
                            break;

                        case ConsoleKey.DownArrow:

                            if (LocationY < 24)
                            {

                                LocationY = LocationY + 1;
                            }
                            break;
                        case ConsoleKey.Enter:
                            GoToSpot();
                            break;

                        case ConsoleKey.Escape:
                            Console.Clear();
                            save.WriteXML(boi);
                            save.WriteXMLWorld(GameWorld);
                            gameRunning = false;
                            break;

                        case ConsoleKey.Backspace:
                            boi.playerMoney++;
                            break;

                        case ConsoleKey.Spacebar:
                            Cartographer.DrawPlanet();
                            break;

                    }

                    Console.SetCursorPosition(LocationX, LocationY);
 
                }


            }
        }
    }
}





