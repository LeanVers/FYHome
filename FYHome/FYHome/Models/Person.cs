using System;
using System.Collections.Generic;
using System.Text;

namespace FYHome.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthdayDate { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Passphrase { get; set; }
        public string KeyPassphrase { get; set; }
    }
}
