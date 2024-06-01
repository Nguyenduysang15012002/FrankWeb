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
using Frank.Repository.Order_AddressRepository;
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
        IOrder_AddressRepository _order_AddressRepository;
        IProductRepository _productRepository;
        IImageRepository _imageRepository;
        public OrderService(IUnitOfWork unitOfWork,
         IOrderRepository orderRepository,
         ILog loger,
         IMapper mapper,
         IOrder_AddressRepository order_AddressRepository,
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
        public List<OrderDto> GetListByIdUser(long UserId)
        {
            var query = from ordertbl in _orderRepository.GetAllAsQueryable()
                        join orderaddresstbl in _order_AddressRepository.GetAllAsQueryable()
                        on ordertbl.Id equals orderaddresstbl.Order_Id
                        join producttbl in _productRepository.GetAllAsQueryable()
                        on ordertbl.Product_Id equals producttbl.Id
                        join imagetbl in _imageRepository.GetAllAsQueryable()
                        on ordertbl.Product_Id equals imagetbl.Product_Id
                        where ordertbl.User_Id == UserId
                        select new OrderDto
                        {
                            Processing_Status = ordertbl.Processing_Status,
                            TotalPrice = ordertbl.TotalPrice,
                            Quantity = ordertbl.Quantity,
                            User_Id = UserId,
                            NameCustomer = orderaddresstbl.NameCustomer,
                            Phone = orderaddresstbl.Phone,
                            Address = orderaddresstbl.Address,
                            Product_Id = ordertbl.Product_Id,
                            Url_Image = imagetbl.Url_Image,
                            Name_Product = producttbl.Name,
                        };
            return query.ToList();
        }
    }
}
