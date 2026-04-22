using FloraBack.Domains.Enums;
using FloraBack.Domains.Entities.Refs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloraBack.Domains.Entities.Address;

namespace FloraBack.Domains.Entities.User
{
    public class UserData : SharedFields
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public AddressData DefaultAddress { get; set; }
        public PaymentMethods DefaultPM { get; set; }
        public DateTime DOB { get; set; }
        public GenderTypes Gender { get; set; }
        public bool IsActive { get; set; } //unhandled yet
    }
}
