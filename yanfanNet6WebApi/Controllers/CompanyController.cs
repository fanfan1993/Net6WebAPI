using Microsoft.AspNetCore.Mvc;

namespace yanfanNet6WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{

    private readonly ILogger<CompanyController> _logger;

    public CompanyController(ILogger<CompanyController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 获取公司信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Company GetUser()
    {
        return new()
        {
            Id = 234,
            Name = "Ric",
            AddRess = "浙江杭州"
        };
    }

    /// <summary>
    /// 新增公司信息
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public int AddCompany(Company user)
    {
        return 1;
    }

    /// <summary>
    /// 修改公司信息
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public int UpdateCompany(Company company)
    {
        return 1;
    }

    /// <summary>
    /// 删除公司信息
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public int DeleteCompany(int id)
    {
        return 1;
    }
}
