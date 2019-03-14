﻿using System;
using System.IO;
using Team_Project_Week_4;
using System.Xml;
using System.Xml.Serialization;
using Team_Project_Week_4;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public class TestPlayerAttribs
{
    public int playerSecurity = 5;       //chance to defend self
    public int playerSpeech = 5;        //Price multiplier
    public int playerMaintenance = 5;    //Likelyness to break 
    public int playerLuck = 5;          //likelieness subtracted from bad stuff, added to good stuff
    public int playerPiloting = 5;       //static distance multiplier
    public int pointsAvail = 7;
    public string FirstName;
    public string Profession;
    public string LastName;
}


public class TestPlayerMake
  {
    TestPlayerAttribs playerAttribs = new TestPlayerAttribs();
    
    SetAttribMenu makePlayerAttribs = new SetAttribMenu();
 
    public void TestPlayerMakerXML()
        {
        TestPlayerAttribs playerAttribs = new TestPlayerAttribs();
        

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
        makePlayerAttribs.SetSecurity();
        }

}

public class SkillTooLow : Exception
{
    
}

public class NoAtribPoints : Exception
{
}

public class SetAttribMenu
{
    TestPlayerAttribs playerAttribs = new TestPlayerAttribs();
 

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
        try {



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
        try {

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
        try {


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
        xmlHelper SaveFunct = new xmlHelper();

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
                { SaveFunct.WriteXML(); }
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

public class PlayerStats
{ 
    TestPlayerAttribs playerAttribs = new TestPlayerAttribs();


    


    
}












     
    

   








    //player.FirstName;
    //playerAttribs;
    //player.LastName;
    //player.Profession;
    //playerAttribs.playerSecurity;
    //playerAttribs.playerSpeech;
    //playerAttribs.playerMaintenance;
    //playerAttribs.playerLuck;
    //playerAttribs.playerPiloting;















   




   