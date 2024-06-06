﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    public class User
    {

        private ulong INN { get; set; }

        private string Name { get; set; }

        private string Surname { get; set; }

        private string PhoneNumber { get; set; }

        private DateOnly UserBirthDate { get; set; }

        private string Address { get; set; }


        public User()
        {
            
        }

        public User(ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)
        {
            INN = inn;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            UserBirthDate = userBirthDate;
            Address = address;
        }

        public override string ToString()
        {
            return $"INN:{this.INN} Name:{this.Name} Surname:{this.Surname} PhoneNumber:{this.PhoneNumber} BirthDate:{this.UserBirthDate} Address:{this.Address}";
        }

    }
}
