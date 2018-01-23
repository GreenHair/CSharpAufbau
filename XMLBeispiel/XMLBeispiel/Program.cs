using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLBeispiel
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create(@"");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.Element:
                        if (reader.IsEmptyElement)
                        {
                            Console.WriteLine("Leeres Element/Node " + reader.Name);                            

                        }
                        else
                        {
                            Console.WriteLine(reader.Name);
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    Console.WriteLine(reader.Name + "=" + reader.Value);
                                }
                            }

                        }
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
