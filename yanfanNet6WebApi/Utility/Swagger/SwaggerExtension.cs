using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace yanfanNet6WebApi.Utility.Swagger
{
    /// <summary>
    /// swagger 扩展独立一个独立封装
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSwaggerGenExt(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option => {

                #region 自定义 支持API分版本展示
                {
                    // 根据 API 版本信息生成 API 文档
                    var provider = builder.Services.BuildServiceProvider
                    ().GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        option.SwaggerDoc(description.GroupName, new OpenApiInfo
                        {
                            Contact = new OpenApiContact
                            {
                                Name = "yanfan",
                                Email = "1784498@163.com"
                            },
                            Description = "yanfan.NET6WebAPI文档",
                            Title = "yanfan，NET6WebAPI文档",
                            Version = description.ApiVersion.ToString()
                        });
                    }
                    //在Swagger文档显示的API地址中将版本信息参数替换为实际的版本号
                    option.DocInclusionPredicate((version, apiDescription) =>
                    {
                        if (!version.Equals(apiDescription.GroupName))
                            return false;

                        IEnumerable<string>? values = apiDescription!.RelativePath
                            .Split('/')
                            .Select(v => v.Replace("v{version}", apiDescription.GroupName));

                        apiDescription.RelativePath = string.Join("/", values);
                        return true;
                     });
                    //参数使用驼峰命名方式
                    option.DescribeAllParametersInCamelCase();
                    //取消A PI文档需要输入版本信息
                    //option.OperationFilter<RemoveVersionFromParameter>();
                }
                #endregion

                #region 版本配置
                //typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                //{
                //    option.SwaggerDoc(version, new OpenApiInfo()
                //    {
                //        Title = $"{version}：我的CoreWebApi~",
                //        Version = version,
                //        Description = $"coreWebApi版本{version}"
                //    });
                //});
                #endregion

                #region 支持token产值
                {
                    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Description = "请输入token，格式为Bearer xxxxxxxx（注意中间必须有空格）",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });
                }
                #endregion

                #region 文件按钮上传
                //{
                //    option.OperationFilter<IOperationFilter>();
                //}
                #endregion
            });
        }

        /// <summary>
        /// swagger 中间件配置应用
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerExt(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                #region MYRegion
                //foreach (string version in typeof(ApiVersions).GetEnumNames())
                //{
                //    option.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"API版本:{version}");
                //}
                #endregion

                #region 调用第三方程序包支持版本控制
                {
                    var provider =
                        app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    //默认加载最新版本的API文档
                    foreach (var description in provider.ApiVersionDescriptions.Reverse())
                    {
                        option.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            $"yanfan API {description.GroupName.ToUpperInvariant()}");
                    }
                }
                #endregion
            });
        }
    }
}

