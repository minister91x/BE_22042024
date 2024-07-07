using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductServices _productServices { get; set; }
        public IBookGenericRepository _bookGenericRepository { get; set; }
        private EBookDBContext _eBookDBContext { get; set; }
        public IAccountServices _accountServices { get; set; }
        public IBookRepository _bookRepository { get; set; }

        public UnitOfWork(IProductServices productServices, 
            IBookGenericRepository bookGenericRepository, EBookDBContext eBookDBContext,
            IAccountServices accountServices, IBookRepository bookRepository)
        {
            _productServices = productServices;
            _bookGenericRepository = bookGenericRepository;
            _eBookDBContext = eBookDBContext;
            _accountServices = accountServices;
            _bookRepository = bookRepository;
        }

        public int SaveChange()
        {
            return _eBookDBContext.SaveChanges();
        }
    }
}
