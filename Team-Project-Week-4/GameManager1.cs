﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{

        
    public class GameManager
    {
        public class NoItems : Exception { }
        public class NoMoney : Exception { }
        Market PlanetMarket;
        List<PlanetGen> Planets ;
        xmlSaver save;
        xmlLoader load ;
        Player boi ;
        Ship Shipo;

        RandomEvents Events;
        World GameWorld;
       
        
               
        Random rnd = new Random();
        public int planetIndex;
        public int LocationX;
        public int LocationY;
        public int PlanetIndex;

        public GameManager()
        {

            PlanetMarket = new Market();
            Planets = new List<PlanetGen>();
            save = new xmlSaver();
            load = new xmlLoader();
            boi = new Player();
            Shipo = new Ship();
            Shipo.boi = boi;

            GameWorld = new World();


            Events = new RandomEvents();

            rnd = new Random();
        
            LocationX = 0;
            LocationY = 0;
    }

        public string WriteCenterScreen(string textToEnter)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            return textToEnter;
        }
  
        public void GoToSpot()
        {

            Console.Clear();
            Console.WriteLine($"Your ship is capable of Warp Factor {Shipo.engineLevel}");
            Console.WriteLine($"This will take {Shipo.TimeToTravel(this.LocationX, this.LocationY)}");
            Console.WriteLine($"Are you sure you want to travel to X:{LocationX}  Y:{LocationY}?  Y/N");
            try
            {
                char userinput = char.Parse(Console.ReadLine().ToLower());

                switch (userinput)

                {
                    case 'y':
                        Shipo.AgeCalculator(this.LocationX, this.LocationY);                        
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
                    PlanetMarket.GenerateItemsSold();
                    i = PlanetIndex;
                }

            }

        }

        public void PlanetMenu(int i)
        {
            Console.Clear();
            Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {boi.playerAge}  ");
            Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerLocation.playerX} Y:{boi.playerLocation.playerY}");
            Console.WriteLine();
            Console.WriteLine($"You are at {Planets[i].name}");
            Console.WriteLine($"The economy is  {Planets[i].economy}");
            Console.WriteLine();
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
                    {
                        PlanetMarket.PlanetMarket(Planets[PlanetIndex].valueMultiplier, Planets[PlanetIndex].economy);
                        Market(i); }
                    break;
                case ConsoleKey.D2:
                    {
                        Shipo.RepairShip();
                        PlanetMenu(i);
                    }
                    break;
                case ConsoleKey.D3:
                    {
                        Shipo.UpgradeShip();
                        PlanetMenu(i);
                    }
                    break;
                case ConsoleKey.D4:
                    { return; }
                    //break;

            }
        }

        public void Market(int i)
        {
            Market Store = new Market();
            Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {boi.playerAge}  ");
            Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerLocation.playerX} Y:{boi.playerLocation.playerY}");
            Console.WriteLine($"You are at {Planets[i].name}");
            Console.WriteLine($"The economy is  {Planets[i].economy}");
            
            Store.PrintItemsSold();

            PlanetMarket.PlanetMarket( Planets[planetIndex].valueMultiplier, Planets[planetIndex].economy);
            PlanetMarket.SelectItem(boi);
                     

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

        public void YouAreHere()
        {
            Console.SetCursorPosition(boi.playerLocation.playerX , boi.playerLocation.playerY);
            Console.Write("X");
            
        }

        public void SetPlayer()
        {
            Console.SetCursorPosition(Planets[planetIndex].locx -1, Planets[planetIndex].locy);
            Console.Write("[ ]");
            LocationX = Planets[planetIndex].locx;
            LocationY = Planets[planetIndex].locy;
        }

        public void DrawEvent()
        {
            int LocationX = rnd.Next(4, Console.WindowWidth);
            int LocationY = rnd.Next(4, Console.WindowHeight);
            Console.SetCursorPosition(LocationX, LocationY);
            Console.Write('?');
        }

        public void StartGame()
        {
            while (true)
            {
                StartMenu();
            }
        }


        private void StartMenu()
        {
            Console.Clear();
            Console.WriteLine(Console.WindowWidth);
            Console.WriteLine(Console.WindowHeight);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            WriteCenterScreen("------------------------------------------");
            WriteCenterScreen("|     1) New Player                      |");
            WriteCenterScreen("|     2) Start Game                      |");
            WriteCenterScreen("|     3) Show Player Stats               |"); 
            WriteCenterScreen("|     4)                                 |");
            WriteCenterScreen("|     5)                                 |");
            WriteCenterScreen("|     6) Quit                            |");
            WriteCenterScreen("------------------------------------------");


            //User input for main menu
            int mainMenuSelect = 0;
            ConsoleKeyInfo userKey;
            userKey = Console.ReadKey(true);

            try
            {
                mainMenuSelect = int.Parse(Console.ReadLine());
            }
            catch (Exception) { Console.WriteLine("try again"); }

            switch (userKey.Key)
            {
                case ConsoleKey.D1:
                    {

                        SetAttribMenu NewPlayer = new SetAttribMenu(boi, Shipo);
                        NewPlayer.TestPlayerMakerXML();
                        //StartMenu();
                    }
                    break;

                case ConsoleKey.D2:
                    {
                        RunLoop();
                        //StartMenu();
                    }
                    break;

                case ConsoleKey.D3:
                    {
                        PrintStat();
                        Console.ReadKey();
                        //StartMenu();
                    }
           
                    break;
                case ConsoleKey.D4:
                    {
                        
                        
                    }
                     break;

                case ConsoleKey.D5:
                    {
                       Console.WriteLine(Console.LargestWindowHeight);
                        Console.WriteLine(Console.LargestWindowWidth);
                        Console.WriteLine(Console.WindowHeight);
                        Console.WriteLine(Console.WindowWidth);
                        Console.ReadKey();
                    }

                    break;




                case ConsoleKey.D6:
                    {
                        Environment.Exit(1);


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
            this.Shipo = load.LoadXMLShip(load.SaveSlot());
            bool gameRunning = true;

            boi.playerX = boi.playerLocation.playerX;
            boi.playerY = boi.playerLocation.playerY;
            LocationX = boi.playerLocation.playerX;
            LocationY = boi.playerLocation.playerY;
            ConsoleKeyInfo userKey;

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


                                if (planetIndex < 0)
                                { planetIndex = 0; }
                                else {  planetIndex--;}
                               
                               
                                
                                break;


                            case ConsoleKey.RightArrow:
                                
                                

                                if (planetIndex > 15)
                                { planetIndex = 15; }
                                else { planetIndex++; }

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
                                //Cartographer.DrawPlanet();
                                break;

                        }
                        Console.Clear();
                        Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {boi.playerAge}  ");
                        Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerLocation.playerX} Y:{boi.playerLocation.playerY}");
                        SetPlayer();
                        YouAreHere();
                        DrawPlanet();
                        DrawEarth();

                        //Console.SetCursorPosition(LocationX, LocationY);
                        //Console.WriteLine("X");


                    }
                    catch (ArgumentOutOfRangeException) { Console.SetCursorPosition(boi.playerLocation.playerX, boi.playerLocation.playerY); }

                }


            }
        }
    }
}





