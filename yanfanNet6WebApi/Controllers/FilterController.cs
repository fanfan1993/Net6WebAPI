using Microsoft.AspNetCore.Mvc;
using yanfanNet6WebApi.Utility.Filters;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

/// <summary>
/// 文件资源
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("2.0")]
[Route("[controller]/v{version:apiVersion}")]
public class FilterController : ControllerBase
{

    private readonly ILogger<FilterController> _logger;

    public FilterController(ILogger<FilterController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("{id:int}")]
    [CustomResourceFilterAttribute]
    public IActionResult GetUser(int id)
    {

        Console.WriteLine("==== 业务逻辑处理 ====");
        var data = new
        {
            Id = id,
            Success = 234,
            Name = "fanfan",
            DateTime = DateTime.Now.ToString()
        };

        return new JsonResult(data);
    }

}

