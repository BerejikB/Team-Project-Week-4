using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Team_Project_Week_4;
using System.Xml.Serialization;
using System.Xml.Linq;



public class xmlSaver
{

    public int? SaveSlotsetter = null;

    public int SaveSlot()
    {
        while (SaveSlotsetter == null)
        {
            try
            {
                Console.WriteLine("Select Save Slot");
                SaveSlotsetter = int.Parse(Console.ReadLine());
            }
            catch (Exception) { Console.WriteLine("try again"); }
        }

        return (int)SaveSlotsetter;
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
        Console.WriteLine();

    }

    public void WriteXMLWorld(World WorldState)
    {
        try
        {
            XmlSerializer writer = new XmlSerializer(typeof(World));

            System.IO.StreamWriter file = new StreamWriter($"WorldState{SaveSlot()}.xml");


            writer.Serialize(file, WorldState);
            file.Close();
        }
        catch (Exception) { WriteXMLWorld(WorldState); }
        Console.WriteLine("World saved");
        Console.WriteLine();
        Console.ReadKey();


    }

    public void WriteXMLShip(Ship Shipo)
    {
        //try
        //{
        XmlSerializer writer = new XmlSerializer(typeof(Ship));

        System.IO.StreamWriter file = new StreamWriter($"Ship{SaveSlot()}.xml");
        writer.Serialize(file, Shipo);
        file.Close();
        // }
        //catch (Exception) { WriteXMLShip(Ship); }
        Console.WriteLine("Ship saved");
        Console.WriteLine();

    }


    public void WriteXMLInventory(Item PlayerInventory)
    {
        try
        {
            XmlSerializer writer = new XmlSerializer(typeof(Item));

            System.IO.StreamWriter file = new StreamWriter($"PlayerInventory{SaveSlot()}.xml");


            writer.Serialize(file, PlayerInventory);
            file.Close();
        }
        catch (Exception) { WriteXMLInventory(PlayerInventory); }
        Console.WriteLine("World saved");
        Console.WriteLine();
        Console.ReadKey();


    }


}


public class xmlLoader
{
    public int? SaveSlotsetter = null;

    public int SaveSlot()
    {
        while (SaveSlotsetter == null)
        {
            try
            {
                Console.WriteLine("Select Save Slot");
                SaveSlotsetter = int.Parse(Console.ReadLine());
            }
            catch (Exception) { Console.WriteLine("try again"); }
        }

        return (int)SaveSlotsetter;
    }

    public Player LoadXML(int SaveSlotsetter)
    {
        Player stats = new Player();

        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load($"player{SaveSlot()}.xml");
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
        stats.playerAge = Convert.ToDouble(Player.SelectSingleNode("playerAge").InnerText);
        stats.playerLocation.playerX = Convert.ToInt32(Player.SelectSingleNode("playerX").InnerText);
        stats.playerLocation.playerY = Convert.ToInt32(Player.SelectSingleNode("playerY").InnerText);

        return stats;
    }

    public World LoadXMLWorld(int SaveSlotsetter)
    {
        World WorldState = new World();
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load($"WorldState{SaveSlot()}.xml");
        var EarthStatus = doc.SelectSingleNode("World");
        
        WorldState.EarthX = Convert.ToInt32(EarthStatus.SelectSingleNode("EarthX").InnerText);
        WorldState.EarthY = Convert.ToInt32(EarthStatus.SelectSingleNode("EarthY").InnerText);


        return WorldState;

    }

    public List<PlanetGen> LoadXMLPlanets(int SaveSlotsetter)
    {
        
        List<PlanetGen> Planets = new List<PlanetGen>();

        XDocument xdoc = XDocument.Load($"WorldState{SaveSlot()}.xml");

        List<PlanetGen> Planet = (from lv1 in xdoc.Descendants("PlanetGen")
                                   select new PlanetGen
                                   {
                                       name = lv1.Element("name").Value,
                                       valueMultiplier = Convert.ToDouble(lv1.Element("valueMultiplier").Value),
                                       locy = Convert.ToInt32(lv1.Element("locy").Value),
                                       locx = Convert.ToInt32(lv1.Element("locx").Value),
                                       economy = Convert.ToString(lv1.Element("economy").Value),

                                   }).ToList();

        return Planet;

    }

   public List<Item> LoadXMLInventory(int SaveSlotsetter)
   {
        List<Item> PlayerInventory = new List<Item>();
    
        XDocument xdoc = XDocument.Load($"PlayerInventory{SaveSlot()}.xml");

        List<Item> PlayerInventoryLoaded = (from lv1 in xdoc.Descendants("Market")
                              select new Item
                              {
                                  name = lv1.Element("name").Value,
                                  price = Convert.ToInt32(lv1.Element("price").Value),
                                  volume = Convert.ToInt32(lv1.Element("volume").Value),
                                  Playerquantity = Convert.ToInt32(lv1.Element("Playerquantity").Value),
                                  

                              }).ToList();

        return PlayerInventory;
    }


    public Ship LoadXMLShip(int SaveSlotsetter)
    {
        Player boi = LoadXML(SaveSlotsetter);
        Ship Shipo = new Ship();
        Shipo.boi = boi;

        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load($"Ship{SaveSlot()}.xml");
        var ShipStatus = doc.SelectSingleNode("Ship");

        Shipo.shipHealth = Convert.ToInt32(ShipStatus.SelectSingleNode("shipHealth").InnerText);
        Shipo.shipStatus = Convert.ToString(ShipStatus.SelectSingleNode("shipStatus").InnerText);
        Shipo.engineLevel = Convert.ToInt32(ShipStatus.SelectSingleNode("engineLevel").InnerText);


        return Shipo;

    }


}



