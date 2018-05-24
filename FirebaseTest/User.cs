using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseConsole
{
    class User
    {
        //public string Uid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User(string Name, string Surname)
        {
            //this.Uid = Uid;
            this.Name = Name;
            this.Surname = Surname;
        }
    }
}
