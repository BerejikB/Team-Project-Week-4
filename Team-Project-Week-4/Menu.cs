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

    ProgramRun RunGame = new ProgramRun();
        SetAttribMenu playerMake = new SetAttribMenu();
        MapGen mapGenerator = new MapGen();
        public void GameStart()
        {
            //SLFL.FileLoad();
            StartMenu();
        }

    public void StartMenu()

    {

            Console.WriteLine("1 New Player TEST");
            Console.WriteLine("2 Map Generator TEST");
            Console.WriteLine("3 Load Player TEST");
            Console.WriteLine("4 Start Game TEST");
            Console.WriteLine("5 TestPlayerInitalize");
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
                                   playerMake.TestPlayerMakerXML();
                                 }

                             break;
    
                             case 2:
                                 {
                                     mapGenerator.MakeMap();
                                 }
                             break;

                             case 3:
                             break;

                                case 4:
                                { RunGame.MainRunLoop(); }
                                break;

                            default:
                             StartMenu();
                            break;

                          }

                 }
                
    }







    

