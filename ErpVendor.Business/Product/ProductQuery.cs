using System;
using System.Linq;
using ErpVendor.Contract.Product;
using Microsoft.EntityFrameworkCore;
using App.CoreLib.EF;
using App.CoreLib.EF.Data;
using App.CoreLib.EF.Data.Repositories;

namespace App.Core.Security.Business
{

    public class ProductQuery : QueryBase<Product>, IProductQuery
    {
        public ProductQuery(IStorage context):base(context)
        {

        }
        protected override void DefaultSort(IQueryRequest request)
        {
                request.OrderColumn = nameof(Product.ProductName);
                request.SortDirection = "asc";
        }

        protected override IQueryable<Product> Define(IQueryRequest request)
        {
            var dbset = storageContext.Set<Product>().AsNoTracking();

            return dbset.Where(r => r.ProductName.Contains(request.SearchValue));
        }
    }
}