using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var liste = new List<GeometricObject>();
            liste.Add(new Circle(100, -50, 75));
            liste.Add(new Rectangle(120, 46, 310, 210));
            liste.Add(new Circle(69, 70, -200));
            liste.Add(new Rectangle(58, 45, -10, -20));

            // Liste serialisieren
            SaveList(liste);

            // Liste deserialisieren
            var newList = GetListObjects();

            foreach (var item in newList)
            {
                Circle circle = item as Circle;
                if (circle != null)
                    Console.WriteLine("Circle: Radius = {0,-5}X={1,-5}Y={2}", circle.Radius, circle.XCoordinate, circle.XCoordinate);
                else
                {
                    Rectangle rect = item as Rectangle;
                    Console.WriteLine("Rectangle: Length = {0,-5}Width={1,-5}X={2,-5}Y={3}", rect.Length, rect.Width, rect.XCoordinate, rect.XCoordinate);
                }
            }
            Console.ReadLine();
        }

        public static void SaveList(IList<GeometricObject> elements)
        {
            FileStream stream = new FileStream(@"D:\GeoObjects.dat", FileMode.Create);
            BinaryFormatter binFormatter = new BinaryFormatter();
            
            binFormatter.Serialize(stream, elements);
            stream.Close();
        }


        public static List<GeometricObject> GetListObjects()
        {
            FileStream stream = new FileStream(@"D:\GeoObjects.dat", FileMode.Open);
            List<GeometricObject> oldList = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                oldList = (List<GeometricObject>)formatter.Deserialize(stream);
            }
            catch (SerializationException e)
            {
                // die Datei kann nicht deserialisiert werden
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                // Beim Versuch, die Datei zu öffnen, ist ein Fehler aufgetreten
                Console.WriteLine(e.Message);
            }
            return oldList;
        }
    }
}
