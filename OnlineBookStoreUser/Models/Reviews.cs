using System;
using System.Collections.Generic;

namespace OnlineBookStoreUser.Models
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public string ReviewSubject { get; set; }
        public string ReviewMessage { get; set; }
    }
}
