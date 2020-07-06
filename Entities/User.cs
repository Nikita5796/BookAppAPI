using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoAuthApp.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int Contact { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int PostalCode { get; set; }

        public string Token { get; set; }
    }
}
