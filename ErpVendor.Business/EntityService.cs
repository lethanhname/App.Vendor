using ErpVendor.Contract.Product;
using ErpVendor.Contract.Vendor;
using Microsoft.EntityFrameworkCore;
using App.CoreLib.EF.Data;

namespace ErpVendor.Business
{
    public class EntityService
    {
        public static void RegisterEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(etb =>
              {
                  etb.HasKey(e => e.ProductCode);
                  etb.ToTable("Products");
              }
            );
            modelBuilder.Entity<Vendor>(etb =>
            {
                etb.HasKey(e => e.VendorCode);
                etb.ToTable("Vendors");
            }
            );
            modelBuilder.Entity<VendorProduct>(etb =>
            {
                etb.HasKey(e => new { e.VendorCode, e.ProductCode });
                etb.ToTable("VendorProducts");
            }
            );
        }
    }
}