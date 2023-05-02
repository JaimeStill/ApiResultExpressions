namespace ApiResultExpression.Models;
public interface IApiResult
{
    string Message { get; set; }
    public bool Error { get; set; }
}