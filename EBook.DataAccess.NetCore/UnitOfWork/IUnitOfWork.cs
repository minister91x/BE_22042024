using EBook.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IProductServices _productServices { get; set; }
        public IBookGenericRepository _bookGenericRepository { get; set; }
        public IBookRepository _bookRepository { get; set; }
        public IAccountServices _accountServices { get; set; }

        public IOrderServices _orderServices { get; set; }
        int SaveChange();
    }
}
