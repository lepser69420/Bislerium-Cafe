using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCoffee.Components.Data
{
    // User Class - use to store the actors/users of the application
    public class User
    {
        public int UserType { get; set; }
        [Required (ErrorMessage = "Username is required!")]
        public string UserName { get; set; }
        [Required (ErrorMessage = "Password is required!")]
        public string UserPassword { get; set; }

        public User() { 
        }

        public User(int type, string name, string password)
        {
            this.UserType = type;
            this.UserName = name;
            this.UserPassword = password;
        }
    }
}
