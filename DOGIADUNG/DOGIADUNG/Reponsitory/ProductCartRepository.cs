using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface IProductCartRepository : IRepository< ProductCart, int>
    {
       
    }

    public class ProductCartRepository : EFRepository<ProductCart, int>, IProductCartRepository
    {
        public ProductCartRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
