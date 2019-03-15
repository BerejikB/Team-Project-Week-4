using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Team_Project_Week_4;



public class NewPlayer
{
    public int playerSecurity  {get; set; }        //chance to defend self
    public int playerSpeech { get; set; }       //Price multiplier
    public int playerMaintenance { get; set; }    //Likelyness to break 
    public int playerLuck { get; set; }          //likelieness subtracted from bad stuff, added to good stuff
    public int playerPiloting { get; set; }       //static distance multiplier
    public int pointsAvail { get; set; }
    public string FirstName { get; set; }
    public string Profession { get; set; }
    public string LastName { get; set; }
    public double playerMoney { get; set; }
    // public object ship  = NoobShip;
    //public object List<>(); = InventoryItems;
}





    public class CurrentPlayer : NewPlayer
{
    GameManager GM = new GameManager();
    xmlLoader playerStats = new xmlLoader();

    
       
    public void printCurrentPlayer()
    {
        int savenum = GM.SaveSlot();

        playerStats.LoadXML(savenum);

        Console.WriteLine($"You are {playerStats.FirstName} {playerStats.LastName}, the {playerStats.Profession}");
        Console.WriteLine($"Your curent attributes are:");
        Console.WriteLine($"Wallet : ${playerStats.playerMoney}");
        Console.WriteLine($"Security : {playerStats.playerSecurity}");
        Console.WriteLine($"Speech : {playerStats.playerSpeech}");
        Console.WriteLine($"Maintenance : {playerStats.playerMaintenance}");
        Console.WriteLine($"Luck : {playerStats.playerLuck}");
        Console.WriteLine($"Piloting : {playerStats.playerPiloting}");
        Console.ReadKey();
        
    }

   

}





