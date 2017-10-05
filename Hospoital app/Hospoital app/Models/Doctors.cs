using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospoital_app.Models
{
    public class Doctors
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}