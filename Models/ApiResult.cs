using System.Text;

namespace ApiResultExpression.Models;
public class ApiResult<T> : IApiResult
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool Error { get; set; }

    public ApiResult() { }

    public ApiResult(string action, Exception ex)
    {
        Error = true;
        Message = BuildExceptionMessage(ex, $"{typeof(T)}.{action}");
    }

    public ApiResult(T data, string message = "Operation completed successfully")
    {
        Data = data;
        Message = message;
    }

    public ApiResult(ValidationResult validation)
    {
        Error = true;
        Message = validation.Message;
    }

    string BuildExceptionMessage(Exception ex, string? action = null)
    {
        StringBuilder sb = new();

        if (action is not null)
            sb.AppendLine(action);

        sb.AppendLine(WriteException(ex));

        if (ex.InnerException is not null)
            sb.AppendLine(BuildExceptionMessage(ex.InnerException));

        return sb.ToString();
    }

    static string WriteException(Exception ex) =>
        $"{ex.GetType()}: {ex.Message}";
}