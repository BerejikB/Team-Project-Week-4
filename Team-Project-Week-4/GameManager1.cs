using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Team_Project_Week_4;
using System.Xml.Serialization;
using System.Xml.Linq;

using System.Xml;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Team_Project_Week_4
{

        
    public class GameManager
    {
        StoryMenus Story;
        public class NoItems : Exception { }
        public class NoMoney : Exception { }
        Market PlanetMarket;
        List<PlanetGen> Planets ;
        xmlSaver save;
        xmlLoader load ;
        Player boi ;
        Ship Shipo;
        InventoryItems UseablePlayerItems;
        RandomEvents Events;
        World GameWorld;
        Item PlayerItems;
        List<Item> PlayerInventory;
        Market Market;
        
               
        Random rnd = new Random();
        public int planetIndex;
        public int LocationX;
        public int LocationY;
        public int PlanetIndex;
        public bool gameWin = false;
        public bool letmeleave = false;
        public int SelectedSave;
        public GameManager()
        {

            PlanetMarket = new Market();
            Planets = new List<PlanetGen>();
            save = new xmlSaver();
            load = new xmlLoader();
            boi = new Player();
            Shipo = new Ship();
            Shipo.boi = boi;
            Story = new StoryMenus();
            GameWorld = new World();
            Events = new RandomEvents(boi, Shipo, PlanetMarket);
            rnd = new Random();
            UseablePlayerItems = new InventoryItems();
            PlayerInventory  = new List<Item>();
            LocationX = 0;
            LocationY = 0;
    }

        public string WriteCenterScreen(string textToEnter)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            return textToEnter;
        }
        public void GameOver()
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
            




        }

        public void AutoSave()
        {
            load.SaveSlotsetter = SelectedSave;
            save.WriteXML(SelectedSave, boi);
            save.WriteXMLInventory(SelectedSave, PlanetMarket);
            save.WriteXMLShip(SelectedSave, Shipo);
        }
        public void LoadGame()
        {

            {

                try
                {
                    Console.WriteLine($"Select Save Slot 1 {File.Exists("player1.xml")}");
                    Console.WriteLine($"Select Save Slot 2 {File.Exists("player2.xml")}");
                    Console.WriteLine($"Select Save Slot 3 {File.Exists("player3.xml")}");
                    ConsoleKeyInfo userinputboi;
                    userinputboi = Console.ReadKey(true);


                    switch (userinputboi.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                SelectedSave = 1;
                            }
                            break;
                        case ConsoleKey.D2:
                            {
                                SelectedSave = 2;
                            }

                            break;
                        case ConsoleKey.D3:
                            {
                                SelectedSave = 3;
                            }
                            break;
                    }
                }
                catch (Exception) { Console.WriteLine("try again"); }
            }

        }


    
         public void EventChecker()
        {
          int randy = rnd.Next(1, 4);

            if(randy == 3)
            {
                Console.Clear();
                Console.WriteLine("Your ship computer drops you out of warp because of an imminent collision......");
                Console.ReadKey();
                Events.EventType( boi, Shipo, PlanetMarket);
                AutoSave();
                SetPlayer();
                DrawPlanet();
                DrawEarth();
                YouAreHere();
            }

        }

        public void GoToSpot()
        {

            Console.Clear();
            Console.WriteLine($"Your ship is capable of Warp Factor {Shipo.engineLevel} and you have {Shipo.fuelLevel}/100 fuel left");
            Console.WriteLine($"This will take {Math.Ceiling((Shipo.TimeToTravelDays( this.LocationX, this.LocationY)))} days and {Shipo.CalculateFuelConsumption(boi, this.LocationX, this.LocationY)} fuel)");            
            Console.WriteLine($"Are you sure you want to travel to X:{LocationX}  Y:{LocationY}?  Y/N");
            
            ConsoleKeyInfo userinputboi;
            userinputboi = Console.ReadKey(true);

            try
            {
               

                switch (userinputboi.Key)

                {
                    case ConsoleKey.Y:
                        letmeleave = false;
                        if (Shipo.fuelLevel >= Shipo.CalculateFuelConsumption( boi, this.LocationX, this.LocationY))
                        {
                            Shipo.AgeCalculator(this.LocationX, this.LocationY);
                            this.boi.playerLocation.playerX = LocationX;
                            this.boi.playerLocation.playerY = LocationY;

                            boi.playerX = boi.playerLocation.playerX;
                            boi.playerY = boi.playerLocation.playerY;
                            boi.playerAge += Shipo.TimeToTravel(this.LocationX, this.LocationY);
                            Shipo.fuelLevel -= Shipo.CalculateFuelConsumption(boi, this.LocationX, this.LocationY);
                            EventChecker();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You do not have enough fuel to make this trip. Either buy fuel before leaving or pick a closer planet.");
                            Console.ReadKey();
                        }
                        break;

                    case ConsoleKey.N:
                        break;

                }

            }
            catch (Exception)
            {
                Console.WriteLine($"I'm sorry {boi.FirstName}, I'm afraid I can't do that.");

            }


            for (int i = 0; i < 17; i++)

            {
                if (boi.playerLocation.playerX == this.Planets[i].locx && boi.playerLocation.playerY == this.Planets[i].locy)
                {
                    if (letmeleave == false)
                    {
                        PlanetMenu(i);
                        PlanetMarket.GenerateItemsSold();
                        i = PlanetIndex;
                    }
                    else return;
                    
                }

            }

        }

        public void PlanetMenu(int i)
        {
            if (boi.isDead)
            {
                GameOver();
            }

            letmeleave = false;
            Console.Clear();
            Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {Math.Floor(boi.playerAge)} Ship Health: {Shipo.shipHealth} Engine Level: {Shipo.engineLevel} Fuel Level: {Shipo.fuelLevel}/100");
            Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerLocation.playerX} Y:{boi.playerLocation.playerY}");
            Console.WriteLine();
            Console.WriteLine($"You are at {Planets[i].name}");
            Console.WriteLine($"The economy is  {Planets[i].economy}");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"1) Go to the market");
            Console.WriteLine($"2) Repair Ship");
            Console.WriteLine($"3) Upgrade Ship");
            Console.WriteLine($"4) Buy Fuel");
            Console.WriteLine($"5) Leave");
            if (i == 0)
            { Console.WriteLine("6) Buy out your contract from Space Shippers Inc $500,000"); }
            if (i == 16)
            { Console.WriteLine("6) Escape to this resort planet with a new identity for $1,000,000"); }
            Console.WriteLine();

            ConsoleKeyInfo userinputboi;
            userinputboi = Console.ReadKey(true);


            switch (userinputboi.Key)
            {
                case ConsoleKey.D1:
                    {
                        PlanetMarket.PlanetMarket(Planets[PlanetIndex].valueMultiplier, Planets[PlanetIndex].economy);
                        GoToMarket(i, PlayerInventory);
                    }
                    break;
                case ConsoleKey.D2:
                    {
                        Shipo.RepairShip(boi);
                        PlanetMenu(i);
                    }
                    break;
                case ConsoleKey.D3:
                    {
                        Shipo.UpgradeShip(boi);
                        PlanetMenu(i);
                    }
                    break;
                case ConsoleKey.D4:
                    Shipo.BuyFuel(boi);
                    break;
                
                case ConsoleKey.D5:
                    letmeleave = true;
                    AutoSave();
                    break;

                case ConsoleKey.D6:

                    if (i == 16)
                    { Story.EscapeToResort(boi.playerMoney, boi); }
                    if (i == 0)
                    { Story.BuyContract(boi.playerMoney, boi); }
                        break;

            }
        }

        public void GoToMarket(int i, List<Item> PlayerInventory)
        {
            
            Market Store = new Market();
            Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {Math.Floor(boi.playerAge)}  ");
            Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerLocation.playerX} Y:{boi.playerLocation.playerY}");
            Console.WriteLine($"You are at {Planets[i].name}");
            Console.WriteLine($"The economy is  {Planets[i].economy}");

            

            PlanetMarket.InitMarket(SelectedSave);
            Store.PrintItemsSold();
            PlanetMarket.PlanetMarket( Planets[planetIndex].valueMultiplier, Planets[planetIndex].economy);
            PlanetMarket.InitMarket(SelectedSave);
            PlanetMarket.SelectItem(boi);
            AutoSave();
            


        }

        public void DrawEarth()
        {
            Console.SetCursorPosition(GameWorld.EarthX, GameWorld.EarthY);
            Console.Write('O');
        }

        public void DrawPlanet()
        {
            for (int i = 0; i < 17; i++)

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
           
            Console.Write(@" 

                     $$$$$$$$\        $$\              $$\ $$\                 
                     \__$$  __|       $$ |             $$ |$$ |                
                       $$ | $$$$$$\$$$$$$\   $$$$$$\  $$ |$$ |$$\   $$\      
                       $$ |$$  __$$\_$$  _|  \____$$\ $$ |$$ |$$ |  $$ |     
                       $$ |$$ /  $$ |$$ |    $$$$$$$ |$$ |$$ |$$ |  $$ |       
                       $$ |$$ |  $$ |$$ |$$\$$  __$$ |$$ |$$ |$$ |  $$ |      
                       $$ |\$$$$$$  |\$$$$  \$$$$$$$ |$$ |$$ |\$$$$$$$ |    
                       \__| \______/  \____/ \_______|\__|\__| \____$$ |     
                                                              $$\   $$ |                                                                                               
                    ------------------------------------------\$$$$$$  |                                                                                                
                    |     1) New Game                        | \______/ 
                    |     2) Load and start Game             |
                    |     3) Show Player Stats               |
                    |     6) Quit                            |
                    ------------------------------------------                                                                                							   							   					   
   $$$$$$\                                                $$\        $$$$$$\             $$\     
 $$ /  \__| $$$$$$\   $$$$$$\   $$$$$$$\  $$$$$$\   $$$$$$$ |      $$ /  $$ |$$\   $$\$$$$$$\   
 \$$$$$$\  $$  __$$\  \____$$\ $$  _____|$$  __$$\ $$  __$$ |      $$ |  $$ |$$ |  $$ \_$$  _|  
  \____$$\ $$ /  $$ | $$$$$$$ |$$ /      $$$$$$$$ |$$ /  $$ |      $$ |  $$ |$$ |  $$ | $$ |    
 $$\   $$ |$$ |  $$ |$$  __$$ |$$ |      $$   ____|$$ |  $$ |      $$ |  $$ |$$ |  $$ | $$ |$$\ 
 \$$$$$$  |$$$$$$$  |\$$$$$$$ |\$$$$$$$\ \$$$$$$$\ \$$$$$$$ |       $$$$$$  |\$$$$$$  | \$$$$  |
  \______/ $$  ____/  \_______| \_______| \_______| \_______|       \______/  \______/   \____/ 
           $$ |                                                                                 
           $$ |                                                                                                 
           \__|                                                                                 
");





            //User input for main menu
            
            ConsoleKeyInfo userKey;
            userKey = Console.ReadKey(true);

            

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
                        LoadGame();
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
            this.boi = load.LoadXML(load.SaveSlotsetter);
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
            this.GameWorld = load.LoadXMLWorld(SelectedSave);
            this.Planets = load.LoadXMLPlanets(SelectedSave); 
            this.boi = load.LoadXML(SelectedSave);
            this.Shipo = load.LoadXMLShip(SelectedSave);
            this.PlayerInventory = load.LoadXMLInventory(SelectedSave);
            this.SelectedSave = (int)load.SaveSlotsetter;
            load.SaveSlotsetter = SelectedSave;
            bool gameRunning = true;

            boi.playerX = boi.playerLocation.playerX;
            boi.playerY = boi.playerLocation.playerY;

            ConsoleKeyInfo userKey;

            while (gameRunning)
            {
                if(boi.isDead )
                {
                    GameOver();
                }
                if (boi.playerAge >= 40)
                {
                    Console.Clear();
                    Console.WriteLine("Space Shippers Inc is coming for your organs......................");
                    Console.ReadKey();
                    GameOver();
                }
                if (boi.iswin == true)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You Win!");
                    StartMenu();
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
                                AutoSave();
                                gameRunning = false;
                                break;



                            

                        }
                        Console.Clear();
                        Console.WriteLine($" Name: {boi.FirstName}   Wallet: {boi.playerMoney}  Age: {Math.Floor(boi.playerAge)} Ship Health: {Shipo.shipHealth} Engine Level: {Shipo.engineLevel} Fuel Level: {Shipo.fuelLevel}/100");
                        Console.WriteLine($"X Coord:{LocationX}   Y Coord:{LocationY}     Player Location X:{boi.playerLocation.playerX} Y:{boi.playerLocation.playerY}");
                        

                        SetPlayer();
                        DrawPlanet();
                        DrawEarth();
                        YouAreHere();

                        


                    }
                    catch (ArgumentOutOfRangeException) { Console.SetCursorPosition(boi.playerLocation.playerX, boi.playerLocation.playerY); }

                }


            }
        }
    }
}





