using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<BrowserType>))]
[Serializable]
public readonly record struct BrowserType : IStringEnum
{
    public static readonly BrowserType Chrome = new(Values.Chrome);

    public static readonly BrowserType Firefox = new(Values.Firefox);

    public static readonly BrowserType Safari = new(Values.Safari);

    public static readonly BrowserType Opera = new(Values.Opera);

    public static readonly BrowserType Edge = new(Values.Edge);

    public static readonly BrowserType Other = new(Values.Other);

    public BrowserType(string value)
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
    public static BrowserType FromCustom(string value)
    {
        return new BrowserType(value);
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

    public static bool operator ==(BrowserType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BrowserType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BrowserType value) => value.Value;

    public static explicit operator BrowserType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Chrome = "CHROME";

        public const string Firefox = "FIREFOX";

        public const string Safari = "SAFARI";

        public const string Opera = "OPERA";

        public const string Edge = "EDGE";

        public const string Other = "OTHER";
    }
}
