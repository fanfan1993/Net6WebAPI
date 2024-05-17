using Microsoft.AspNetCore.Mvc;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

/// <summary>
/// 文件资源
/// </summary>
/// 
[ApiController]
[ApiVersion("1.0")]
[Route("[controller]/v{version:apiVersion}")]
//[Route("[controller]")]
//[ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiVersions.V3))]
public class VersionController : ControllerBase
{

    private readonly ILogger<VersionController> _logger;

    public VersionController(ILogger<VersionController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 获取版本号
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public User GetVersion()
    {
        return new()
        {
            Id = 234,
            Name = " 版本号1.0-来着yanfan",
            Age = 18
        };
    }

}

