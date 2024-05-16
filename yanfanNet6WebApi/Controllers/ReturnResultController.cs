using Microsoft.AspNetCore.Mvc;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

/// <summary>
/// 文件资源
/// </summary>
[ApiController]
[ApiVersion("1.o")]
[Route("[controller]/v(version:apiVersion]")]
public class ReturnResultController : ControllerBase
{

    private readonly ILogger<ReturnResultController> _logger;

    public ReturnResultController(ILogger<ReturnResultController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Specific-type == 返回User
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //[HttpGet]
    //[Route("GetStudentById/{id:int}")]
    //public Student GetStudentById(int id) => new Student()
    //{
    //    Success = 234,
    //    Age = 36,
    //    name = "张三",
    //};

}

