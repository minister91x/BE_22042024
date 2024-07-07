namespace WebMVC_NetCore.Models
{
    public class ProductGetListRequestData
    {
    }

    public class ProductGetListReponseData
    {
        public int productID { get; set; }
        public int categoryId { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public List<object> productAttributes { get; set; }
    }


}
