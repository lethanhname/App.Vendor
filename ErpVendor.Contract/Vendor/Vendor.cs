using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using App.CoreLib.EF.Data.Entity;

namespace ErpVendor.Contract.Vendor
{
    public class Vendor : EntityBase
    {
        [Display(Name = "Vendor Code *")]
        [Required]
        [StringLength(15)]
        public string VendorCode { get; set; }

        [Display(Name = "Vendor Name *")]
        [Required]
        [StringLength(50)]
        public string VendorName { get; set; }

        [Display(Name = "Partner Type")]
        [StringLength(15)]
        public PartnerTypeEnum? PartnerType { get; set; }

        [Display(Name = "Domain *")]
        [Required]
        [StringLength(15)]
        public DomainEnum? Domain { get; set; }


        [Display(Name = "Website")]
        [StringLength(50)]
        public string Website { get; set; }
    }
}
