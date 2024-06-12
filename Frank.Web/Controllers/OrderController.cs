using AutoMapper;
using Frank.Repository.ProductRepository;
using Frank.Repository;
using Frank.Service.Attribute_ProductService;
using Frank.Service.Order_DetailService;
using Frank.Service.OrderService;
using Frank.Service.ProductService;
using Frank.Service.ShopCartService;
using Frank.Service.UserService;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Printing;
using System.Web.UI;
using PagedList;
using Frank.Model.Entities;
using Frank.Service.Common;

namespace Frank.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _ProductRepository;
        private readonly ILog _ilog;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IAttribute_ProductService _attribute_ProductService;
        private readonly IShopCartService _shopCartService;
        private readonly IOrderService _orderService;
        private readonly IOrder_DetailService _order_DetailService;
        public OrderController(
              IProductService ProductService, ILog Ilog,
              IAttribute_ProductService AttributeService,
              IUserService UserService,
              IMapper mapper,
              IShopCartService shopCartService,
              IOrderService orderService,
              IOrder_DetailService order_DetailService

              )
        {
            _productService = ProductService;
            _ilog = Ilog;
            _mapper = mapper;
            _userService = UserService;
            _attribute_ProductService = AttributeService;
            _shopCartService = shopCartService;
            _orderService = orderService;
            _order_DetailService = order_DetailService;

        }
        // GET: Order
        public ActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = page ?? 1;
            int pageSizeValue = pageSize ?? 100;
            var listOrder = _orderService.GetAll().ToList();

            var orderDtoPagedList = listOrder.ToPagedList(pageNumber, pageSizeValue);
            ViewBag.PageSize = pageSize;          
            return View(orderDtoPagedList);
        }
        public ActionResult Edit(long id)
        {      
            ViewBag.Status = new List<SelectListItem>
            {
                 new SelectListItem { Value = "2", Text = "Phê duyệt" },
                 new SelectListItem { Value = "3", Text = "Đã giao hàng" },
                 new SelectListItem { Value = "4", Text = "Hủy đơn hàng" } 
            };
            var model = _orderService.GetById(id);
            return View(model);
        }
        [HttpPatch]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(FormCollection form)
        {
            var result = new JsonResultBO(true, "Cập nhật đơn hàng thành công");
            try
            {
                var RecieveName = form["RecieveName"];
                var RecieveAddress = form["RecieveAddress"];
                var RecievePhone = form["RecievePhone"];
                var Status = form["Status"];             
                var Id = long.Parse(form["Id"]);
                var order = _orderService.FindBy(x => x.Id == Id).FirstOrDefault();
                if (order != null)
                {
                    order.RecieveName = RecieveName;
                    order.RecieveAddress = RecieveAddress;
                    order.RecievePhone = RecievePhone;
                    order.Processing_Status = int.Parse(Status);
                    _orderService.Update(order);
                }
            }
            catch (Exception ex)
            {
                result.MessageFail(ex.Message);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(long Id)
        {
            try
            {
                var order = _orderService.FindBy(x => x.Id == Id).FirstOrDefault();
                if (order != null)
                {
                    _orderService.Delete(order);
                    return Json(new { success = true, message = "Xóa đơn hàng thành công." });
                }
                else
                {
                    return Json(new { success = false, message = "Xóa đơn hàng thất bại." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}