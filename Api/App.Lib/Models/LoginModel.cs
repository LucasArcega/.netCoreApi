using System;
using System.Collections.Generic;
using System.Text;

namespace App.Lib.Models
{
    public class LoginModel
    {
        public bool Authenticated { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
    }
}
