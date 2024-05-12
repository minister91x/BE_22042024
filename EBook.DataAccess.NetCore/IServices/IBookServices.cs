using EBook.DataAccess.NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.IServices
{
    public interface IBookServices
    {
        Task<List<Book>> GetBooks();
        Task<BookInsertReturnData> Book_Insert(Book book);
    }
}
