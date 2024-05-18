using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace yanfanNet6WebApi.Utility.Filters
{
    /// <summary>
    ///  自定义 resourceFilter 扩展缓存
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
            Console.WriteLine("---befoer-----CustomAsyncResourceFilterAttribute OnResourceExecutionAsync");
            await next.Invoke(); // 条用下一个
            Console.WriteLine("---after----CustomAsyncResourceFilterAttribute OnResourceExecutionAsync");

        }
    }
}

