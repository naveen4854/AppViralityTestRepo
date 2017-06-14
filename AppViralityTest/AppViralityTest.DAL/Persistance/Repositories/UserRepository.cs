using AppViralityTest.DAL.Core.Models;
using AppViralityTest.DAL.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppViralityTest.DAL.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppViralityTestDBEntities1 context) : base(context)
        {
        }
    }
}
