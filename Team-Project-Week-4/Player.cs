using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Team_Project_Week_4;



public class CurrentPlayer
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
    public double playerMoney = 250000;
    // public object ship  = NoobShip;
    //public object List<>(); = InventoryItems;

    public CurrentPlayer()
    { }

    
    public CurrentPlayer(xmlLoader LoadSave)
    {
        playerSpeech = LoadSave.playerSpeech;
        playerSecurity = LoadSave.playerSecurity;
        playerMaintenance = LoadSave.playerMaintenance;
        playerLuck = LoadSave.playerLuck;
        playerPiloting = LoadSave.playerPiloting;
        FirstName = LoadSave.FirstName;
        LastName = LoadSave.LastName;
        Profession = LoadSave.Profession;
       //playerShip = LoadSave.playerShip
       //playerInventory = LoadSave.playerInventory
        
       

    }



}