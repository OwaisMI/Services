using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Services.Models.WorkModels
{
    public partial class Companies
    {
        public Companies()
        {
            BusinessActivtiy = new HashSet<BusinessActivity>();
            Socials = new HashSet<Socials>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int Number { get; set; }
        public string Branch { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BusinessActivity> BusinessActivtiy { get; set; }
        public virtual ICollection<Socials> Socials { get; set; }
    }
}
