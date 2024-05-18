using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace yanfanNet6WebApi.Utility.Filters
{
    /// <summary>
    ///  自定义 AsyncResourceFilter
    /// </summary>
    public class CustomCacheResourceFilterAttribute : Attribute, IResourceFilter
    {
        /// <summary>
        /// 缓存区域
        /// </summary>
        private static Dictionary<string, object> CacheiDictionary = new Dictionary<string, object>();

    
        void IResourceFilter.OnResourceExecuted(ResourceExecutedContext context)
            {
            // 如果能够执行到这单，说明一定已经执行了：控制器的构造函数 + 一定已经执行了API了：/
            // /必然也已经得到了计算的结果了：就应该把计算的记过保存到缓存中去：
            string key = context.HttpContext.Request.Path;//Url地址
            CacheiDictionary[key] = context.Result;
        }

        void IResourceFilter.OnResourceExecuting(ResourceExecutingContext context)
            {
            //在这里就应该检查缓存，如果有就直接返回：
            string key = context.HttpContext.Request.Path;//Url地址
            if (CacheiDictionary.ContainsKey(key))
            {
                object oResult = CacheiDictionary[key];
                IActionResult result = oResult as IActionResult;
                context.Result = result; //请求处理的过程中的一个短路器，如果给Result赋值了，就不继续往后执行了，如果没有赋值，为null，就继续往后执行：
            }
           
        }
    }
}
