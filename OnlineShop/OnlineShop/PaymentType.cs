﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class PaymentType 
    {
        private static int indexer = 0;

        public int PaymentType_Id { get; private set; }

        public string PaymentType_Name { get; set; }

        public PaymentType()
        {
            PaymentType_Id = indexer;
            indexer++;
        }

        public PaymentType(string name)
        {
            PaymentType_Name = name;
            PaymentType_Id = indexer;
            indexer++;
        }
    }
}
