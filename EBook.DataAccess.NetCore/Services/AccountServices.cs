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
        EBookDBContext _eBookDBContext;

        public AccountServices(EBookDBContext eBookDBContext)
        {
            _eBookDBContext = eBookDBContext;
        }
        public async Task<LoginResponseData> Account_Login(Account_LoginRequestData requestData)
        {
            var returnData = new LoginResponseData();
            try
            {
                var account = _eBookDBContext.account.Where(s => s.UserName == requestData.username
                && s.Password == requestData.password).FirstOrDefault();

                if (account == null && account?.Id <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMsg = "đăng nhập thất bại";
                    return returnData;
                }
                var model = new Account
                {
                    UserName = account.UserName,
                    Id = account.Id,
                    FullName = account.FullName,
                };

                returnData.ReturnCode = account.Id;
                returnData.ReturnMsg = "đăng nhập thành công";
                returnData.account = model;
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Function> GetFunction(string functionCode)
        {
            var model = new Function();
            try
            {
                model = _eBookDBContext.function.Where(s => s.FunctionCode == functionCode).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

            return model;
        }

        public async Task<User_Permission> User_PermissionById(int functionId, int UserID)
        {
            var model = new User_Permission();

            try
            {
                model = _eBookDBContext.user_permission.Where(s => s.FunctionID == functionId && s.UserID == UserID).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }

            return model;
        }
    }
}
