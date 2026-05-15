using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.Domains.Models.Base
{
    public class ResponseAction
    {
        public int Id { get; set; }

        public bool IsSuccess { get; set; } 

        public string Message { get; set; }

    }
}
