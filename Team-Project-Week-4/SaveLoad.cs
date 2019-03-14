using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Team_Project_Week_4;
using System.Xml.Serialization;


public class xmlHelper
{

    public void WriteXML(TestPlayerAttribs playerStats)
    {
        try
        {
            Console.WriteLine("Select a save slot");
            int userInput = int.Parse(Console.ReadLine());

            XmlSerializer writer =  new XmlSerializer(typeof(TestPlayerAttribs));

            System.IO.StreamWriter file = new StreamWriter($"Player{userInput}.xml");
            writer.Serialize(file, playerStats);


            file.Close();
        }
        catch (Exception) { WriteXML(playerStats); }
    }
//Read XML code example:

//public void Read(string fileName)
//{
//    XDocument doc = XDocument.Load(fileName);

//    foreach (XElement el in doc.Root.Elements())
//    {
//        Console.WriteLine("{0} {1}", el.Name, el.Attribute("id").Value);
//        Console.WriteLine("  Attributes:");
//        foreach (XAttribute attr in el.Attributes())
//            Console.WriteLine("    {0}", attr);
//        Console.WriteLine("  Elements:");

//        foreach (XElement element in el.Elements())
//            Console.WriteLine("    {0}: {1}", element.Name, element.Value);
//    }
//}
}
