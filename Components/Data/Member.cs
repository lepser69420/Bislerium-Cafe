using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeCoffee.Components.Data
{
    // Member Class - use to store members of cafe
    public class Member
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        public Member()
        {

        }

        public Member(int id, string phone)
        {
            Id = id;
            PhoneNumber = phone;
        }
    }
}
