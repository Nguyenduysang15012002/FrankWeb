using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository.OrderRepository;
using Frank.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.OrderService
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        IUnitOfWork _unitOfWork;
        IOrderRepository _orderRepository;
        ILog _loger;
        IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork,
         IOrderRepository orderRepository,
         ILog loger,
         IMapper mapper
        )
        : base(unitOfWork, orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _loger = loger;
            _mapper = mapper;
        }
    }
}
