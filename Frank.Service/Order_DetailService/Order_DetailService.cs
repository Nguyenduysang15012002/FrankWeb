using AutoMapper;
using Frank.Model.Entities;
using Frank.Repository;
using Frank.Repository.Order_DetailRepository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.Order_DetailService
{
    public class Order_DetailService : EntityService<Order_Detail>, IOrder_DetailService
    {
        IUnitOfWork _unitOfWork;
        IOrder_DetailRepository _order_detailRepository;
        IMapper _mapper;
        ILog _logger;
        public Order_DetailService(
            IUnitOfWork unitOfWork,
            IOrder_DetailRepository order_DetailRepository,
            IMapper mapper) 
            : base( unitOfWork,order_DetailRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _order_detailRepository = order_DetailRepository;
        }
    }
}
