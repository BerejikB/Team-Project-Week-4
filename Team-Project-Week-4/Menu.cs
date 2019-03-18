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
    
    public void StartMenu()

    {
        Console.Clear();
        Console.WriteLine("1) New Player");
            Console.WriteLine("2) Map Generator NOT IMPLIMENTED");
            Console.WriteLine("3) Load Player NOT IMPLIMENTED");
            Console.WriteLine("4) Start WORK IN PROGRESS");
            Console.WriteLine("5) Show Player Stats");
            Console.WriteLine("6) Quit");
            


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
                    StartMenu();
                }

                break;

            case 2:
                {
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
                    GameManager GM = new GameManager();
                    GM.GameRun();
                    StartMenu();
                }
                break;

            case 5:
                {
                    GameManager GM = new GameManager();
                    GM.PrintStat();
                    Console.ReadKey();
                    StartMenu();
                }

                break;

            default:

                StartMenu();
                break;
               
        }

    }

   




}








    

