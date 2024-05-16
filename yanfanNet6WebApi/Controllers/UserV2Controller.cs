using Microsoft.AspNetCore.Mvc;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

[ApiController]
[Route("[controller]")]
//[ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiVersions.V2))]
public class UserV2Controller : ControllerBase
{

    private readonly ILogger<UserV2Controller> _logger;

    public UserV2Controller(ILogger<UserV2Controller> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public User GetUser()
    {
        return new()
        {
            Id = 234,
            Name = "Ric",
            Age = 18
        };
    }

    /// <summary>
    /// 新增用户信息
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public int AddUser(User user)
    {
        return 1;
    }

    /// <summary>
    /// 修改用户信息
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public int UpdateUser(User user)
    {
        return 1;
    }

    /// <summary>
    /// 删除用户信息
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public int DeleteUser(int userId)
    {
        return 1;
    }
}

