using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Filters.Attributes
{
    public class TwoFactorAuthorizeAttribute : Attribute, IResourceFilter
    {
        private ITFAService _service;
        private string _cookieName = "TFAPin";

        public TwoFactorAuthorizeAttribute(ITFAService service)
        {
            _service = service;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.HttpContext.User.Identities.ToList()[0].Name != null)
            {
                var leadID = new Guid(context.HttpContext.User.Identities.ToList()[0].Name);

                var pin = context.HttpContext.Request.Cookies[_cookieName];
                var isCorrectPin = Task.Run<bool>(async () => await _service.ConfirmPinAsync(leadID, pin)).Result;

                if (!isCorrectPin)
                {
                    context.Result = new ContentResult() { StatusCode = (int)HttpStatusCode.Unauthorized };
                }
            }
            else
            {
                context.Result = new ContentResult() { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
    }
}
