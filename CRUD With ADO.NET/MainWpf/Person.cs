using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWpf
{
    class Person
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Phone { get; set; }


        public Person()
        {

        }

        public Person(int id, string fname, string lname, int phone)
        {
            Id = id;
            FName = fname;
            LName = lname;
            Phone = phone;
        }

        public Person(string fname, string lname, int phone)
        {
            FName = fname;
            LName = lname;
            Phone = phone;
        }
    }

}
