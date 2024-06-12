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
using Frank.Service.Order_DetailService.Dto;
using System.Data.Entity;

namespace Frank.Service.OrderService
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        IUnitOfWork _unitOfWork;
        IOrderRepository _orderRepository;
        ILog _loger;
        IMapper _mapper;
        IOrder_DetailRepository _order_DetailRepository;
        IProductRepository _productRepository;
        IImageRepository _imageRepository;
        public OrderService(IUnitOfWork unitOfWork,
         IOrderRepository orderRepository,
         ILog loger,
         IMapper mapper,
         IOrder_DetailRepository order_DetailRepository,
         IProductRepository productRepository,
         IImageRepository imageRepository

        )
        : base(unitOfWork, orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _loger = loger;
            _mapper = mapper;
            _order_DetailRepository = order_DetailRepository;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
        }
        public List<OrderDto> GetListByIdUser(long UserId)
        {
            var result = new List<OrderDto>();
            var order = _orderRepository.GetAllAsQueryable().Where(x => x.User_Id == UserId).AsNoTracking();
            if (order != null)
            {
                foreach (var item in order)
                {
                    var obj = new OrderDto();
                    obj.Id = item.Id;
                    obj.Processing_Status = item.Processing_Status;
                    obj.TotalPrice = item.TotalPrice;
                    obj.RecieveAddress = item.RecieveAddress;
                    obj.RecieveName = item.RecieveName;
                    obj.RecievePhone = item.RecievePhone;
                    obj.User_Id = UserId;
                    obj.Order_Details = (from order_Detailtbl in _order_DetailRepository.GetAllAsQueryable().Where(x => x.Order_Id == item.Id).AsNoTracking()
                                         join producttbl in _productRepository.GetAllAsQueryable().AsNoTracking()
                                         on order_Detailtbl.Product_Id equals producttbl.Id
                                         join imagetbl in _imageRepository.GetAllAsQueryable().AsNoTracking()
                                         on producttbl.Id equals imagetbl.Product_Id
                                         select new Order_DetailDto
                                         {
                                             Price = order_Detailtbl.Price,
                                             Quantity = order_Detailtbl.Quantity,
                                             Order_Id = item.Id,
                                             Product_Id = order_Detailtbl.Product_Id,
                                             Url_Image = imagetbl.Url_Image,
                                             NameProduct = producttbl.Name
                                         }).ToList();
                    if (obj.Order_Details.Count > 0)
                    {
                        result.Add(obj);
                    }
                }
            }
            return result;
        }
        public OrderDto GetByUserAndOrder_Id(long UserId, long Order_Id)
        {
            OrderDto result = new OrderDto();
            var order = _orderRepository.FindBy(x=>x.User_Id == UserId && x.Id == Order_Id).FirstOrDefault();
            if (order != null)
            {
                result.Id = order.Id;
                result.User_Id = order.User_Id;
                result.Processing_Status = order.Processing_Status;
                result.TotalPrice = order.TotalPrice;
                result.RecieveName = order.RecieveName;
                result.RecieveAddress = order.RecieveAddress;
                result.RecievePhone = order.RecievePhone;
                result.Order_Details = (from order_Detailtbl in _order_DetailRepository.GetAllAsQueryable().Where(x => x.Order_Id == order.Id).AsNoTracking()
                                        join producttbl in _productRepository.GetAllAsQueryable().AsNoTracking()
                                        on order_Detailtbl.Product_Id equals producttbl.Id
                                        join imagetbl in _imageRepository.GetAllAsQueryable().AsNoTracking()
                                        on producttbl.Id equals imagetbl.Product_Id
                                        select new Order_DetailDto
                                        {
                                            Price = order_Detailtbl.Price,
                                            Quantity = order_Detailtbl.Quantity,
                                            Order_Id = order.Id,
                                            Product_Id = order_Detailtbl.Product_Id,
                                            Url_Image = imagetbl.Url_Image,
                                            NameProduct = producttbl.Name
                                        }).ToList();             
            }
            return result;
        }
    }
}
