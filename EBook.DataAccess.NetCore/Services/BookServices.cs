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

        public async Task<BookInsertReturnData> Book_Insert(Book bookInput)
        {
            var returnData = new BookInsertReturnData();
            try
            {
                // kiểm tra đầu vào 
                if (bookInput == null
                    || string.IsNullOrEmpty(bookInput.BookName))
                {
                    returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.DataInValid;
                    returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ ";
                    return returnData;
                }

                // kiểm tra trùng 
                var currentBook = _eBookDBContext.book.ToList().Where(s => s.BookName == bookInput.BookName).FirstOrDefault();
                if (currentBook != null)
                {
                    if (currentBook.BookName == bookInput.BookName
                        && currentBook.PublishDate.ToString("dd/MM/yyy")
                        == bookInput.PublishDate.ToString("dd/MM/yyy"))
                    {
                        returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.DuplicateData;
                        returnData.ReturnMsg = "Sách này đã tồn tại trên hệ thống";
                        return returnData;
                    }

                }
                _eBookDBContext.book.Add(bookInput);
                var result = _eBookDBContext.SaveChanges();

                returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.Success;
                returnData.ReturnMsg = "Thêm dữ liệu thành công";
                returnData.book = bookInput;

                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Book>> GetBooks()
        {
            return _eBookDBContext.book.ToList();
        }
    }
}
