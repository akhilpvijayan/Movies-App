using System;
using System.Collections.Generic;

namespace MoviesAppproject.Models
{
    public partial class Users
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Userpassword { get; set; }
        public string Email { get; set; }
        public decimal? Contact { get; set; }
    }
}
