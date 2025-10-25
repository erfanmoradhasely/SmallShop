using System;
using System.Collections.Generic;
using System.Text;

namespace SmallShop.Contracts.Identity.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
