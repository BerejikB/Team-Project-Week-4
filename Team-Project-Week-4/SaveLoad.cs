using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Team_Project_Week_4;
using System.Xml.Serialization;
using System.Xml.Linq;

using System.Xml;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;




public class xmlSaver
{

    public int? SaveSlotsetter = null;

    public int SaveSlot()
    {
        while (SaveSlotsetter == null)
        {
            try
            {
                Console.WriteLine($"Select Save Slot 1 {File.Exists("player1.xml")}");
                Console.WriteLine($"Select Save Slot 2 {File.Exists("player2.xml")}");
                Console.WriteLine($"Select Save Slot 3 {File.Exists("player3.xml")}");
                ConsoleKeyInfo userinputboi;
                userinputboi = Console.ReadKey(true);


                switch (userinputboi.Key)
                {
                    case ConsoleKey.D1:
                        {
                            SaveSlotsetter = 1;
                        }
                        break;
                    case ConsoleKey.D2:
                        {
                            SaveSlotsetter = 2;
                        }

                        break;
                    case ConsoleKey.D3:
                        {
                            SaveSlotsetter = 3;
                        }
                        break;
                }
            }
            catch (Exception) { Console.WriteLine("try again"); }
        }

        return (int)SaveSlotsetter;
    }

    public void WriteXML(Player playerStats)
    {
        if (File.Exists($"player{SaveSlotsetter}.xml"))
        {

            Console.WriteLine($"Are you sure you want to overwrite Save {SaveSlotsetter}?");

            ConsoleKeyInfo userinputboi;
            userinputboi = Console.ReadKey(true);


            switch (userinputboi.Key)
            {
                case ConsoleKey.Y:
                    {

                    }
                    break;
                case ConsoleKey.N:
                    {

                        SaveSlot();
                    }
                    break;
            }


        }



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

    public void WriteXMLInventory(Market PlayerInventory)
    {
            XmlSerializer writer = new XmlSerializer(typeof(Market));

            System.IO.StreamWriter file = new StreamWriter($"PlayerInventory{SaveSlot()}.xml");


            writer.Serialize(file, PlayerInventory);
            file.Close();
        
        
        Console.WriteLine("Inventory saved");
        Console.WriteLine();
       


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
                Console.WriteLine($"Select Save Slot 1 {File.Exists("player1.xml")}");
                Console.WriteLine($"Select Save Slot 2 {File.Exists("player2.xml")}");
                Console.WriteLine($"Select Save Slot 3 {File.Exists("player3.xml")}");
                ConsoleKeyInfo userinputboi;
                userinputboi = Console.ReadKey(true);


                switch (userinputboi.Key)
                {
                    case ConsoleKey.D1:
                        {
                            SaveSlotsetter = 1;
                        }
                        break;
                    case ConsoleKey.D2:
                        {
                            SaveSlotsetter = 2;
                        }

                        break;
                    case ConsoleKey.D3:
                        {
                            SaveSlotsetter = 3;
                        }
                        break;
                }
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
        Market NewMarket = new Market();
        List<Item> PlayerInventory = new List<Item>();
        List<Item> LoaderPlayerInventory = new List<Item>();
        XDocument xdoc = XDocument.Load($"PlayerInventory{SaveSlot()}.xml");
        
        LoaderPlayerInventory = (from lv1 in xdoc.Descendants("Item")
                              select new Item
                              {
                                  name = lv1.Element("name").Value,
                                  price = Convert.ToInt32(lv1.Element("price").Value),
                                  volume = Convert.ToInt32(lv1.Element("volume").Value),
                                  Playerquantity = Convert.ToInt32(lv1.Element("Playerquantity").Value),
                                  

                              }).ToList();

        return LoaderPlayerInventory;
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
        Shipo.fuelLevel = Convert.ToInt32(ShipStatus.SelectSingleNode("fuelLevel").InnerText);

        return Shipo;

    }


}



