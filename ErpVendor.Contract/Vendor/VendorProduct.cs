using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using App.CoreLib.EF.Data.Entity;

namespace ErpVendor.Contract.Vendor
{
    public class VendorProduct : EntityBase
    {
        [Display(Name = "Vendor Code * ")]
        [Required]
        [StringLength(15)]
        public string VendorCode { get; set; }

        [Display(Name = "Product Code * ")]
        [Required]
        [StringLength(15)]
        public string ProductCode { get; set; }
    }
}
