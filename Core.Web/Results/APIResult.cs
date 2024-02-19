using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Results;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Web.Results;

public class APIResult<T> : IAPIResult<T>, IActionResult
{
    public bool Status { get; set; }
    public string Message { get; set; } = "";
    public T? Data { get; set; }//default;

    [JsonIgnore]
    public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;

    public APIResult(string message, bool status, T? data = default)
    {
        Message = message;
        Status = status;
        Data = data;
    }

    public APIResult(string message, bool status, T? data = default, HttpStatusCode code = HttpStatusCode.OK)
    {
        Message = message;
        Status = status;
        Data = data;
        Code = code;
    }

    public Task ExecuteResultAsync(ActionContext context)
    {
        return Task.Run(async () =>
        {
            var is_development = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production") == "Development";
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)Code;

            var result = new
            {
                Message,
                Status,
                Data
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = is_development,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                MaxDepth = 0,
                //ReferenceHandler = ReferenceHandler.Preserve
            };

            await response.WriteAsync(JsonSerializer.Serialize<object>(result, options));
        });
    }
}
