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
using Frank.Service.OrderService.Dto;
using Frank.Repository.Order_DetailRepository;
using Frank.Repository.ProductRepository;
using Frank.Repository.ImageRepository;

namespace Frank.Service.OrderService
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        IUnitOfWork _unitOfWork;
        IOrderRepository _orderRepository;
        ILog _loger;
        IMapper _mapper;
        IOrder_DetailRepository _order_AddressRepository;
        IProductRepository _productRepository;
        IImageRepository _imageRepository;
        public OrderService(IUnitOfWork unitOfWork,
         IOrderRepository orderRepository,
         ILog loger,
         IMapper mapper,
         IOrder_DetailRepository order_AddressRepository,
         IProductRepository productRepository,
         IImageRepository imageRepository

        )
        : base(unitOfWork, orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _loger = loger;
            _mapper = mapper;
            _order_AddressRepository = order_AddressRepository;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
        }
        //public List<OrderDto> GetListByIdUser(long UserId)
        //{
           
        //    return query.ToList();
        //}
    }
}
