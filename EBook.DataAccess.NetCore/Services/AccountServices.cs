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
    public class AccountServices : IAccountServices
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();
        public async Task<ReturnData> Account_Login(Account_LoginRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                var account = _eBookDBContext.account.Where(s => s.Email == requestData.email
                && s.Password == requestData.password).FirstOrDefault();

                if(account==null && account.Id <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "đăng nhập thất bại";
                    return returnData;
                }

                returnData.ReturnCode = account.Id;
                returnData.ReturnMsg = "đăng nhập thành công";
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
