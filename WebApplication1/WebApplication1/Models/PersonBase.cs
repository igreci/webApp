using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PersonBase
    {
        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je obavezno!")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        [Required(ErrorMessage = "Prezime je obavezno!")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail je obavezan!")]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Ime: {FirstName}\nPrezime: {LastName}\nE-mail: {Email}";
        }
    }
}