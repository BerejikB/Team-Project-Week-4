using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Project_Week_4
{


    public class GameManager
    {

        Menu mainmen = new Menu();
        xmlLoader playerStats = new xmlLoader();
        xmlSaver SaveGame = new xmlSaver();
        NewPlayer currentboi = new NewPlayer();
        public void GameStartMenu()
        { mainmen.StartMenu(); }

        public void LoadCurrentPlayer()
        {
            int savenum = mainmen.SaveSlot();
            playerStats.LoadXML(savenum);
        }

        public void GameRun()
        {
            Console.WriteLine("Game is running");
            Console.WriteLine("Press 1 to give self $1");
            int userinput = int.Parse(Console.ReadLine());
            if (userinput == 1) { currentboi.playerMoney += 1; }
            else { GameRun(); }

            SaveGame.WriteXML(currentboi);

        }
    }
}





