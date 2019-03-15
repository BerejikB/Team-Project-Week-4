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
    GameManager GM = new GameManager();
    public void WriteXML(NewPlayer playerStats)
    {
        try
        {

            XmlSerializer writer = new XmlSerializer(typeof(NewPlayer));

            System.IO.StreamWriter file = new StreamWriter($"Player{GM.SaveSlot()}.xml");
            writer.Serialize(file, playerStats);


            file.Close();
        }
        catch (Exception) { WriteXML(playerStats); }
        Console.WriteLine("Character created! Start the game!");
        
    }
}


public class xmlLoader
{
    public string FirstName;
    public string LastName;
    public double playerMoney;
    public string Profession;
    public int playerSecurity;
    public int playerSpeech;
    public int playerPiloting;
    public int playerLuck;
    public int playerMaintenance;
        
    public void LoadXML(int saveSlot)
    {

        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load($"player{saveSlot}.xml");
        var testPlayer = doc.SelectSingleNode("NewPlayer");
        playerSecurity = Convert.ToInt32(testPlayer.SelectSingleNode("playerSecurity").InnerText);
        playerSpeech = Convert.ToInt32(testPlayer.SelectSingleNode("playerSpeech").InnerText);
        playerMaintenance = Convert.ToInt32(testPlayer.SelectSingleNode("playerMaintenance").InnerText);
        playerLuck = Convert.ToInt32(testPlayer.SelectSingleNode("playerLuck").InnerText);
        playerPiloting = Convert.ToInt32(testPlayer.SelectSingleNode("playerPiloting").InnerText);
        FirstName = Convert.ToString(testPlayer.SelectSingleNode("FirstName").InnerText);
        Profession = Convert.ToString(testPlayer.SelectSingleNode("Profession").InnerText);
        LastName = Convert.ToString(testPlayer.SelectSingleNode("LastName").InnerText);
        playerMoney = Convert.ToDouble(testPlayer.SelectSingleNode("playerMoney").InnerText);



    }

}
    
