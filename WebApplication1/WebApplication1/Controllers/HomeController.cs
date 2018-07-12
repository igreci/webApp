using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        

        // GET: Home/Index
        public ActionResult Index()
        {
            // input form
            return View("Index");
        }

        // POST: Home/Index
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                PersonFull person = new PersonFull();

                // Get base or full person
                var search = collection["Email"];
                var searchResult = DAL.API_Traffic.GetDataFromApi(search);

                if (searchResult != null)
                {
                    
                    JArray token = (JArray)searchResult;

                    foreach (var item in token)
                    {
                        string personString = JsonConvert.SerializeObject(item);
                        person = JsonConvert.DeserializeObject<PersonFull>(personString);
                    }
                }
                
                person.Email = collection["Email"];
                person.FirstName = collection["FirstName"];
                person.LastName = collection["LastName"];

                // if full person
                if (!string.IsNullOrWhiteSpace(person.FirstName) && !string.IsNullOrWhiteSpace(person.WebSite))
                {
                    DAL.DatabaseTraffic.SaveFullPerson(person);
                    DAL.MailTraffic.SendEmailFullPerson(person);
                }
                else
                {
                    DAL.DatabaseTraffic.SaveBasePerson(person);
                    DAL.MailTraffic.SendEmailBasePerson(person);
                }
                                
                return View("ThankYou");
            }
            catch(Exception)
            {
                return View();
            }
        }
        
    }
}
