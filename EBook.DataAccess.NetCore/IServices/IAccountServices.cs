using EBook.DataAccess.NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.IServices
{
    public interface IAccountServices
    {
       Task<LoginResponseData> Account_Login(Account_LoginRequestData requestData);

        Task<Function> GetFunction(string functionCode);
        Task<User_Permission> User_PermissionById(int functionId, int UserID);
    }
}
