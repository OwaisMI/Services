using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Services.Models.WorkModels
{
    public partial class Socials
    {
        public int SocialId { get; set; }
        public string SocialName { get; set; }
        public int CompanyId { get; set; }
        public string Url { get; set; }

        public virtual Companies Company { get; set; }
    }
}
