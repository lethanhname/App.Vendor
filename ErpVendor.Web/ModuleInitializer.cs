using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using App.CoreLib.Module;
using App.Core.Security.Business;
using ErpVendor.Contract.Vendor;
using ErpVendor.Contract.Product;
using Microsoft.Extensions.Logging;
using App.CoreLib.EF.Data;

namespace ErpVendor.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductQuery, ProductQuery>();
            services.AddScoped<IVendorQuery, VendorQuery>();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {

            ILogger logger = applicationBuilder.ApplicationServices.GetService<ILoggerFactory>().CreateLogger("ErpVendor.Web");

            logger.LogInformation("seeding data to database");

            SeedData(applicationBuilder, logger);

        }

        private void SeedData(IApplicationBuilder applicationBuilder, ILogger logger)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var success = true;
                logger.LogInformation("seeding product to database");
                var productRepository = serviceScope.ServiceProvider.GetRequiredService<IRepository<Product>>();
                if (productRepository.Find("NAV") == null)
                {
                    productRepository.Add(new Product { ProductCode = "NAV", ProductName = "MS Dynamics NAV", ProductSector = ProductSectorEnum.ERP, ProductProvider = ProductProviderEnum.Microsoft, RowVersion = 1 });
                    productRepository.Add(new Product { ProductCode = "AX", ProductName = "MS Dynamics Axapta", ProductSector = ProductSectorEnum.ERP, ProductProvider = ProductProviderEnum.Microsoft, RowVersion = 1 });
                    productRepository.Add(new Product { ProductCode = "SAPB1", ProductName = "SAP B1", ProductSector = ProductSectorEnum.ERP, ProductProvider = ProductProviderEnum.SAP, RowVersion = 1 });
                    productRepository.Add(new Product { ProductCode = "SAPA1", ProductName = "SAP A1", ProductSector = ProductSectorEnum.ERP, ProductProvider = ProductProviderEnum.SAP, RowVersion = 1 });
                    productRepository.Add(new Product { ProductCode = "LS-RETAIL", ProductName = "LS Retail", ProductSector = ProductSectorEnum.POS, ProductProvider = null, RowVersion = 1 });
                    productRepository.Add(new Product { ProductCode = "CRM-D365", ProductName = "CRM D365 ", ProductSector = ProductSectorEnum.ERP, ProductProvider = ProductProviderEnum.Microsoft, RowVersion = 1 });
                    var result = productRepository.SaveChangesAsync().Result;
                    if (!result.Succeeded)
                    {
                        success = false;
                        logger.LogError(result.ToString());
                    }
                }

                logger.LogInformation("seeding vendor to database");
                var vendorRepository = serviceScope.ServiceProvider.GetRequiredService<IRepository<Vendor>>();
                if (vendorRepository.Find("NVW") == null)
                {
                    vendorRepository.Add(new Vendor { VendorCode = "NVW", VendorName = "Naviworld VN", PartnerType = PartnerTypeEnum.Gold, Domain = DomainEnum.BusinessSolution, RowVersion = 1 });
                    vendorRepository.Add(new Vendor { VendorCode = "NTK", VendorName = "Netika VN", PartnerType = null, Domain = DomainEnum.BusinessSolution, RowVersion = 1 });
                    vendorRepository.Add(new Vendor { VendorCode = "VTV", VendorName = "Votiva VN", PartnerType = PartnerTypeEnum.Gold, Domain = DomainEnum.BusinessSolution, RowVersion = 1 });
                    var result = vendorRepository.SaveChangesAsync().Result;
                    if (!result.Succeeded)
                    {
                        success = false;
                        logger.LogError(result.ToString());
                    }
                }
                if (success)
                {
                    logger.LogInformation("seeding vendor product to database");
                    var vendorProductRepository = serviceScope.ServiceProvider.GetRequiredService<IRepository<VendorProduct>>();
                    if (vendorProductRepository.Find("NVW", "NAV") == null)
                    {
                        vendorProductRepository.Add(new VendorProduct { VendorCode = "NVW", ProductCode = "NAV", RowVersion = 1 });
                        vendorProductRepository.Add(new VendorProduct { VendorCode = "NVW", ProductCode = "LS-RETAIL", RowVersion = 1 });

                        vendorProductRepository.Add(new VendorProduct { VendorCode = "NTK", ProductCode = "NAV", RowVersion = 1 });

                        vendorProductRepository.Add(new VendorProduct { VendorCode = "VTV", ProductCode = "AX", RowVersion = 1 });
                        vendorProductRepository.Add(new VendorProduct { VendorCode = "VTV", ProductCode = "CRM-D365", RowVersion = 1 });
                        var result = vendorProductRepository.SaveChangesAsync().Result;
                        if (!result.Succeeded)
                        {
                            success = false;
                            logger.LogError(result.ToString());
                        }
                    }
                }                
            }
        }

    }
}
