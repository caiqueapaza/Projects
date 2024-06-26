﻿using System.Text;

namespace Course.Entities
{
    class Client
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime BirthDate{ get; set; }

        public Client()
        {
        }

        public Client(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
