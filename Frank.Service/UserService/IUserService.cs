using Frank.Model.Entities;
using Frank.Service.Common;
using Frank.Service.UserService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.UserService
{
    public interface IUserService:IEntityService<User>
    {
        Task<UserDto> GetByUserName(string username);
    }
}
