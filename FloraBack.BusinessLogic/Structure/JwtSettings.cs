using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraBack.BusinessLogic.Structure
{
    public static class JwtSettings
    {
        public const string Issuer = "FloraBackApi";
        public const string Audience = "FloraBackClients";
        public const string SecretKey = "tw_curs2026_super_secret_min_32_caractere!";
        public const int ExpireMinutes = 60;
    }
}
