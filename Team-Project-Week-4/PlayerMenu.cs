using System;
using System.IO;
using Team_Project_Week_4;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class SkillTooLow : Exception
{

}

public class NoAtribPoints : Exception
{
}

public class SetAttribMenu 
{        
    World GameWorld = new World();
    StoryMenus Story = new StoryMenus();
    List<Item> GameItems = new List<Item>();
    Market PlanetMarket = new Market();
    public int SaveSlotsetter = 1;
    Player playerAttribs;
    Ship NewShipo;

    public SetAttribMenu(Player boi, Ship shipo)
    {
        
        this.playerAttribs = boi;
        this.NewShipo = shipo;
    }


    public void SelectSaveSlot()
    {


        while (SaveSlotsetter == 0)
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
                            SaveSlotsetter = 1;
                        }
                        break;
                    case ConsoleKey.D2:
                        {
                            SaveSlotsetter = 2;
                        }

                        break;
                    case ConsoleKey.D3:
                        {
                            SaveSlotsetter = 3;
                        }
                        break;
                }
            }
            catch (Exception) { Console.WriteLine("try again"); }
        }

        






    }


    public void TestPlayerMakerXML()
    {
        
        GameWorld.PlanetGenerator();
        playerAttribs.playerLocation.playerX = GameWorld.EarthX;
        playerAttribs.playerLocation.playerY = GameWorld.EarthY;
        playerAttribs.playerSecurity = 5;
        playerAttribs.playerSpeech = 5;
        playerAttribs.playerMaintenance = 5;
        playerAttribs.playerPiloting = 5;
        playerAttribs.playerLuck = 5;
        playerAttribs.playerMoney = 2500;
        playerAttribs.pointsAvail = 7;
        playerAttribs.playerAge = 20;

        NewShipo.fuelLevel = 100;
        NewShipo.shipHealth = 8;
        NewShipo.engineLevel = 6;
        NewShipo.shipStatus = "In Working Order";
        NewShipo.warpVelocity = 6;

    playerAttribs.isDead = false;

        Console.Clear();
        Console.WriteLine("What is your name?");
        Console.WriteLine("First Name:");
        playerAttribs.FirstName = Console.ReadLine();
        Console.WriteLine("Last Name:");
        playerAttribs.LastName = Console.ReadLine();
        Console.WriteLine("What is your profession?");
        playerAttribs.Profession = Console.ReadLine();
        Console.WriteLine($"Are you sure your name is {playerAttribs.FirstName} {playerAttribs.LastName}, and you want to be a {playerAttribs.Profession}?");
        Console.WriteLine("Y/N");
        
        ConsoleKeyInfo playerIsSure;
        playerIsSure = Console.ReadKey(true);
        if (Console.KeyAvailable)
        {
            switch (playerIsSure.Key)

            {

                case ConsoleKey.Y:
                    {
                        Console.WriteLine($"Welcome {playerAttribs.FirstName}, Time to begin your adveture.");
                    }
                    break;


                case ConsoleKey.N:
                    {
                        TestPlayerMakerXML();
                    }
                    break;

                default:
                    {
                        TestPlayerMakerXML();
                    }
                    break;


            }
        }

        Console.WriteLine();
        Console.ReadKey();
        SetSecurity();
    }

    public void SetSecurity()
    {
        
        try
        {

            Console.Clear();
            Console.WriteLine($"Security will give you a bonus to defending yourself");
            Console.WriteLine($"Press Up Arrow to add a point, press Down Arrow to subract a point, and Right Arrow to go to next Attribute ");
            Console.WriteLine($"Press Left Arrow to go back ");
            Console.WriteLine($"Your Security Skill is {playerAttribs.playerSecurity} ");
            Console.WriteLine($"You have {playerAttribs.pointsAvail} points avaliable");
            var ch = Console.ReadKey(true).Key;
            switch (ch)
            {
                case ConsoleKey.UpArrow:
                    {

                        playerAttribs.playerSecurity++;

                        playerAttribs.pointsAvail--;
                        if (playerAttribs.pointsAvail < 0) throw new NoAtribPoints();
                        SetSecurity();
                    }
                    break;


                case ConsoleKey.DownArrow:
                    {


                        playerAttribs.playerSecurity--;

                        playerAttribs.pointsAvail++;
                        if (playerAttribs.playerSecurity <= 1) throw new SkillTooLow();
                        SetSecurity();
                    }

                    break;

                case ConsoleKey.RightArrow:
                    { SetSpeech(); }
                    break;

                default:
                    SetSecurity();
                    break;

            }

        }
        catch (NoAtribPoints) { Console.WriteLine("Out of attribute points"); playerAttribs.pointsAvail = 0; playerAttribs.playerSecurity--; SetSecurity(); }
        catch (SkillTooLow) { Console.WriteLine("Skill Too Low"); playerAttribs.playerSecurity = 1; playerAttribs.pointsAvail--; SetSecurity(); }


    }

    public void SetSpeech()
    {
        try
        {



            Console.Clear();
            Console.WriteLine($"Speech will give you a bonus to your buying and selling prices");
            Console.WriteLine($"Press Up Arrow to add a point, press Down Arrow to subract a point, and Right Arrow to go to next Attribute ");
            Console.WriteLine($"Press Left Arrow to go back ");
            Console.WriteLine($"Your Speech Skill is {playerAttribs.playerSpeech} ");
            Console.WriteLine($"You have {playerAttribs.pointsAvail} points avaliable");
            var ch = Console.ReadKey(false).Key;

            switch (ch)
            {
                case ConsoleKey.UpArrow:
                    {
                        playerAttribs.playerSpeech++;

                        playerAttribs.pointsAvail--;
                        if (playerAttribs.pointsAvail < 0) throw new NoAtribPoints();
                    }
                    SetSpeech();
                    break;


                case ConsoleKey.DownArrow:
                    {

                        playerAttribs.playerSpeech--;

                        playerAttribs.pointsAvail++;
                        if (playerAttribs.playerSpeech <= 1) throw new SkillTooLow();

                    }
                    SetSpeech();
                    break;

                case ConsoleKey.RightArrow:
                    {
                        SetMaintenance();
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    {
                        SetSecurity();
                    }
                    break;

                default:


                    SetSpeech();
                    break;
            }
        }

        catch (NoAtribPoints) { Console.WriteLine("Out of attribute points"); playerAttribs.pointsAvail = 0; playerAttribs.playerSpeech--; SetSpeech(); }
        catch (SkillTooLow) { Console.WriteLine("Skill Too Low"); playerAttribs.playerSpeech = 1; playerAttribs.pointsAvail--; SetSpeech(); }
    }

    public void SetMaintenance()
    {
        try
        {

            Console.Clear();
            Console.WriteLine($"Maintenance will give you a bonus to your ability to maintain your ship");
            Console.WriteLine($"Press Up Arrow to add a point, press Down Arrow to subract a point, and Right Arrow to go to next Attribute ");
            Console.WriteLine($"Press Left Arrow to go back ");
            Console.WriteLine($"Your Maintenance Skill is {playerAttribs.playerMaintenance} ");
            Console.WriteLine($"You have {playerAttribs.pointsAvail} points avaliable");

            var ch = Console.ReadKey(false).Key;

            switch (ch)
            {
                case ConsoleKey.UpArrow:
                    {
                        playerAttribs.playerMaintenance++;

                        playerAttribs.pointsAvail--;
                        if (playerAttribs.pointsAvail < 0) throw new NoAtribPoints();
                    }
                    SetMaintenance();
                    break;


                case ConsoleKey.DownArrow:
                    {
                        playerAttribs.playerMaintenance--;

                        playerAttribs.pointsAvail++;
                        if (playerAttribs.playerMaintenance <= 1) throw new SkillTooLow();
                    }
                    SetMaintenance();
                    break;

                case ConsoleKey.RightArrow:
                    { SetLuck(); }
                    break;
                case ConsoleKey.LeftArrow:
                    { SetSpeech(); }
                    break;

                default:
                    SetMaintenance();
                    break;

            }

        }
        catch (NoAtribPoints) { Console.WriteLine("Out of attribute points"); playerAttribs.pointsAvail = 0; playerAttribs.playerMaintenance--; SetMaintenance(); }
        catch (SkillTooLow) { Console.WriteLine("Skill Too Low"); playerAttribs.playerMaintenance = 1; playerAttribs.pointsAvail--; SetMaintenance(); }
    }

    public void SetLuck()
    {
        try
        {

            Console.Clear();
            Console.WriteLine("Luck will make good things more likley to happen to you");
            Console.WriteLine($"Press Up Arrow to add a point, press Down Arrow to subract a point, and Right Arrow to go to next Attribute ");
            Console.WriteLine($"Press Left Arrow to go back ");
            Console.WriteLine($"Your Luck Skill is {playerAttribs.playerLuck} ");
            Console.WriteLine($"You have {playerAttribs.pointsAvail} points avaliable");
            var ch = Console.ReadKey(true).Key;
            switch (ch)
            {
                case ConsoleKey.UpArrow:
                    {

                        playerAttribs.playerLuck++;

                        playerAttribs.pointsAvail--;
                        if (playerAttribs.pointsAvail < 0) throw new NoAtribPoints();
                        SetLuck();
                    }
                    break;


                case ConsoleKey.DownArrow:
                    {


                        playerAttribs.playerLuck--;

                        playerAttribs.pointsAvail++;
                        if (playerAttribs.playerLuck <= 1) throw new SkillTooLow();
                        SetLuck();
                    }

                    break;

                case ConsoleKey.RightArrow:
                    { SetPiloting(); }
                    break;
                case ConsoleKey.LeftArrow:
                    { SetMaintenance(); }
                    break;

                default:
                    SetLuck();
                    break;

            }

        }
        catch (NoAtribPoints) { Console.WriteLine("Out of attribute points"); playerAttribs.pointsAvail = 0; playerAttribs.playerLuck--; SetLuck(); }
        catch (SkillTooLow) { Console.WriteLine("Skill Too Low"); playerAttribs.playerLuck = 1; playerAttribs.pointsAvail--; SetLuck(); }


    }

    public void SetPiloting()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Piloting will give you a bonus to how fast you travel");
            Console.WriteLine($"Press Up Arrow to add a point, press Down Arrow to subract a point, and Right Arrow to go to FINISH ");
            Console.WriteLine($"Press Left Arrow to go back ");
            Console.WriteLine($"Your Piloting Skill is {playerAttribs.playerPiloting} ");
            Console.WriteLine($"You have {playerAttribs.pointsAvail} points avaliable");

            var ch = Console.ReadKey(false).Key;


            switch (ch)
            {
                case ConsoleKey.UpArrow:
                    {
                        playerAttribs.playerPiloting++;

                        playerAttribs.pointsAvail--;
                        if (playerAttribs.pointsAvail < 0) throw new NoAtribPoints();
                    }
                    SetPiloting();
                    break;


                case ConsoleKey.DownArrow:
                    {
                        playerAttribs.playerPiloting--;

                        playerAttribs.pointsAvail++;
                        if (playerAttribs.playerPiloting <= 1) throw new SkillTooLow();

                    }
                    SetPiloting();
                    break;

                case ConsoleKey.RightArrow:
                    { Review(); }
                    break;
                case ConsoleKey.LeftArrow:
                    { SetLuck(); }
                    break;


                default:
                    SetPiloting();
                    break;

            }

        }
        catch (NoAtribPoints) { Console.WriteLine("Out of attribute points"); playerAttribs.pointsAvail = 0; playerAttribs.playerPiloting--; SetPiloting(); }
        catch (SkillTooLow) { Console.WriteLine("Skill Too Low"); playerAttribs.playerPiloting = 1; playerAttribs.pointsAvail--; SetPiloting(); }

    }

    public void Review()
    {
        xmlSaver SaveFunct = new xmlSaver();

        Console.Clear();

        Console.WriteLine($"You are {playerAttribs.FirstName} {playerAttribs.LastName}, the {playerAttribs.Profession}");
        Console.WriteLine($"Your curent attributes are:");
        Console.WriteLine($"Security : {playerAttribs.playerSecurity}");
        Console.WriteLine($"Speech : {playerAttribs.playerSpeech}");
        Console.WriteLine($"Maintenance : {playerAttribs.playerMaintenance}");
        Console.WriteLine($"Luck : {playerAttribs.playerLuck}");
        Console.WriteLine($"Piloting : {playerAttribs.playerPiloting}");
        Console.WriteLine($"Are you sure this information is correct? Y/N");
        char userInput = 'f';
        try { userInput = char.Parse(Console.ReadLine().ToLower()); } catch (Exception) { Console.WriteLine("Try Again"); }

        switch (userInput)
        {
            case 'y':
                {

                    if (File.Exists($"player{SaveSlotsetter}.xml"))
                    {

                        Console.WriteLine($"Are you sure you want to overwrite Save {SaveSlotsetter}?");

                        ConsoleKeyInfo userinputboi;
                        userinputboi = Console.ReadKey(true);


                        switch (userinputboi.Key)
                        {
                            case ConsoleKey.Y:
                                {
                                    SaveFunct.WriteXML(SaveSlotsetter, playerAttribs);
                                    SaveFunct.WriteXMLWorld(SaveSlotsetter, GameWorld);
                                    SaveFunct.WriteXMLShip(SaveSlotsetter, NewShipo);
                                    SaveFunct.WriteXMLInventory(SaveSlotsetter, PlanetMarket);
                                    Story.StartGameInterView(playerAttribs.FirstName, playerAttribs.Profession, playerAttribs.playerMoney);
                                }
                                break;
                            case ConsoleKey.N:
                                {

                                    Review();
                                }
                                break;
                        }



                    }
                    else
                    {
                        SaveFunct.WriteXML(SaveSlotsetter, playerAttribs);
                        SaveFunct.WriteXMLWorld(SaveSlotsetter, GameWorld);
                        SaveFunct.WriteXMLShip(SaveSlotsetter, NewShipo);
                        SaveFunct.WriteXMLInventory(SaveSlotsetter, PlanetMarket);
                        Story.StartGameInterView(playerAttribs.FirstName, playerAttribs.Profession, playerAttribs.playerMoney);
                    }
                }
                break;
            case 'n':
                { SetPiloting(); }
                break;
            default:
                Review();
                break;

        }

    }

    

}
