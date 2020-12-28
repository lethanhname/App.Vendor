using Microsoft.EntityFrameworkCore;
using App.CoreLib.EF.Data;
using ErpVendor.Business;
namespace ErpVendor.Web
{
    public class EntityRegistrar : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelBuilder) => EntityService.RegisterEntities(modelBuilder);
    }
}