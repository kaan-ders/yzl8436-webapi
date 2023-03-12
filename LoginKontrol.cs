using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi
{
    public class LoginKontrol : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Headers["kullanici"] != "admin" || filterContext.HttpContext.Request.Headers["sifre"] != "123")
            {
                var controller = (WebApi.Controllers.DenemeController)filterContext.Controller;
                filterContext.Result = controller.Unauthorized();
            }
        }
    }
}
