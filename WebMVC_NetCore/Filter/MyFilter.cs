using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVC_NetCore.Filter
{
    public class MyFilterAttribute : ActionFilterAttribute
    {
        public MyFilterAttribute()
        {
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var text = "";
            var router = filterContext.RouteData;
        }

    }
}
