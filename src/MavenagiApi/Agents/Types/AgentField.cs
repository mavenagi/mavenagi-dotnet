using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<AgentField>))]
[Serializable]
public readonly record struct AgentField : IStringEnum
{
    public static readonly AgentField CreatedAt = new(Values.CreatedAt);

    public static readonly AgentField Environment = new(Values.Environment);

    public AgentField(string value)
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
    public static AgentField FromCustom(string value)
    {
        return new AgentField(value);
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

    public static bool operator ==(AgentField value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(AgentField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentField value) => value.Value;

    public static explicit operator AgentField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CreatedAt = "CREATED_AT";

        public const string Environment = "ENVIRONMENT";
    }
}
