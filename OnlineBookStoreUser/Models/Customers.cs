﻿using System;
using System.Collections.Generic;

namespace OnlineBookStoreUser.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Address { get; set; }
        public long ZipCode { get; set; }
        public long Contact { get; set; }
        public int? ReviewId { get; set; }

        public Reviews Review { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
