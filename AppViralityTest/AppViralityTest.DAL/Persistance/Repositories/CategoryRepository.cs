using AppViralityTest.DAL.Core.Models;
using AppViralityTest.DAL.Core.Repositories;

namespace AppViralityTest.DAL.Persistance.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppViralityTestDBEntities1 context) : base(context)
        {

        }
    }
}
