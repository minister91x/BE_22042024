namespace WebMVC_NetCore.Models
{

    public class ResponseData
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class BookInsertResponse: ResponseData
    {
    
    }
    public class BookDeleteResponse : ResponseData
    {

    }

}
