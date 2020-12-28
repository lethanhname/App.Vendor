using System;
using System.Linq;
using ErpVendor.Contract.Vendor;
using Microsoft.EntityFrameworkCore;
using App.CoreLib.EF;
using App.CoreLib.EF.Data;
using App.CoreLib.EF.Data.Repositories;

namespace App.Core.Security.Business
{

    public class VendorQuery : QueryBase<Vendor>, IVendorQuery
    {
        public VendorQuery(IStorage context):base(context)
        {

        }
        protected override void DefaultSort(IQueryRequest request)
        {
                request.OrderColumn = nameof(Vendor.VendorName);
                request.SortDirection = "asc";
        }

        protected override IQueryable<Vendor> Define(IQueryRequest request)
        {
            var dbset = storageContext.Set<Vendor>().AsNoTracking();

            return dbset.Where(r => r.VendorName.Contains(request.SearchValue));
        }
    }
}