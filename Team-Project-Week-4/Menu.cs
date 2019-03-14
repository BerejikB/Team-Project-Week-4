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
        
        
        TestPlayerMake playerMake = new TestPlayerMake();

        public void GameStart()
        {
            //SLFL.FileLoad();
            StartMenu();
        }

    public void StartMenu()

    {

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
                             break;

                             case 3:
                             break;
                default:
                StartMenu();
                break;

                          }

                 }
                
    }







    

