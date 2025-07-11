using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<PreconditionGroupOperator>))]
[Serializable]
public readonly record struct PreconditionGroupOperator : IStringEnum
{
    public static readonly PreconditionGroupOperator And = new(Values.And);

    public static readonly PreconditionGroupOperator Or = new(Values.Or);

    public PreconditionGroupOperator(string value)
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
    public static PreconditionGroupOperator FromCustom(string value)
    {
        return new PreconditionGroupOperator(value);
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

    public static bool operator ==(PreconditionGroupOperator value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreconditionGroupOperator value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreconditionGroupOperator value) => value.Value;

    public static explicit operator PreconditionGroupOperator(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string And = "AND";

        public const string Or = "OR";
    }
}
