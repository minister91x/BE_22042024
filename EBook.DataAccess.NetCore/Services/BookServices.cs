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
    public class BookServices : IBookServices
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();

        public async  Task<int> Book_Insert(Book book)
        {
            _eBookDBContext.book.Add(book);
            return _eBookDBContext.SaveChanges();
        }

        public async Task<List<Book>> GetBooks()
        {
            return _eBookDBContext.book.ToList();
        }
    }
}
