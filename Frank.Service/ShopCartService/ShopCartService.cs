using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository.ProductRepository;
using Frank.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frank.Repository.ShopCartRepository;

namespace Frank.Service.ShopCartService
{
    public class ShopCartService : EntityService<ShopCart>, IShopCartService
    {
        IUnitOfWork _unitOfWork;
        IShopCartRepository _shopcartRepository;
        ILog _loger;
        IMapper _mapper;
        public ShopCartService(IUnitOfWork unitOfWork,
         IShopCartRepository ShopCartRepository,
         ILog loger,
         IMapper mapper
        )
        : base(unitOfWork, ShopCartRepository)
        {
            _unitOfWork = unitOfWork;
            _shopcartRepository = ShopCartRepository;
            _loger = loger;
            _mapper = mapper;
        }
    }
}
