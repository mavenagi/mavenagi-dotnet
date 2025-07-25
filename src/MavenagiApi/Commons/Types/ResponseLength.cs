using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<ResponseLength>))]
[Serializable]
public readonly record struct ResponseLength : IStringEnum
{
    public static readonly ResponseLength Short = new(Values.Short);

    public static readonly ResponseLength Medium = new(Values.Medium);

    public static readonly ResponseLength Long = new(Values.Long);

    public ResponseLength(string value)
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
    public static ResponseLength FromCustom(string value)
    {
        return new ResponseLength(value);
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

    public static bool operator ==(ResponseLength value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResponseLength value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResponseLength value) => value.Value;

    public static explicit operator ResponseLength(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Short = "SHORT";

        public const string Medium = "MEDIUM";

        public const string Long = "LONG";
    }
}
