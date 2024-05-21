using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
      User GetById(long id);
    }
}
