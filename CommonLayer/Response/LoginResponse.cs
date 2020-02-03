using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class LoginResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
