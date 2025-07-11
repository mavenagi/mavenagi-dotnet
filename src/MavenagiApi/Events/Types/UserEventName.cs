using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<UserEventName>))]
[Serializable]
public readonly record struct UserEventName : IStringEnum
{
    /// <summary>
    /// A button click occurred
    /// </summary>
    public static readonly UserEventName ButtonClicked = new(Values.ButtonClicked);

    /// <summary>
    /// A link was clicked
    /// </summary>
    public static readonly UserEventName LinkClicked = new(Values.LinkClicked);

    /// <summary>
    /// The chat window was opened
    /// </summary>
    public static readonly UserEventName ChatOpened = new(Values.ChatOpened);

    /// <summary>
    /// The chat window was closed
    /// </summary>
    public static readonly UserEventName ChatClosed = new(Values.ChatClosed);

    public UserEventName(string value)
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
    public static UserEventName FromCustom(string value)
    {
        return new UserEventName(value);
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

    public static bool operator ==(UserEventName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserEventName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserEventName value) => value.Value;

    public static explicit operator UserEventName(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// A button click occurred
        /// </summary>
        public const string ButtonClicked = "BUTTON_CLICKED";

        /// <summary>
        /// A link was clicked
        /// </summary>
        public const string LinkClicked = "LINK_CLICKED";

        /// <summary>
        /// The chat window was opened
        /// </summary>
        public const string ChatOpened = "CHAT_OPENED";

        /// <summary>
        /// The chat window was closed
        /// </summary>
        public const string ChatClosed = "CHAT_CLOSED";
    }
}
