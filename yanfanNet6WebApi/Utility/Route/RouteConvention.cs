﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace yanfanNet6WebApi.Utility.Route
{
	public class RouteConvention: IApplicationModelConvention
	{
		/// 定义一个路由前缀变量
		private readonly AttributeRouteModel _centralPrefix;
        /// <summary>
        /// 调用时传入指定的路由前缀
        /// </summary>
        /// <param name="routeTemplateProvider"></param>
        public RouteConvention(IRouteTemplateProvider routeTemplateProvider)
		{
			_centralPrefix = new AttributeRouteModel(routeTemplateProvider);
		}


		/// <summary>
		/// 接口的Apply的方法，在这个方法中根据情况来添加API 路由前缀
		/// </summary>
		/// <param name="application"></param>
		/// <exception cref="NotImplementedException"></exception>
		public void Apply(ApplicationModel application)
		{
			//遍历所有的Controller
			foreach (var controller in application.Controllers)
			{
                //l、已经标记了RouteAttribute的Controller
                //这一块需要注意，如果在控制器中已经标注有路由了，则会在路由的前面再添加指定的路由内容。
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel !=
				    null).ToList();
				if (matchedSelectors.Any())
				{
					foreach (var selectorModel in matchedSelectors)
					{
						//在当前路由上再添加一个路由前缀
						selectorModel.AttributeRouteModel =
						AttributeRouteModel.CombineAttributeRouteModel(_centralPrefix,
						   selectorModel.AttributeRouteModel);
					}
                }

				//2、没有标记RouteAttribute的Controller
				var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel
				== null).ToList();
				if (unmatchedSelectors.Any())
				{
					foreach (var selectorModel in unmatchedSelectors)
					{
                        //添加一个路由前缀
                        selectorModel.AttributeRouteModel = _centralPrefix;
                    }
				}

            }
            //throw new NotImplementedException();
        }

    }
}

