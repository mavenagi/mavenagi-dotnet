using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<OsType>))]
[Serializable]
public readonly record struct OsType : IStringEnum
{
    public static readonly OsType Windows = new(Values.Windows);

    public static readonly OsType Macos = new(Values.Macos);

    public static readonly OsType Linux = new(Values.Linux);

    public static readonly OsType Android = new(Values.Android);

    public static readonly OsType Ios = new(Values.Ios);

    public static readonly OsType Other = new(Values.Other);

    public OsType(string value)
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
    public static OsType FromCustom(string value)
    {
        return new OsType(value);
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

    public static bool operator ==(OsType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(OsType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(OsType value) => value.Value;

    public static explicit operator OsType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Windows = "WINDOWS";

        public const string Macos = "MACOS";

        public const string Linux = "LINUX";

        public const string Android = "ANDROID";

        public const string Ios = "IOS";

        public const string Other = "OTHER";
    }
}
