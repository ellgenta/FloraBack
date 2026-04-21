using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        Confirmed = 1,
        Canceled = 2,
        Shipping = 3,
        Delievered = 4,
    }
}
