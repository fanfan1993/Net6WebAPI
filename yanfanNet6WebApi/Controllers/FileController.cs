using Microsoft.AspNetCore.Mvc;
using yanfanNet6WebApi.Utility.Swagger;

namespace yanfanNet6WebApi.Controllers;

/// <summary>
/// 文件资源
/// </summary>
[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{

    private readonly ILogger<FileController> _logger;

    public FileController(ILogger<FileController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 文件上传
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public JsonResult UpLoadFile(IFormCollection form)
    {
        return new JsonResult(new
        {
            Success = 234,
            Message = "上传成功",
            FileName = form.Files.FirstOrDefault()?.FileName
        });
    }

}

