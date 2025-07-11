using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<EventField>))]
[Serializable]
public readonly record struct EventField : IStringEnum
{
    public static readonly EventField CreatedAt = new(Values.CreatedAt);

    public EventField(string value)
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
    public static EventField FromCustom(string value)
    {
        return new EventField(value);
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

    public static bool operator ==(EventField value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(EventField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventField value) => value.Value;

    public static explicit operator EventField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CreatedAt = "CREATED_AT";
    }
}
