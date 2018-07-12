using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PersonFull : PersonBase
    {
        public string WebSite { get; set; }
        public string Phone { get; set; }

        public IAddress Address { get; set; }

        public PersonFull()
        {
            Address = new Address();
        }

        public override string ToString()
        {
            return $"Ime: {FirstName}\nPrezime: {LastName}\nE-mail: {Email}\nWeb: {WebSite}\nPhone: {Phone}" + 
                    $"\nAdresa:\n\tUlica: {Address.Street}\n\tStan: {Address.Suite}\n\tGrad: {Address.City}\n\tPoštabski broj: {Address.ZipCode}";
        }
    }
}