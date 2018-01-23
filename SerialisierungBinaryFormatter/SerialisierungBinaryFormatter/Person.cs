using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisierungBinaryFormatter
{
    [Serializable()]
    class Person
    {
        string _name;
        int _alter;

        public int Alter
        {
            get
            {
                return _alter;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Person(string name, int alter)
        {
            _name = name;
            _alter = alter;
        }
    }
}
