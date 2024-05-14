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

var lst_Book = await bookservices.GetBook_ByStock(new GetBook_ByStockRequestData { BookName = "v" });

var lst_Book_EF = await bookservices.GetBooks();

var listExpried = from
                  lstbook // biến để lưu dữ liệu
                  in
                  lst_Book_EF // nguồn dữ liệu
                              // điều kiên 
                  where lstbook.PublishDate < (DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)))
                  && lstbook.Quantity  >0// (from  in select )
                  // // sắp xếp book có id từ lớn đến bé
                  orderby lstbook.BookID descending

                  // trả về dữ liệu
                //  select lstbook
                  select new
                  {
                      Quantity = lstbook.Quantity,
                      BookName = lstbook.BookName
                  };


var lst = listExpried.ToList();

var totalQuantiTy = listExpried.Sum(s => s.Quantity);

if (lst != null && lst.Count() > 0)
{
    Console.WriteLine("---------Danh sách hết hạn--------");
    foreach (var item in lst)
    {
        // Console.WriteLine("BookID {0}", item.BookID);
        Console.WriteLine("BookName {0}", item.BookName);
        Console.WriteLine("Quantity {0}", item.Quantity);
        // Console.WriteLine("Price {0}", item.Price);
    }

    Console.WriteLine("---------Tổng số lượng sắp hết hạn {0}", totalQuantiTy);
}



