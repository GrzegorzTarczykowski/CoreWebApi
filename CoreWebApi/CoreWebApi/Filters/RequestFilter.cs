﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CoreWebApi.Filters
{
    public class RequestFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
