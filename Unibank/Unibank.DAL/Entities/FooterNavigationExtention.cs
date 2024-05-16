using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unibank.DAL.Entities
{
    public class FooterNavigationExtention : TimeStample
    {
        public string PageTitle { get; set; }
        public string PageUrl { get; set; }
        public int FooterNavigationId { get; set; }
        public FooterNavigation FooterNavigation { get; set; }
    }
}
