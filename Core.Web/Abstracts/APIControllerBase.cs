using Core.Web.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core.Web.Abstracts;

public partial class APIControllerBase : ControllerBase
{
    public APIResult<T> ApiResult<T>(string message, bool status, T? data = default)
    {
        return new APIResult<T>(message, status, data);
    }

    public APIResult<T> ApiResult<T>(string message, bool status, T? data = default, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new APIResult<T>(message, status, data, statusCode);
    }
}
