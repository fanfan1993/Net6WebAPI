using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace yanfanNet6WebApi.Utility.Filters
{
    /// <summary>
    /// 自定义 接口
    /// </summary>
    // 继承 Attribute 并且实现接口话 IResourceFilter
    public class CustomResourceFilterAttribute : Attribute , IResourceFilter
    {
        /// <summary>
        /// 在莫某资源后
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("CustomResourceFilterAttribute.OnResourceExecuted");
        }

        /// <summary>
        /// 在莫某资源前
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("CustomResourceFilterAttribute.OnResourceExecuting");
        }
    }
}

