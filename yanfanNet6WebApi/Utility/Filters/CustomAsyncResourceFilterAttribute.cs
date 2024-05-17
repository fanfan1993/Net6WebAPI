using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace yanfanNet6WebApi.Utility.Filters
{
    /// <summary>
    ///  自定义 AsyncResourceFilter
    /// </summary>
    public class CustomAsyncResourceFilterAttribute : Attribute, IAsyncResourceFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Console.WriteLine("CustomAsyncResourceFilterAttribute OnResourceExecutionAsync");
            await next.Invoke(); // 条用下一个
        }
    }
}

