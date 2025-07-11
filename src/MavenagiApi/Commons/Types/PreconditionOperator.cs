using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<PreconditionOperator>))]
[Serializable]
public readonly record struct PreconditionOperator : IStringEnum
{
    public static readonly PreconditionOperator Not = new(Values.Not);

    public PreconditionOperator(string value)
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
    public static PreconditionOperator FromCustom(string value)
    {
        return new PreconditionOperator(value);
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

    public static bool operator ==(PreconditionOperator value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreconditionOperator value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreconditionOperator value) => value.Value;

    public static explicit operator PreconditionOperator(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Not = "NOT";
    }
}
