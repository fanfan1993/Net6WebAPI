using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace yanfanNet6WebApi.Utility.Filters
{
    /// <summary>
    ///  自定义 AsyncResourceFilter
    /// </summary>
    public class CustomAsyncCacheResourceFilterAttribute : Attribute, IAsyncResourceFilter
    {
        /// <summary>
        /// 缓存区域
        /// </summary>
        private static Dictionary<string, object> CacheiDictionary = new Dictionary<string, object>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {

            // 判断缓存
            string key = context.HttpContext.Request.Path;//Url地址
            if (CacheiDictionary.ContainsKey(key))
            {
                object oResult = CacheiDictionary[key];
                IActionResult result = oResult as IActionResult;
                context.Result = result; //请求处理的过程中的一个短路器，如果给Result赋值了，就不继续往后执行了，如果没有赋值，为null，就继续往后执行：
            }
            else
            {
                ResourceExecutedContext executedContext = await next.Invoke();
                CacheiDictionary[key] = executedContext.Result;
            }
        }
    }
}
