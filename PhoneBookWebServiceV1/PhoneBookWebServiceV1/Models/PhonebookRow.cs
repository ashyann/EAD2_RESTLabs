using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookWebServiceV1.Models
{
    public class PhonebookRow
    {
        public String Name {get; set;}

        //Unique Identifier
        public String Number { get; set; }

        public String Address { get; set; }
    }
}