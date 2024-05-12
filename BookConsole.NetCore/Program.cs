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

//var rs = await bookservices.Book_Insert(book);
var rs = await bookservices.ADO_Book_Insert(book);

if (rs.ReturnCode < 0)
{
    Console.WriteLine("Thêm lỗi với lý do  {0}", rs.ReturnMsg);
    return;
}

// insert thành công 
//var book_servies_return = rs.book;
//Console.WriteLine("-----------------");
//Console.WriteLine("BookID {0}", rs.ReturnCode);
//Console.WriteLine("Bookname {0}", book_servies_return.BookName);
//Console.WriteLine("Bookname {0}", book_servies_return.PublishDate);
//Console.WriteLine("Bookname {0}", book_servies_return.Price);
//Console.WriteLine("Bookname {0}", book_servies_return.Quantity);

var lst_Book = await bookservices.ADO_GetBooks(new GetBookRequestData { BookName = "" });
if (lst_Book != null && lst_Book.Count > 0)
{
    Console.WriteLine("-----------------");
    foreach (var item in lst_Book)
    {
        Console.WriteLine("BookID {0}", item.BookID);
        Console.WriteLine("BookName {0}", item.BookName);
        Console.WriteLine("Quantity {0}", item.Quantity);
        Console.WriteLine("Price {0}", item.Price);
    }
}

