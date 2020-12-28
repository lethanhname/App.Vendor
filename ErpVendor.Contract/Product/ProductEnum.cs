using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpVendor.Contract.Product
{
    public enum ProductSectorEnum
    {
        [Display(Name = "ERP")]
        ERP,
        [Display(Name = "CRM")]
        CRM,
        [Display(Name = "SCM")]
        SCM,
        [Display(Name = "Vertical Solution")]
        VS,
        [Display(Name = "Retail - POS")]
        POS
    }
    public enum ProductProviderEnum
    {
        [Display(Name = "Microsoft")]
        Microsoft,
        [Display(Name = "SAP")]
        SAP,
        [Display(Name = "Oracle")]
        Oracle,
        [Display(Name = "Odoo")]
        Odoo,
        [Display(Name = "Open Source")]
        OS
    }
}
