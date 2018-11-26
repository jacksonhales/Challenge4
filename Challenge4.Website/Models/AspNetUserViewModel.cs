using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge4.Website.Models
{
    public class AspNetUserViewModel
    {
        public List<AspNetUser> AspNetUsers { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public List<Game> Games { get; set; }
    }
}