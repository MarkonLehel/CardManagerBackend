using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardManagerBackend.Enums
{
    public enum CardStatus
    {
        ACTIVE, INACTIVE, DISABLED, EXPIRED
    }
    public enum PaymentType
    {
        CURRENCY, FORINT, CREDIT
    }
}
