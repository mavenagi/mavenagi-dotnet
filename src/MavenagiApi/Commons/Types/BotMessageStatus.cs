using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<BotMessageStatus>))]
[Serializable]
public readonly record struct BotMessageStatus : IStringEnum
{
    public static readonly BotMessageStatus Sending = new(Values.Sending);

    public static readonly BotMessageStatus Sent = new(Values.Sent);

    public static readonly BotMessageStatus Rejected = new(Values.Rejected);

    public static readonly BotMessageStatus Canceled = new(Values.Canceled);

    public static readonly BotMessageStatus Failed = new(Values.Failed);

    public static readonly BotMessageStatus Unknown = new(Values.Unknown);

    public BotMessageStatus(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static BotMessageStatus FromCustom(string value)
    {
        return new BotMessageStatus(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(BotMessageStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BotMessageStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BotMessageStatus value) => value.Value;

    public static explicit operator BotMessageStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Sending = "SENDING";

        public const string Sent = "SENT";

        public const string Rejected = "REJECTED";

        public const string Canceled = "CANCELED";

        public const string Failed = "FAILED";

        public const string Unknown = "UNKNOWN";
    }
}
