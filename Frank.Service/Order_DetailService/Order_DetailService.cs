using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository;
using Frank.Repository.Order_DetailRepository;
using Frank.Repository.OrderRepository;
using Frank.Service.Order_DetailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.Order_AddressService
{
    public class Order_DetailService : EntityService<Order_Detail>, IOrder_DetailService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IOrder_DetailRepository _order_detailRepository;
        IOrderRepository _orderRepository;
        public Order_DetailService(
            IUnitOfWork unitOfWork,
            IOrder_DetailRepository order_DetailRepository,
            IOrderRepository orderRepository,
            IMapper mapper)
            : base(unitOfWork, order_DetailRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _order_detailRepository = order_DetailRepository;
            _orderRepository = orderRepository;
        }

    }
}
