// See https://aka.ms/new-console-template for more information
using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.Services;
using Microsoft.EntityFrameworkCore;

var bookservices = new BookServices();

string bookName = string.Empty;

Console.WriteLine("Nhập bookName:");
bookName = Console.ReadLine();
// kiểm tra dữ liêu

var book = new Book
{
    BookName = bookName,
    AuthorID = 1,
    PublishDate = DateTime.Now,
    Price = 100000,
    Quantity = 150
};

var rs = await bookservices.Book_Insert(book);

if (rs.ReturnCode < 0)
{
    Console.WriteLine("Thêm lỗi với lý do  {0}", rs.ReturnMsg);
    return;
}

// insert thành công 
var book_servies_return = rs.book;
Console.WriteLine("-----------------");
Console.WriteLine("Bookname {0}", book_servies_return.BookName);
Console.WriteLine("Bookname {0}", book_servies_return.PublishDate);
Console.WriteLine("Bookname {0}", book_servies_return.Price);
Console.WriteLine("Bookname {0}", book_servies_return.Quantity);

