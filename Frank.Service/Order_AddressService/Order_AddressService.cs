using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository;
using Frank.Repository.Order_AddressRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.Order_AddressService
{
    public class Order_AddressService : EntityService<Order_Address>, IOrder_AddressService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IOrder_AddressRepository _order_AddressRepository;
        public Order_AddressService(
            IUnitOfWork unitOfWork,
            IOrder_AddressRepository order_AddressRepository,
            IMapper mapper)
            : base(unitOfWork,order_AddressRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _order_AddressRepository = order_AddressRepository;
        }
    }
}
