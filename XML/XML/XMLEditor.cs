using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace XML
{
    class XMLEditor
    {
        bool programRunning;
        string input;
        XmlDocument xmlDoc;
        string filename;
        public XMLEditor()
        {
            xmlDoc = new XmlDocument();
            programRunning = true;
            LoadXML();
            StartLines();            
            while (programRunning == true)
            {                
                input = Console.ReadLine();
                input = input.ToLower();
                if (input.StartsWith("display"))
                {
                    Display();
                }
                if (input.StartsWith("question"))
                {
                    Question();
                }
                if (input.StartsWith("answer"))
                {
                    Answer();
                }
                if (input.StartsWith("exit"))
                {
                    Exit();
                }
            }
        }

        public void StartLines()
        {
            Console.WriteLine("XML Prototype");            
        }

        public void LoadXML()
        {            
            input = "F:\\Year 4\\Semester 5\\Game 410 - Project Management\\XML\\XML\\Example.xml";
            try
            {
                xmlDoc.Load(input);
                filename = input;
                Console.WriteLine("Loading Successful.");
            }
            catch
            {
                Console.WriteLine("IT FAILED");
            }

        }

        public void Display()
        {
            Console.WriteLine("");
            XmlTextReader reader = new XmlTextReader(filename);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine("<" + reader.Name + ">");
                    if (reader.HasAttributes)
                    {
                        for (int i = 0; i < reader.AttributeCount; i++)
                        {
                            Console.WriteLine("\tAttribute: " + reader.GetAttribute(i));
                        }
                    }
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine("\tValue: " + reader.Value);
                }
            }
        }

        public void Question()
        {
            Console.WriteLine("");
            XmlTextReader reader = new XmlTextReader(filename);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.HasAttributes)
                    {
                        for (int i = 0; i < reader.AttributeCount; i++)
                        {
                            if (reader.GetAttribute(i).Equals("1001"))
                            {
                                i++;
                                reader.MoveToAttribute(i);
                                Console.WriteLine(reader.Value);
                            }
                        }
                    }                 
                }               
            }
            input = Console.ReadLine();
            Console.WriteLine();           
        }

        public void Answer()
        {

        }
        public void Edit()
        {
            XmlTextReader reader = new XmlTextReader(filename);
            XmlTextReader reader2 = new XmlTextReader(filename);
            Console.WriteLine("\nCommands: \nadd - Add a pre-made entry to the XML file. \ndelete - Delete the pre-made entry to the XML file. \nedit - Edit an existing file to a new value");
            input = Console.ReadLine();

            if (input.StartsWith("delete"))
            {
                Console.WriteLine("\nPlease enter an attribute ID\n\nAttribute Choices:");
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.HasAttributes)
                        {
                            for (int i = 0; i < reader.AttributeCount; i++)
                            {
                                Console.WriteLine(reader.GetAttribute(i));
                            }
                        }
                    }
                }
                Console.WriteLine("");
                input = Console.ReadLine();
                while (reader2.Read())
                {
                    if (reader2.NodeType == XmlNodeType.Element)
                    {
                        if (reader2.HasAttributes)
                        {
                            for (int i = 0; i < reader2.AttributeCount; i++)
                            {
                                if (reader2.GetAttribute(i).Equals(input))
                                {
                                    XmlNode node = xmlDoc.SelectSingleNode("/Contact/ContactID");
                                    node.RemoveChild(node);
                                    //XmlNode node = xmlDoc.ReadNode(reader2.GetAttribute(i));
                                    //node.ParentNode.RemoveChild(node);
                                    xmlDoc.Save(filename);
                                }
                            }
                        }
                    }
                }





                /*if (input.StartsWith("delete"))
                {
                    Console.WriteLine("\nEnter the contact ID you wish to remove.\n");
                    input = Console.ReadLine();
                    if (reader.NodeType == XmlNodeType.Attribute)
                    {
                        //XmlNode node = filename.(input);
                        //node.RemoveAll();
                    }
                }*/

                if (input.StartsWith("edit"))
                {
                    Console.WriteLine("Select what ID you wish to edit.");
                    input = Console.ReadLine();
                    if (reader.NodeType == XmlNodeType.Attribute)
                    {
                        //XmlNode node = filename.StartsWith(selection);
                        Console.WriteLine("What will the new ID be?");
                        input = Console.ReadLine();
                        Console.WriteLine("What will the new first name be?");
                        input = Console.ReadLine();
                        Console.WriteLine("What will the new last name be?");
                        input = Console.ReadLine();
                    }
                }
            }
        }

        public void Exit()
        {
            programRunning = false;
        }
    }
}
