using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Services.Models.WorkModels
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public int CityId { get; set; }
        public string POBox { get; set; }
        public string StreetNumber { get; set; }
        public int? ZipCode { get; set; }

        public virtual Cities City { get; set; }
    }
}
