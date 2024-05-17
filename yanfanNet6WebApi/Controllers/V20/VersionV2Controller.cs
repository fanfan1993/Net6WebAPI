using Microsoft.AspNetCore.Mvc;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

/// <summary>
/// 文件资源
/// </summary>
/// 
[ApiController]
[Route("[controller]")]
[ApiVersion("2.0")]
[Route("[controller]/v{version:apiVersion}")]
//[ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiVersions.V3))]
public class VersionV2Controller : ControllerBase
{

    private readonly ILogger<VersionV2Controller> _logger;

    public VersionV2Controller(ILogger<VersionV2Controller> logger)
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
            Name = " 版本号2.0-来着yanfan",
            Age = 18
        };
    }

}

