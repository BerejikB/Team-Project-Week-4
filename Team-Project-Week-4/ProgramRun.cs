using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;



namespace Team_Project_Week_4 { 

public class ProgramRun
{
        
        static void Main(string[] args)

        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            GameManager MainProgramRun = new GameManager();
                      
            System.Console.SetWindowSize(120, 30);   //set window size to almost full screen 
            //Console.BufferHeight = 32;
            //Console.BufferWidth = 122;


            MainProgramRun.StartMenu();
        }


       
}



}
