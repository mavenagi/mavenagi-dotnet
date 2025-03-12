using System;

namespace MavenagiApi;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class MavenAGIException(string message, Exception? innerException = null)
    : Exception(message, innerException);
