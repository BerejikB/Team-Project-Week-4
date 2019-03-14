using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Team_Project_Week_4;
using System.Xml.Serialization;




public class xmlSaver
{
    Menu MainMenu = new Menu();
    public void WriteXML(CurrentPlayer playerStats)
    {
        try
        {

            Menu MainMenu = new Menu();

            XmlSerializer writer = new XmlSerializer(typeof(CurrentPlayer));

            System.IO.StreamWriter file = new StreamWriter($"Player{MainMenu.SaveSlot()}.xml");
            writer.Serialize(file, playerStats);


            file.Close();
        }
        catch (Exception) { WriteXML(playerStats); }
        Console.WriteLine("Character created! Start the game!");
        MainMenu.StartMenu();
    }
}
/// <summary>
/// /HELP MAKE WORK HALP HALP HALP WHAT DO
/// </summary>

public class xmlLoader
{
    public int playerSecurity;       //chance to defend self
    public int playerSpeech ;        //Price multiplier
    public int playerMaintenance;    //Likelyness to break 
    public int playerLuck ;          //likelieness subtracted from bad stuff, added to good stuff
    public int playerPiloting ;       //static distance multiplier
    public string FirstName;
    public string Profession;
    public string LastName;
    public double playerMoney;

    public void LoadXML(int saveSlot)
    {

        xmlLoader PlayerValues = new xmlLoader();

        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load($"player{saveSlot}.xml");
        var testPlayer = doc.SelectSingleNode("CurrentPlayer");
        PlayerValues.playerSecurity = Convert.ToInt32(testPlayer.SelectSingleNode("playerSecurity").InnerText);
        PlayerValues.playerSpeech = Convert.ToInt32(testPlayer.SelectSingleNode("playerSpeech").InnerText);
        PlayerValues.playerMaintenance = Convert.ToInt32(testPlayer.SelectSingleNode("playerMaintenance").InnerText);
        PlayerValues.playerLuck = Convert.ToInt32(testPlayer.SelectSingleNode("playerLuck").InnerText);
        PlayerValues.playerPiloting = Convert.ToInt32(testPlayer.SelectSingleNode("playerPiloting").InnerText);
        PlayerValues.FirstName = Convert.ToString(testPlayer.SelectSingleNode("FirstName").InnerText);
        PlayerValues.Profession = Convert.ToString(testPlayer.SelectSingleNode("Profession").InnerText);
        PlayerValues.LastName = Convert.ToString(testPlayer.SelectSingleNode("LastName").InnerText);
        PlayerValues.playerMoney = Convert.ToDouble(testPlayer.SelectSingleNode("playerMoney").InnerText);







    }

}
    
