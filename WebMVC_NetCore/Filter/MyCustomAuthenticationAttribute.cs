using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVC_NetCore.Filter
{
    public class MyCustomAuthenticationAttribute : TypeFilterAttribute
    {
        public MyCustomAuthenticationAttribute(string function, string permision) : 
            base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { function, permision };
        }
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        public string _function { get; set; }

        public string _permision { get; set; }

        public ClaimRequirementFilter(string function, string permision)
        {
           _function = function;
           _permision = permision;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var f = _function;
            // userid = 1 và nếu permisson ! VIEW thì trả về thông báo lỗi  ;throw new NotImplementedException();
        }
    }
}
