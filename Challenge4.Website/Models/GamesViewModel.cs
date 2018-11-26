using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge4.Website.Models
{
    public class GamesViewModel
    {

        public List<Game> Games { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public Game Game { get; set; }
    }
}