using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DTO
{
    public class Book
    {
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public DateTime PublishDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    public class GetBookRequestData
    {
        public string BookName { get; set; }
        public DateTime PublishDate { get; set; }
    }

    public class GetBook_ByStockRequestData
    {
        public string BookName { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Result
    {
        public int bookID { get; set; }
        public string bookName { get; set; }
        public int authorID { get; set; }
        public int categoryID { get; set; }
        public DateTime publishDate { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }

    public class GetBookResponseData
    {
        public List<Result> result { get; set; }
        public int id { get; set; }
        public object exception { get; set; }
        public int status { get; set; }
        public bool isCanceled { get; set; }
        public bool isCompleted { get; set; }
        public bool isCompletedSuccessfully { get; set; }
        public int creationOptions { get; set; }
        public object asyncState { get; set; }
        public bool isFaulted { get; set; }
    }


}
