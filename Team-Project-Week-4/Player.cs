using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Team_Project_Week_4;





public class Player
{
       
    public int playerSecurity;  //chance to defend self
    public int playerSpeech;       //Price multiplier
    public int playerMaintenance;     //Likelyness to break 
    public int playerLuck;           //likelieness subtracted from bad stuff, added to good stuff
    public int playerPiloting;      //static distance multiplier
    public int pointsAvail;
    public string FirstName;
    public string Profession;
    public string LastName;
    public double playerMoney;
    public bool isDead;





    //Attribute Multipliers, add to base values later
    public double PlayerPriceMultSell()
    {
        double mult = playerSpeech * 0.05;
        return mult;
    }
    public double PlayerPriceMultBuy()
    {
        double mult = playerSpeech * 0.05;
        return mult;
    }
    public double PlayerSecMultiplier()
    {
        double mult = playerSecurity * 0.05;
        return mult;
    }



}
