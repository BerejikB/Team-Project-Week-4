using System;
using System.IO;
using Team_Project_Week_4;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SkillTooLow : Exception
{

}

public class NoAtribPoints : Exception
{
}

public class SetAttribMenu 
{


    
    World GameWorld = new World();

    Player playerAttribs;

    public SetAttribMenu(Player boi)
    {
        this.playerAttribs = boi;
        
    }
    Ship Shipo;
    public SetAttribMenu()
    {
        Shipo = new Ship(playerAttribs);
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
        playerAttribs.playerMoney = 250000;
        playerAttribs.pointsAvail = 7;
        playerAttribs.playerAge = 20;
       
        playerAttribs.isDead = false;


        Console.WriteLine("What is your name?");
        Console.WriteLine("First Name:");
        playerAttribs.FirstName = Console.ReadLine();
        Console.WriteLine("Last Name:");
        playerAttribs.LastName = Console.ReadLine();
        Console.WriteLine("What is your profession?");
        playerAttribs.Profession = Console.ReadLine();
        Console.WriteLine($"Are you sure your name is {playerAttribs.FirstName} {playerAttribs.LastName}, and you want to be a {playerAttribs.Profession}?");
        Console.WriteLine("Y/N");

        char playerIsSure = char.Parse(Console.ReadLine().ToLower());
        switch (playerIsSure)

        {

            case 'y':
                {
                    Console.WriteLine($"Welcome {playerAttribs.FirstName}, Time to begin your adveture.");
                }
                break;


            case 'n':
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

        Console.WriteLine();
        Console.ReadKey();
        SetSecurity();
    }

    public void SetSecurity()
    {
        
        try
        {

            Console.Clear();
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
                { SaveFunct.WriteXML(playerAttribs);

                  SaveFunct.WriteXMLWorld(GameWorld);
                  //SaveFunct.WriteXMLShip(Shipo);

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
