using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{


    public class GameManager
    {
                
        GameRun GameLoop = new GameRun();

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

        public void PrintStat()
        {
            CurrentPlayer boi = new CurrentPlayer();
            boi.printCurrentPlayer();


        }


        public void GameStartMenu()
        { Menu mainmen = new Menu();
            mainmen.StartMenu(); }

        public void LoadCurrentPlayer()
        {
            xmlLoader playerStats = new xmlLoader();
            int savenum = SaveSlot();
            playerStats.LoadXML(savenum);
        }

        public void GameRun()
        {
            xmlSaver SaveGame = new xmlSaver();
            NewPlayer currentboi = new NewPlayer();
            GameLoop.RunLoop();
            SaveGame.WriteXML(currentboi);

        }
    }
}





