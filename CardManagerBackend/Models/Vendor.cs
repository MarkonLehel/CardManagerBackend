using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardManagerBackend.Models
{
    public class Vendor
    {
        public int VendorID { get; set; }
        public string Name { get; set; }
        public string Addresses { get; set; }
        public string Contacts { get; set; }
    }
}
