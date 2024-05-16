using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace yanfanNet6WebApi.Utility.Swagger
{
	/// <summary>
	/// 删除版本 扩展
	/// </summary>
	public class RemoveVersionFromParameter: IOperationFilter
    {
        void IOperationFilter.Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.FirstOrDefault(p => p.Name == "version");
            if (versionParameter != null)
            {
                operation.Parameters.Remove(versionParameter);
            }

        }
	}
}

