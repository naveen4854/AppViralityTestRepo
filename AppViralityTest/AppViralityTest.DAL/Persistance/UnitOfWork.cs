using AppViralityTest.DAL.Core;
using AppViralityTest.DAL.Core.Models;
using AppViralityTest.DAL.Core.Repositories;
using AppViralityTest.DAL.Persistance.Repositories;

namespace AppViralityTest.DAL.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppViralityTestDBEntities1 _context;

        public UnitOfWork()
        {
            _context = new AppViralityTestDBEntities1();
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
        }

        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
