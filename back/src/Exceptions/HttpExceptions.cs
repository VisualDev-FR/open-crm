using System.Net;

namespace OpenCRM.Exceptions;

public class HttpException : System.Exception
{
    public HttpStatusCode StatusCode { get; }

    public HttpException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public HttpException(int statusCode, string message) : base(message)
    {
        StatusCode = (HttpStatusCode)statusCode;
    }
}

public class BadRequestException : HttpException
{
    public BadRequestException(string message) : base(400, message) { }
}

public class UnhautorizedException : HttpException
{
    public UnhautorizedException(string message) : base(401, message) { }
}

public class NotFoundException : HttpException
{
    public NotFoundException(string message) : base(404, message) { }
}

