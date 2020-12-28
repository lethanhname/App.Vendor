
using App.CoreLib.EF.Data;

namespace ErpVendor.Contract.Vendor
{
    public interface IVendorQuery : IQueryBase<Vendor>
    {

    }
    public class VendorQueryRequest : QueryRequestBase
    {
    }
    
}