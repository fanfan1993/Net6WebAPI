using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace yanfanNet6WebApi.Utility.Swagger
{
    /// <summary>
    /// 扩展文件上传， 展示选择文件按钮
    /// </summary>
    public class FileUploadFilter : IOperationFilter
    {
        /// <summary>
        /// 扩展文件上传， 展示选择文件按钮
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        /// 这里生成有问题
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            const string FileUploadContentType = "multipart/form-data";
            if (operation.RequestBody == null ||
                !operation.RequestBody.Content.Any(x =>
                x.Key.Equals(FileUploadContentType,
                  StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            if (context.ApiDescription.ParameterDescriptions[0].Type == typeof
                (IFormCollection))
            {
                operation.RequestBody = new OpenApiRequestBody
                {
                    Description = "文件上传",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            FileUploadContentType, new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Type = "object",
                                    Required = new HashSet<string>{"file"},
                                    Properties=new Dictionary<string, OpenApiSchema>
                                    {
                                        {
                                               "file", new OpenApiSchema()
                                               {
                                                   Type = "string",
                                                   Format = "binary"
                                               }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
            }
            //throw new NotImplementedException();
        }
    }
}

