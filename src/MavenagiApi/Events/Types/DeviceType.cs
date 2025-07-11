using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<DeviceType>))]
[Serializable]
public readonly record struct DeviceType : IStringEnum
{
    public static readonly DeviceType Desktop = new(Values.Desktop);

    public static readonly DeviceType Mobile = new(Values.Mobile);

    public static readonly DeviceType Tablet = new(Values.Tablet);

    public static readonly DeviceType Other = new(Values.Other);

    public DeviceType(string value)
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
    public static DeviceType FromCustom(string value)
    {
        return new DeviceType(value);
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

    public static bool operator ==(DeviceType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(DeviceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeviceType value) => value.Value;

    public static explicit operator DeviceType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Desktop = "DESKTOP";

        public const string Mobile = "MOBILE";

        public const string Tablet = "TABLET";

        public const string Other = "OTHER";
    }
}
