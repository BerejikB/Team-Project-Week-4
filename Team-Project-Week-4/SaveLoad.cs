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

    public void WriteXML(Player playerStats)
    {

        try
        {
            XmlSerializer writer = new XmlSerializer(typeof(Player));

            System.IO.StreamWriter file = new StreamWriter($"Player{SaveSlot()}.xml");
            writer.Serialize(file, playerStats);


            file.Close();
        }
        catch (Exception) { WriteXML(playerStats); }
        Console.WriteLine("Character saved");
        Console.ReadKey();
        
    }

    //public void WriteXMLWorld(World WorldState)
    //{

    //    try
    //    {
    //        XmlSerializer writer = new XmlSerializer(typeof(Player));

    //        System.IO.StreamWriter file = new StreamWriter($"WorldState{SaveSlot()}.xml");
    //        writer.Serialize(file, WorldState);


    //        file.Close();
    //    }
    //    catch (Exception) { WriteXML(WorldState); }
    //    Console.WriteLine("World saved");
    //    Console.ReadKey();

    //}
}


public class xmlLoader
{
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

    public Player LoadXML(int saveSlot)
    {
        Player stats = new Player();

        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load($"player{saveSlot}.xml");
        var Player = doc.SelectSingleNode("Player");
        stats.playerSecurity = Convert.ToInt32(Player.SelectSingleNode("playerSecurity").InnerText);
        stats.playerSpeech = Convert.ToInt32(Player.SelectSingleNode("playerSpeech").InnerText);
        stats.playerMaintenance = Convert.ToInt32(Player.SelectSingleNode("playerMaintenance").InnerText);
        stats.playerLuck = Convert.ToInt32(Player.SelectSingleNode("playerLuck").InnerText);
        stats.playerPiloting = Convert.ToInt32(Player.SelectSingleNode("playerPiloting").InnerText);
        stats.FirstName = Convert.ToString(Player.SelectSingleNode("FirstName").InnerText);
        stats.Profession = Convert.ToString(Player.SelectSingleNode("Profession").InnerText);
        stats.LastName = Convert.ToString(Player.SelectSingleNode("LastName").InnerText);
        stats.playerMoney = Convert.ToDouble(Player.SelectSingleNode("playerMoney").InnerText);
        stats.isDead = bool.Parse(Convert.ToString(Player.SelectSingleNode("isDead").InnerText));

        return stats;
    }



    //public World LoadXMLWorld(int saveSlot)
    //{
    //    World WorldState = new World();

    //    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
    //    doc.Load($"WorldState{saveSlot}.xml");
    //    var WorldState = doc.SelectSingleNode("WorldState");
    //    WorldState.????????????????? = Convert.ToInt32(World.SelectSingleNode("???????????????").InnerText);
        

    //    return WorldState;
    //}

}
    
