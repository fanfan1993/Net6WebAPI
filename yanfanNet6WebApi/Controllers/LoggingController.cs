using Microsoft.AspNetCore.Mvc;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

/// <summary>
/// 文件资源
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("[controller]/v{version:apiVersion}")]
public class LoggingController : ControllerBase
{

    private readonly ILogger<LoggingController> _logger;

    public LoggingController(ILogger<LoggingController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 获取日志信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetLog()
    {
        _logger.LogInformation("====Get APi 被调用======");
        return new JsonResult(new ApiResult<string>()
        {
            Success = true,
            Data = "日志记录",
        });
    }

}

internal class ApiResult<T>
{
    public ApiResult()
    {
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public string Data { get; set; }
}