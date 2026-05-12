using FloraBack.Domains.Entities.Address;
using FloraBack.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.User
{
    public class UserCreateDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public AddressData? DefaultAddress { get; set; }

        public PaymentMethods? DefaultPaymentMethod { get; set; }

        public DateTime DOB { get; set; }

        public GenderTypes Gender { get; set; }
    }
}
