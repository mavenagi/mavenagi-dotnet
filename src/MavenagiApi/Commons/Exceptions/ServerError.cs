namespace MavenagiApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
public class ServerError(ErrorMessage body) : MavenAGIApiException("ServerError", 500, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ErrorMessage Body => body;
}
