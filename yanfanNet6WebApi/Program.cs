using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models; // 就是注释引入
using Microsoft.VisualBasic.FileIO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using yanfanNet6Interfaces;
using yanfanNet6Services;
using yanfanNet6WebApi.Utility.Route;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        // var builder = WebApplication.CreateBuilder(args);

        builder.Logging.AddLog4Net("cfgFile/log4net.Config");
        // Add services to the container

        builder.Services
            .AddControllers(option => {
            // 全局路由加上 api/ 这个
            option.Conventions.Insert(0, new RouteConvention(new RouteAttribute("api/")));
            })
            // 解决中文乱码问题
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        #region 添加API版本控制的支持
        {
            // 添加API版本支持
            builder.Services.AddApiVersioning(o =>
            {
                //是否在响应的header信息中返回API版本信息
                o.ReportApiVersions = true;
                //默认的API版本
                o.DefaultApiVersion = new ApiVersion(1, 0);
                //未指定API版本时，设置API版本为默认的版本
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            //配置API版本信息
            builder.Services.AddVersionedApiExplorer(option =>
            {
                //api版本分组名称
                option.GroupNameFormat = "'v'VVVV";
                //未指定API版本时，设置API版本为默认的版本
                option.AssumeDefaultVersionWhenUnspecified = true;
            });
        }
        #endregion




        // 关于swagger 完整配置
        //SwaggerExtension.AddSwaggerGenExt();
        builder.AddSwaggerGenExt();


        #region 注册抽象和具体之间的关系
        builder.Services.AddTransient<ITestServiceA, TestServiceA>();
        builder.Services.AddTransient<ITestServiceB, TestServiceB>();
        #endregion

        WebApplication app = builder.Build();
        //var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // 等于下面的代码
            //SwaggerExtension.UseSwaggerExt(app);
            // 关于swagger 中间件的引入
            app.UseSwaggerExt();

            //app.UseSwagger();
            //app.UseSwaggerUI(option => {
            //    foreach (string version in typeof(ApiVersions).GetEnumNames())
            //    {
            //        option.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"API版本:{version}");
            //    }
            //});
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

