using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.mvc.crud.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        
        [DisplayNameAttribute("Họ")]
        public string FirstName { get; set; }
        public string? Gender { get; set; }
    }
}