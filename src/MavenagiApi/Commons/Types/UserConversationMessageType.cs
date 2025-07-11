using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<UserConversationMessageType>))]
[Serializable]
public readonly record struct UserConversationMessageType : IStringEnum
{
    public static readonly UserConversationMessageType User = new(Values.User);

    public static readonly UserConversationMessageType HumanAgent = new(Values.HumanAgent);

    public static readonly UserConversationMessageType ExternalSystem = new(Values.ExternalSystem);

    public UserConversationMessageType(string value)
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
    public static UserConversationMessageType FromCustom(string value)
    {
        return new UserConversationMessageType(value);
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

    public static bool operator ==(UserConversationMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserConversationMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserConversationMessageType value) => value.Value;

    public static explicit operator UserConversationMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string User = "USER";

        public const string HumanAgent = "HUMAN_AGENT";

        public const string ExternalSystem = "EXTERNAL_SYSTEM";
    }
}
