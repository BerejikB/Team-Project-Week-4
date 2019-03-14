using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Team_Project_Week_4;




public class Menu 
    {

    //ProgramRun RunGame = new ProgramRun();
        
        MapGen mapGenerator = new MapGen();
        xmlLoader LoadPlayer = new xmlLoader();

    
    public void GameStart()
        {
           StartMenu();
        }

    public void StartMenu()

    {
            Console.WriteLine("1 New Player");
            Console.WriteLine("2 Map Generator TEST");
            Console.WriteLine("3 Load Player TEST");
            Console.WriteLine("4 Start Game TEST");
            Console.WriteLine("5 Show Player Stats");
            Console.WriteLine("1 TestPlayerInitalize");
            Console.WriteLine("1 TestPlayerInitalize");


        //User input for main menu
        int mainMenuSelect = 0;
        try
        {
            mainMenuSelect = int.Parse(Console.ReadLine());
        }
        catch (Exception){ Console.WriteLine("try again"); }


        switch (mainMenuSelect)
        {
            case 1:
                {
                    SetAttribMenu NewPlayer = new SetAttribMenu();
                    NewPlayer.TestPlayerMakerXML();
                }

                break;

            case 2:
                {
                    mapGenerator.MakeMap();
                }
                break;

            case 3:
                {
                    LoadPlayer.LoadXML(SaveSlot());
                    StartMenu();
                }
                break;
            case 4:
                {
                    SaveSlot();
                    Console.WriteLine($"Slot{SaveSlot()}Selected");
                    
                   // RunGame.MainRunLoop();
                }
                break;

            case 5:
                {
                    LoadPlayer.LoadXML(SaveSlot());

                    
                    PrintStats();



                }
                break;

            default:

                StartMenu();
                break;

        }

    }

    public int SaveSlot()
    {
        int saveSlot = 0;
        try
        {
            Console.WriteLine("Select Save Slot");
            saveSlot = int.Parse(Console.ReadLine());
            return saveSlot;
        }
        catch (Exception) { Console.WriteLine("try again"); }
        return saveSlot;


    }


    public void PrintStats()
    { }

    public void PrintStats(xmlLoader LoadSave)
    {
        Console.WriteLine($"  {LoadSave.playerSpeech} ");
        Console.WriteLine($"  {LoadSave.playerSecurity} ");
        Console.WriteLine($"  { LoadSave.playerMaintenance} ");
        Console.WriteLine($"  {LoadSave.playerLuck} ");
        Console.WriteLine($"  {LoadSave.playerPiloting} ");
        Console.WriteLine($"  {LoadSave.FirstName} ");
        Console.WriteLine($"  {LoadSave.LastName} ");
        Console.WriteLine($"  {LoadSave.Profession} ");
        Console.ReadKey();
        Console.WriteLine();
        StartMenu();


    }
}








    

