//using System;
//using System.IO;
//using Team_Project_Week_4;
//using System.Xml;
//using System.Xml.Serialization;
//using Team_Project_Week_4;

//public class Player
//{ 

//        TestPlayerAttribs playerAttribs = new TestPlayerAttribs();
//        TestPlayerStats player = new TestPlayerStats();
//         public string pfn = player.FirstName;
//         public string pln = player.LastName;
//        public string pp = Playermenu.player.Profession;
//         public int psec =  playerAttribs.playerSecurity;
//         public int psp = playerAttribs.playerSpeech;
//         public int pmain = playerAttribs.playerMaintenance;
//         public int plu = playerAttribs.playerLuck;
//        public int ppi = playerAttribs.playerPiloting;


// /// <summary>
///// Writes the given object instance to an XML file.
///// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
///// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [XmlIgnore] attribute.</para>
///// <para>Object type must have a parameterless constructor.</para>
///// </summary>
///// <typeparam name="T">The type of object being written to the file.</typeparam>
///// <param name="filePath">The file path to write the object instance to.</param>
///// <param name="objectToWrite">The object instance to write to the file.</param>
///// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>

//        public static void WriteToXmlFile<T>(string filePath, Player objectToWrite, bool append = false) where T : new()
//    {
//        TextWriter writer = null;
//        try
//        {
//            var serializer = new XmlSerializer(typeof(Player));
//            writer = new StreamWriter(filePath, append);
//            serializer.Serialize(writer, objectToWrite);
//        }
//        finally
//        {
//            if (writer != null)
//                writer.Close();
//        }
//    }

//}



////player.Profession;
////    playerAttribs.playerSecurity;
////    playerAttribs.playerSpeech;
////    playerAttribs.playerMaintenance;
////    playerAttribs.playerLuck;
////    playerAttribs.playerPiloting;

