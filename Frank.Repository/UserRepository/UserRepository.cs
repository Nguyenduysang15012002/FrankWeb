using Frank.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frank.Model.Entities;


namespace Frank.Repository.UserRepository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {

        }
        public User GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
