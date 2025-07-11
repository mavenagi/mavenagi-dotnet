using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<AgentEnvironment>))]
[Serializable]
public readonly record struct AgentEnvironment : IStringEnum
{
    public static readonly AgentEnvironment Demo = new(Values.Demo);

    public static readonly AgentEnvironment Staging = new(Values.Staging);

    public static readonly AgentEnvironment Production = new(Values.Production);

    public AgentEnvironment(string value)
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
    public static AgentEnvironment FromCustom(string value)
    {
        return new AgentEnvironment(value);
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

    public static bool operator ==(AgentEnvironment value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AgentEnvironment value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AgentEnvironment value) => value.Value;

    public static explicit operator AgentEnvironment(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Demo = "DEMO";

        public const string Staging = "STAGING";

        public const string Production = "PRODUCTION";
    }
}
