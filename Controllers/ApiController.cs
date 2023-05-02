using ApiResultExpression.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiResultExpression.Controllers;
public abstract class ApiController : ControllerBase
{
    public IActionResult ApiReturn<T>(T? data) => data switch
    {
        ValidationResult validation => HandleValidation(validation),
        IApiResult result => HandleApiResult(result),
        _ => HandleResult(data)
    };

    IActionResult HandleValidation(ValidationResult result) =>
        result.IsValid
            ? Ok(result)
            : BadRequest(result.Message);

    IActionResult HandleApiResult(IApiResult result) =>
        result.Error
            ? BadRequest(result.Message)
            : Ok(result);

    IActionResult HandleResult<T>(T? data) =>
        data is null
            ? BadRequest(data)
            : Ok(data);
}