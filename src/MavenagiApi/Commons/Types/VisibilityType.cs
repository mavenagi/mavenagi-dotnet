using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<VisibilityType>))]
[Serializable]
public readonly record struct VisibilityType : IStringEnum
{
    public static readonly VisibilityType Visible = new(Values.Visible);

    public static readonly VisibilityType PartiallyVisible = new(Values.PartiallyVisible);

    public static readonly VisibilityType Hidden = new(Values.Hidden);

    public VisibilityType(string value)
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
    public static VisibilityType FromCustom(string value)
    {
        return new VisibilityType(value);
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

    public static bool operator ==(VisibilityType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VisibilityType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VisibilityType value) => value.Value;

    public static explicit operator VisibilityType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Visible = "VISIBLE";

        public const string PartiallyVisible = "PARTIALLY_VISIBLE";

        public const string Hidden = "HIDDEN";
    }
}
