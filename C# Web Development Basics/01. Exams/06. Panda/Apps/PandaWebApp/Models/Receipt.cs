using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public decimal Free { get; set; }

        public DateTime IssuedOn  { get; set; }

        public int RecipientId { get; set; }

        public User Recipient { get; set; }

        public int PackageId { get; set; }

        public Package Package { get; set; }
    }
}
