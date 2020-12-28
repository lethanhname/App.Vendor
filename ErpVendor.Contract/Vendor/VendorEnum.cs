using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpVendor.Contract.Vendor
{
    public enum PartnerTypeEnum
    {
        [Display(Name = "Gold")]
        Gold,
        [Display(Name = "Silver")]
        Silver,
        [Display(Name = "Premium")]
        Premium
    }
    public enum DomainEnum
    {
        [Display(Name = "Business Solution")]
        BusinessSolution,
        [Display(Name = "Framework Service")]
        FrameworkService
    }
}
