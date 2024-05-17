using System;
using Microsoft.AspNetCore.Mvc;
using yanfanNet6Interfaces;
using yanfanNet6Services;

using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

/// <summary>
/// 文件资源
/// </summary>
[ApiController]
[Route("[controller]")]
[ApiVersion("2.0")]
public class IocContainerController : ControllerBase
{

    private readonly ILogger<IocContainerController> _logger;

    private readonly ITestServiceA _ITestServiceA;
    private readonly ITestServiceB _ITestServiceB;
    private readonly IServiceProvider _IServiceProvider;

    public IocContainerController(ILogger<IocContainerController> logger,
        ITestServiceA iTestServiceA, ITestServiceB iTestServiceB, IServiceProvider iServiceProvider)
    {
        _logger = logger;
        _ITestServiceA = iTestServiceA;
        _ITestServiceB = iTestServiceB;
        _IServiceProvider = iServiceProvider;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iTestServiceBNew"></param>
    /// <param name="iServiceProvider"></param>
    /// <returns></returns>
    [HttpGet()]
    public string ShowA([FromServices] ITestServiceB iTestServiceBNew, [FromServices]
    IServiceProvider iServiceProvider)
    {
        //TestServiceA testServiceA = new TestServiceA();

        ITestServiceB testServiceB1 = _IServiceProvider.GetService<ITestServiceB>();
        ITestServiceB testServiceB2 = iServiceProvider.GetService<ITestServiceB>();
        return _ITestServiceA.ShowA();
    }

    [HttpPost()]
    public string ShowB()
    {
        return _ITestServiceB.ShowB();
    }
}


