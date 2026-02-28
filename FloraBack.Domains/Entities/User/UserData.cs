using FloraBack.Domains.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.User
{
    public class UserData
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        //public string Contacts { get; set; }
        public DateTime DOB { get; set; }
        public GenderTypes Gender { get; set; }
    }
}
