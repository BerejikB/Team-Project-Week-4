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
      
        Menu menu = new Menu();
        menu.GameStart();

    }


        public void MainRunLoop()
        {
            int run = 1;
            do { Console.WriteLine("GAME IS RUNNING"); }

            while (run == 1);

        }
}



}
