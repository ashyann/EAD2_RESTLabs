using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneBookWebServiceV1.Models;

namespace PhoneBookWebServiceV1.Controllers
{
    [RoutePrefix("phonebook")]
    public class PhonebookRowsController : ApiController
    {
        public List<PhonebookRow> phonerows;

        public PhonebookRowsController()
        {
            phonerows = new List<PhonebookRow>();
            phonerows.Add(new PhonebookRow(){Name="Jane Doe",Number="1234567890",Address="123 IT Tallaght"});
            phonerows.Add(new PhonebookRow(){Name="Joe Bloggs",Number="0987654321",Address="456 DIT"});
            phonerows.Add(new PhonebookRow(){Name="Ashleen Rath",Number="0860889861",Address="898 Rathcoole"});
        }
        
        [Route("number/{num}")]
        public IHttpActionResult GetNumber(String num)
        {
            var number = phonerows.FirstOrDefault(n=>n.Number.ToUpper() == num.ToUpper());
            
            if(number == null)
            {
                return NotFound();
            }

            return Ok(number);
        }


        //GET api/phonebookrow/name/
        //GET api/phonebookrow/number/

        [Route("name/{name}")]

        // GET phonebook/name/Jane Doe
        public IHttpActionResult GetPhoneBookRowName(String name)
        {
            //consruct upper case query match so case insensitive 
            var namequery = phonerows.Where(p => p.Name.ToUpper() == name.ToUpper());
            //if there isnt an entry
            if(namequery == null)
            {
                return NotFound();
            }
                //entry has been found, return a 200 OK
                return Ok(namequery);
        }
        
    }
}
