using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Core.Contract.Security;
using App.CoreLib.EF.Data;
using Microsoft.EntityFrameworkCore;
using ErpVendor.Contract.Product;
using ErpVendor.Contract.Vendor;
using Microsoft.Extensions.Logging;

namespace ErpVendor.Web
{
    [Route("api/[controller]")]
    [ApiController]
    [Area(Constants.AreaName)]
    public class ErpApiController : ControllerBase
    {
        readonly ILogger<ErpApiController> _log;
        readonly IRepository<Product> _productRepos;
        readonly IRepository<Vendor> _vendorRepos;

        public ErpApiController(ILogger<ErpApiController> log, IRepository<Product> productRepos, IRepository<Vendor> vendorRepos)
        {
            _log = log;
            _productRepos = productRepos;
            _vendorRepos = vendorRepos;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetAllProduct()
        {
            var data = await this._productRepos.Query().ToListAsync();
            return new JsonResult(data);
        }

        [HttpGet("Vendors")]
        public async Task<IActionResult> GetAllVendor()
        {
            var data = await this._vendorRepos.Query().ToListAsync();
            return new JsonResult(data);
        }
    }
}