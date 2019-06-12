using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ZMS.WebApplication.Infrastructure.Filters
{
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;

            context.Result = new ContentResult
            {
                Content = $"Method {actionName} throw an exception: \n {exceptionMessage} \n {exceptionStack}"
            };
        }
    }
}
