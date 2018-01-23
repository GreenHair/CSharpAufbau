using System;
using System.Xml;
using System.Xml.Schema;


namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			XmlReaderSettings readerSettings = new XmlReaderSettings();
			readerSettings.IgnoreWhitespace = true;
			readerSettings.IgnoreComments = true;
			readerSettings.ValidationType = ValidationType.Schema;
			readerSettings.Schemas.Add(null, @"..\..\Personen.xsd");
			readerSettings.ValidationEventHandler += ValidationCallback;

			XmlReader reader = XmlReader.Create(@"..\..\Personen.xml", readerSettings);
			try{
				while (reader.Read())
				{
					switch (reader.NodeType)
					{
						case XmlNodeType.XmlDeclaration:
							Console.WriteLine("{0,-20}<{1}>", "DEKLARATION", reader.Value);
							break;
						case XmlNodeType.CDATA:
							Console.WriteLine("{0,-20}{1}", "CDATA", reader.Value);
							break;
						case XmlNodeType.Whitespace:
							Console.WriteLine("{0,-20}", "WHITESPACE");
							break;
						case XmlNodeType.Comment:
							Console.WriteLine("{0,-20}<!--{1}-->", "COMMENT", reader.Value);
							break;
						case XmlNodeType.Element:
							if (reader.IsEmptyElement)
								Console.WriteLine("{0,-20}<{1} />", "EMPTY_ELEMENT", reader.Name);
							else
							{
								Console.WriteLine("{0,-20}<{1}>", "ELEMENT", reader.Name);
								// Prüfen, ob der Knoten Attribute hat
								if (reader.HasAttributes)
								{
									// Durch die Attribute navigieren
									while (reader.MoveToNextAttribute())
									{
										Console.WriteLine("{0,-20}{1}", "ATTRIBUT", reader.Name + "=" + reader.Value);
									}
								}
							}
							break;
						case XmlNodeType.EndElement:
							Console.WriteLine("{0,-20}</{1}>", "END_ELEMENT", reader.Name);
							break;
						case XmlNodeType.Text:
							Console.WriteLine("{0,-20}{1}", "TEXT", reader.Value);
							break;
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Validierung fehlgeschlagen.\n{0}", ex.Message);
			}
			reader.Close();
			Console.ReadLine();
		}

		static void ValidationCallback(object sender, ValidationEventArgs e)
		{			
      //throw e.Exception;
      Console.WriteLine(e.Message);
		}
	}
}
