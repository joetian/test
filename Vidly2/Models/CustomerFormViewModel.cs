using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class CustomerFormViewModel
    {
        // IList has Add, Delete etc method which IEnumerable only can foreach, here we do NOT need add/delete, so use IEnumerable
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}