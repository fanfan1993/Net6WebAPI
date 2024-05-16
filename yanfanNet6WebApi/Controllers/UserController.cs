using Microsoft.AspNetCore.Mvc;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

[ApiController]
[Route("[controller]")]
//[ApiVersion("1.0")]
//[ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiVersions.V1))]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "User")]
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
    /// 获取用户ID
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    //[Route("{userId}")]
    [Route("GetUserById/{userId:int}")]
    public User GetUserById(int userId)
    {
        return new()
        {
            Id = 234,
            Name = "Ric",
            Age = 18
        };
    }

    /// <summary>
    /// 分页查询用户信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{userId}/{pageSize}/{pageIndex}")]
    public User GetPageUser(int userId, int pageIndex, int pageSize)
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
    [HttpPost(Name = "User")]
    public int AddUser(User user)
    {
        return 1;
    }

    /// <summary>
    /// 修改用户信息
    /// </summary>
    /// <returns></returns>
    [HttpPut(Name = "User")]
    public int UpdateUser(User user)
    {
        return 1;
    }

    /// <summary>
    /// 删除用户信息
    /// </summary>
    /// <returns></returns>
    [HttpDelete(Name = "User")]
    public int DeleteUser(int userId)
    {
        return 1;
    }
}

