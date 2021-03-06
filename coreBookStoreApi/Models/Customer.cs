﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreBookStoreApi.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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



        public List<Order> Order { get; set; }
        public Review Review { get; set; }
    }
}
