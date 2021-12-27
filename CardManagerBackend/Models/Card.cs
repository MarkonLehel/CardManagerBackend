using CardManagerBackend.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardManagerBackend.Models
{
    public class Card
    {
        public int CardID { get; set; }
        public int UserID { get; set; }
        public long CardNumber { get; set; }
        public bool Valid { get; set; }
        public CardStatus State { get; set; }
        public PaymentType CardType { get; set; }
        public string CurrencyType { get; set; }

    }

    
}
