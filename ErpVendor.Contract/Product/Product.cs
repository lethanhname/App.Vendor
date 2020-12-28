using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using App.CoreLib.EF.Data.Entity;

namespace ErpVendor.Contract.Product
{
    public class Product : EntityBase
    {
        [Display(Name = "Product Code *")]
        [Required]
        [StringLength(15)]
        public string ProductCode { get; set; }

        [Display(Name = "Product Name *")]
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Display(Name = "Sector")]
        [StringLength(15)]
        public ProductSectorEnum? ProductSector { get; set; }

        [Display(Name = "Provider *")]
        [StringLength(15)]
        public ProductProviderEnum? ProductProvider { get; set; }

    }
}
