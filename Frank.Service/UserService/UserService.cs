using Frank.Model.Entities;
using Frank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Frank.Repository.UserRepository;
using System.Linq.Dynamic;
using AutoMapper;
using PagedList;
using log4net;
using Frank.Service.Common;
using Frank.Repository.ProductRepository;


namespace Frank.Service.UserService
{
    public class UserService : EntityService<User>, IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;
        ILog _loger;
        IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork,
        IUserRepository UserRepository,
        ILog loger,
         IMapper mapper
        )
        : base(unitOfWork, UserRepository)
        {
            _unitOfWork = unitOfWork;          
            _loger = loger;
            _mapper = mapper;
        }
    }
}
