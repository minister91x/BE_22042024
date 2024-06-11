using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.Services
{
    public class BookServices : IBookServices
    {
      //  EBookDBContext _eBookDBContext = new EBookDBContext();

        //public async Task<BookInsertReturnData> ADO_Book_Insert(Book bookInput)
        //{
        //    var returnData = new BookInsertReturnData();
        //    try
        //    {
        //        // kiểm tra đầu vào 
        //        if (bookInput == null
        //            || string.IsNullOrEmpty(bookInput.BookName))
        //        {
        //            returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.DataInValid;
        //            returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ ";
        //            return returnData;
        //        }

        //        // Bước 1: Mở connection đến DB
        //        var connect = Eshop.Common.DbHelper.GetSqlConnection();

        //        // Bước 2: Sử dụng Sqlcommand để thao tác

        //        var cmd = new SqlCommand("SP_BookInsert", connect);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        //var cmdText = new SqlCommand("Select * from Book whew bookid=1=1", connect);
        //        //cmd.CommandType = System.Data.CommandType.Text;

        //        //KIỂU COMMAND mà muốn dùng TEXT VÀ STORE

        //        // Bước 3: thêm tham số 
        //        cmd.Parameters.AddWithValue("@BookName", bookInput.BookName);
        //        cmd.Parameters.AddWithValue("@PublishDate", bookInput.PublishDate);
        //        cmd.Parameters.AddWithValue("@AuthorID", bookInput.AuthorID);
        //        cmd.Parameters.AddWithValue("@CategoryID", bookInput.CategoryID);
        //        cmd.Parameters.AddWithValue("@Price", bookInput.Price);
        //        cmd.Parameters.AddWithValue("@Quantity", bookInput.Quantity);
        //        cmd.Parameters.AddWithValue("@ResponseCode", SqlDbType.Int).Direction = ParameterDirection.Output;

        //        // Bước 4: Nhận kết quả 
        //        cmd.ExecuteNonQuery();


        //        var rs = cmd.Parameters["@ResponseCode"].Value != DBNull.Value ?
        //            Convert.ToInt32(cmd.Parameters["@ResponseCode"].Value) : 0;

        //        if (rs < 0)
        //        {
        //            returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.Fail;
        //            returnData.ReturnMsg = "Thêm dữ liệu thất bại";
        //            return returnData;
        //        }


        //        returnData.ReturnCode = rs;
        //        returnData.ReturnMsg = "Thêm dữ liệu thành công!";
        //        returnData.book = bookInput;
        //        return returnData;
        //    }
        //    catch (Exception ex)
        //    {
        //        returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.Exception;
        //        returnData.ReturnMsg = ex.Message;
        //        return returnData;
        //    }
        //}

        //public async Task<List<Book>> ADO_GetBooks(GetBookRequestData requestData)
        //{
        //    var list = new List<Book>();
        //    try
        //    {
        //        // Bước 1: Mở connection đến DB
        //        var connect = Eshop.Common.DbHelper.GetSqlConnection();

        //        // Bước 2: Sử dụng Sqlcommand để thao tác

        //        var cmd = new SqlCommand("SP_Book_GetAll", connect);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        // Bước 3: gán giá trị cho các parammeter 
        //        cmd.Parameters.AddWithValue("@BookName", requestData.BookName);

        //        // Bước 4: nhận kết quá 
        //        var reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            var book = new Book
        //            {
        //                BookID = reader["BookID"] != null ? Convert.ToInt32(reader["BookID"]) : 0,
        //                BookName = reader["BookName"] != null ? Convert.ToString(reader["BookName"]) : String.Empty,
        //                Price = reader["Price"] != null ? Convert.ToInt32(reader["Price"]) : 0,
        //                Quantity = reader["Quantity"] != null ? Convert.ToInt32(reader["Quantity"]) : 0,
        //            };

        //            list.Add(book);
        //        }

        //        return list;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<BookInsertReturnData> Book_Insert(Book bookInput)
        //{
        //    var returnData = new BookInsertReturnData();
        //    try
        //    {
        //        // kiểm tra đầu vào 
        //        if (bookInput == null
        //            || string.IsNullOrEmpty(bookInput.BookName))
        //        {
        //            returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.DataInValid;
        //            returnData.ReturnMsg = "Dữ liệu đầu vào không hợp lệ ";
        //            return returnData;
        //        }

        //        // kiểm tra trùng 
        //        var currentBook = _eBookDBContext.book.ToList().Where(s => s.BookName == bookInput.BookName).FirstOrDefault();
        //        if (currentBook != null)
        //        {
        //            if (currentBook.BookName == bookInput.BookName
        //                && currentBook.PublishDate.ToString("dd/MM/yyy")
        //                == bookInput.PublishDate.ToString("dd/MM/yyy"))
        //            {
        //                returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.DuplicateData;
        //                returnData.ReturnMsg = "Sách này đã tồn tại trên hệ thống";
        //                return returnData;
        //            }

        //        }
        //        _eBookDBContext.book.Add(bookInput);
        //        var result = _eBookDBContext.SaveChanges();

        //        returnData.ReturnCode = (int)Eshop.Common.Enum_ReturnCode.Success;
        //        returnData.ReturnMsg = "Thêm dữ liệu thành công";
        //        returnData.book = bookInput;

        //        return returnData;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<List<Book>> GetBooks()
        //{
        //    return _eBookDBContext.book.ToList();
        //}

        //public async Task<List<Book>> GetBook_ByStock(GetBook_ByStockRequestData requestData)
        //{
        //    var list = new List<Book>();
        //    try
        //    {
        //        // Bước 1: Mở connection đến DB
        //        var connect = Eshop.Common.DbHelper.GetSqlConnection();

        //        // Bước 2: Sử dụng Sqlcommand để thao tác

        //        var cmd = new SqlCommand("SP_Book_GetStock", connect);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        // Bước 3: gán giá trị cho các parammeter 
        //        cmd.Parameters.AddWithValue("@BookName", requestData.BookName);

        //        // Bước 4: nhận kết quá 
        //        var reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            var book = new Book
        //            {
        //                BookID = reader["BookID"] != null ? Convert.ToInt32(reader["BookID"]) : 0,
        //                BookName = reader["BookName"] != null ? Convert.ToString(reader["BookName"]) : String.Empty,
        //                Price = reader["Price"] != null ? Convert.ToInt32(reader["Price"]) : 0,
        //                Quantity = reader["Quantity"] != null ? Convert.ToInt32(reader["Quantity"]) : 0,
        //            };

        //            list.Add(book);
        //        }

        //        connect.Close();
        //        return list;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}
