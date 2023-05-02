using ApiResultExpression.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiResultExpression.Controllers;

[Route("api/[controller]")]
public class AppController : ApiController
{
    [HttpGet("[action]")]
    public IActionResult GetData() =>
        ApiReturn(new AppData
        {
            Id = 1,
            Name = "Important Data"
        });

    [HttpGet("[action]")]
    public IActionResult GetNullData() =>
        ApiReturn<AppData>(null);

    [HttpGet("[action]")]
    public IActionResult GetApiResult() =>
        ApiReturn<ApiResult<AppData>>(
            new(
                new AppData
                {
                    Id = 2,
                    Name = "Actioned Data"
                },
                "Successfully actioned data"
            )
        );

    [HttpGet("[action]")]
    public IActionResult GetApiException() =>
        ApiReturn(
            new ApiResult<AppData>(
                "Operate",
                new Exception("Invalid app data operation!")
            )
        );

    [HttpGet("[action]")]
    public IActionResult GetValidResult() =>
        ApiReturn(new ValidationResult());

    [HttpGet("[action]")]
    public IActionResult GetInvalidResult() =>
        ApiReturn(new ValidationResult("Invalid data"));
}