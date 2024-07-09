using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.Services
{
    public class OrderServices : IOrderServices
    {
        private EBookDBContext _eBookDBContext;
        public OrderServices(EBookDBContext eBookDBContext)
        {
            _eBookDBContext = eBookDBContext;
        }

        public async Task<int> OrderDetail_Create(OrderDetail orderDetail)
        {
            try
            {
                _eBookDBContext.orderdetail.Add(orderDetail);
                return 1;
            }
            catch (Exception ex)
            {

                return -969;
            }
        }

        public async Task<Order_CreateReturnData> Order_Create(OrdersCreateRequestData requestData)
        {
            var returnData = new Order_CreateReturnData();
            try
            {
                // kiểm tra 
                var req = new Order
                {
                    CreatedTime = DateTime.Now,
                    CustomerId = requestData.CustomerId == 0 ? 1 : 0,// fake data
                    ShipingAddress = requestData.ShipingAddress,
                    TotalAmount = requestData.TotalAmount,
                };
                _eBookDBContext.order.Add(req);
               // _eBookDBContext.SaveChangesAsync();

                returnData.ReturnCode = req.OrderId;
                returnData.ReturnMsg = "mua sản phẩm thành công";
                return returnData;
            }
            catch (Exception EX)
            {

                returnData.ReturnCode = -969;
                returnData.ReturnMsg = EX.Message;
                return returnData;
            }
        }
    }
}
