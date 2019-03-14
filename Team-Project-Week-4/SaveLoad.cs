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
    public void WriteXML(TestPlayerAttribs playerStats)
    {
        try
        {

            Menu MainMenu = new Menu();

            XmlSerializer writer = new XmlSerializer(typeof(TestPlayerAttribs));

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
    //public class xmlLoader
    //{
    //    Menu saveSlotSelect = new Menu();
    //    Player PlayerStatus = new Player();
    //    public void LoadXML()


    //    {
    //        XmlSerializer reader = new XmlSerializer(typeof(TestPlayerAttribs));
    //        System.IO.StreamReader file = new StreamReader($"Player{saveSlotSelect.SaveSlot()}.xml");
    //        reader.Serialize(file, PlayerStatus);
    //    }


    //}
 