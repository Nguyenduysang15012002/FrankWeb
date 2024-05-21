using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.PermissionRepository
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DbContext context)
                : base(context)
        {

        }
        public Permission GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
