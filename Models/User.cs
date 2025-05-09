﻿using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace gp2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Transaction> Transactions { get; set; }

    }

}
