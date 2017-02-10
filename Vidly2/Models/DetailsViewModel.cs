using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class DetailsViewModel
    {
        public Customer Customer { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}