using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Services.Models.WorkModels
{
    public partial class BusinessActivity
    {
        public int BusinessId { get; set; }
        public string ActivityName { get; set; }
        public int CompanyId { get; set; }

        public virtual Companies Company { get; set; }
    }
}
