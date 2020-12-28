
using App.CoreLib.EF.Data;

namespace ErpVendor.Contract.Product
{
    public interface IProductQuery : IQueryBase<Product>
    {

    }
    public class ProductQueryRequest : QueryRequestBase
    {
    }
    
}