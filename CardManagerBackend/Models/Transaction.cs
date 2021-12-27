using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardManagerBackend.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public bool Finnished { get; set; }
        public long CardNumber { get; set; }
        public int VendorID { get; set; }
    }
}
