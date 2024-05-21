using Frank.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Repository.PermissionRepository
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Permission GetById(long id);
    }
}
