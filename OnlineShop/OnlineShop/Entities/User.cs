﻿using OnlineShop.BusinessLayer.Services;

namespace OnlineShop.Data.Entities
{
    public class User
    {

        public ulong INN { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public DateOnly UserBirthDate { get; set; }

        public string Address { get; set; }


        public User()
        {
            
        }

        public User( ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)
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
