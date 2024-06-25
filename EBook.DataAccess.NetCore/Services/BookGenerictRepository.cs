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
    public class BookGenerictRepository : GenericRepository<Book>, IBookGenericRepository
    {
        public BookGenerictRepository(EBookDBContext dbContext) : base(dbContext)
        {
        }
    }
}
