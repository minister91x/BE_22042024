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

if (string.IsNullOrEmpty(bookName))
{
    Console.WriteLine(" bookName không được trống:");
    return;
}

var book_Input = new Book
{
    BookName = bookName,
    AuthorID = 1,
    PublishDate = DateTime.Now.AddMonths(-1),
    IsActive = 1,
    CreatedUser = 1
};
var result = await bookservices.Book_Insert(book_Input);


if (result <= 0)
{
    Console.WriteLine("Thêm mới thất bại:");
    return;
}

Console.WriteLine("--------Danh sách book-------");
var list = await bookservices.GetBooks();

if (list.Count > 0)
{
    foreach (var item in list)
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("bookid {0}", item.BookID);
        Console.WriteLine("bookid {0}", item.BookName);
        Console.WriteLine("PublishDate {0}", item.PublishDate.ToString("dd/MM/yyyy"));
    }
}

