using AppViralityTest.DAL.Core.Models;
using AppViralityTest.DAL.Core.Repositories;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViralityTest.DAL.Persistance.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppViralityTestDBEntities1 context) : base(context)
        {

        }
        public AppViralityTestDBEntities1 _context
        {
            get { return Context as AppViralityTestDBEntities1; }
        }
        public Product GetProductWithCategory(int Id)
        {
            return _context.Products.Include(q => q.Category).SingleOrDefault(q => q.Id == Id);
        }
    }
}
