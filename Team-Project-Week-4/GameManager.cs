using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{

        
    public class GameManager
    {
        Market PlanetMarket = new Market();
        List<PlanetGen> Planets = new List<PlanetGen>();
        xmlSaver save = new xmlSaver();
        xmlLoader load = new xmlLoader();
        Player boi = new Player();
        World GameWorld;
        MapGen Cartographer = new MapGen();
        RandomEvents Events = new RandomEvents();
        //Ship Ship = new Ship(boi);
        
        public string WriteCenterScreen(string textToEnter)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            return textToEnter;
        }
        Random rnd = new Random();
        public int LocationX = 0;
        public int LocationY = 0;
        public int PlanetIndex;
        public GameManager()
        {
            Ship = new Ship(boi);
        }

        public string WriteCenterScreen(string textToEnter)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            return textToEnter;
        }
  
        public void GoToSpot()
        {

            Console.Clear();
            Console.WriteLine($"Are you sure you want to travel to X:{LocationX}  Y:{LocationY}?  Y/N");
           
            try
            {
                char userinput = char.Parse(Console.ReadLine().ToLower());

                switch (userinput)

                {
                    case 'y':
                        
                        this.boi.playerLocation.playerX = LocationX;
                        this.boi.playerLocation.playerY = LocationY;

                        break;

                    case 'n':
                        break;

                }

            }
            catch (Exception)
            {
                Console.WriteLine($"I'm sorry {boi.FirstName}, I'm afraid I can't do that.");

            }


            for (int i = 0; i < 15; i++)

            {
                if (boi.playerLocation.playerX == this.Planets[i].locx && boi.playerLocation.playerY == this.Planets[i].locy)
                {
                    PlanetMenu(i);
                    i = PlanetIndex;
                }

            }

        }

        public void PlanetMenu(int i)
        {
            Console.Clear();
            Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {boi.playerAge}  ");
            Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerX} Y:{boi.playerY}");
            Console.WriteLine($"You are at {Planets[i].name}");
            Console.WriteLine($"The economy is  {Planets[i].economy}");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"1) Go to the market");
            Console.WriteLine($"2) Repair Ship");
            Console.WriteLine($"3) Upgrade ship");
            Console.WriteLine($"4) Leave");
            Console.WriteLine();

            ConsoleKeyInfo userinputboi;
            userinputboi = Console.ReadKey(true);


            switch (userinputboi.Key)
            {
                case ConsoleKey.D1:
                    { Market(i); }
                    break;
                case ConsoleKey.D2:
                    {
                        Ship.RepairShip();
                        PlanetMenu(i);
                    }
                    break;
                case ConsoleKey.D3:
                    {
                        Ship.UpgradeShip();
                        PlanetMenu(i);
                    }
                    break;
                case ConsoleKey.D4:
                    { }
                    break;

            }
        }
        public void Market(int i)
        {
            Market Store = new Market();
            Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {boi.playerAge}  ");
            Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerX} Y:{boi.playerY}");
            Console.WriteLine($"You are at {Planets[i].name}");
            Console.WriteLine($"The economy is  {Planets[i].economy}");
            Store.PrintItemsSold();
            Store.SelectItem(boi);
                     

        }


        public void DrawEarth()
        {
            Console.SetCursorPosition(GameWorld.EarthX, GameWorld.EarthY);
            Console.Write('O');
        }

        public void DrawPlanet()
        {
            for (int i = 0; i < 15; i++)

            {
                Console.SetCursorPosition(Planets[i].locx, Planets[i].locy);
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
            Console.WriteLine(Console.WindowWidth);
            Console.WriteLine(Console.WindowHeight);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            WriteCenterScreen("------------------------------------------");
            WriteCenterScreen("|     1) New Player                      |");
            WriteCenterScreen("|     2) Start WORK IN PROGRESS          |");
            WriteCenterScreen("|     3) Show Player Stats               |"); 
            WriteCenterScreen("|     4)                                 |");
            WriteCenterScreen("|     5)                                 |");
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
                        RunLoop();
                        StartMenu();
                    }
                    break;

                case 3:
                    {
                        PrintStat();
                        Console.ReadKey();
                        StartMenu();
                    }
           
                    break;
                case 4:
                    {
                        
                        
                    }
                     break;

                case 5:
                    {
                       
                    }

                    break;




                case 6:
                    {
                        Console.WriteLine(Console.LargestWindowHeight);
                        Console.WriteLine(Console.LargestWindowWidth);
                        Console.WriteLine(Console.WindowHeight);
                        Console.WriteLine(Console.WindowWidth);
                        Console.ReadKey();
                        
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
            this.Planets = load.LoadXMLPlanets(load.SaveSlot()); 
            this.boi = load.LoadXML(load.SaveSlot());
            this.Ship = load.LoadXMLShip(load.SaveSlot());
            bool gameRunning = true;
            ConsoleKeyInfo userKey;
            LocationX = boi.playerLocation.playerX;
            LocationY = boi.playerLocation.playerY;

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
                   
                    userKey = Console.ReadKey(true);
                    try
                    {
                        switch (userKey.Key)
                        {

                            case ConsoleKey.LeftArrow:

                                try
                                {
                                    if (LocationX > 4)
                                    {
                                        LocationX = LocationX - 1;
                                    }
                                }
                                catch (Exception) { LocationX = LocationX + 1; }

                                break;


                            case ConsoleKey.RightArrow:
                                try
                                {
                                    if (LocationX < Console.WindowWidth)
                                    {
                                        LocationX = LocationX + 1;
                                    }
                                }
                                catch (Exception) { LocationX = LocationX - 1; }
                                break;


                            case ConsoleKey.UpArrow:

                                try
                                {

                                    if (LocationY > 2)

                                    {
                                        LocationY = LocationY - 1;

                                    }
                                }
                                catch (Exception) { LocationY = LocationY + 1; }
                                break;



                            case ConsoleKey.DownArrow:
                                try
                                {
                                    if (LocationY < Console.WindowHeight)
                                    {
                                        LocationY = LocationY + 1;
                                    }
                                }
                                catch (Exception) { LocationY = LocationY - 1; }

                                break;


                            case ConsoleKey.Enter:
                                GoToSpot();
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
                        Console.Clear();
                        
                        Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {boi.playerAge}  ");
                        Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerLocation.playerX} Y:{boi.playerLocation.playerY}");
                        DrawEarth();
                        DrawPlanet();

                        Console.SetCursorPosition(LocationX, LocationY);
                         Console.WriteLine("X");


                    }
                    catch (ArgumentOutOfRangeException) { Console.SetCursorPosition(boi.playerLocation.playerX, boi.playerLocation.playerY); }

                }


            }
        }
    }
}





