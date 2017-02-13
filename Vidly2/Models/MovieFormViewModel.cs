﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }

        public string Title()
        {
            if ((Movie == null) || (Movie.Id == 0))
            {
                return "New Movie";
            }
            else
            {
                return "Edit Movie";
            }
        }
    }
}