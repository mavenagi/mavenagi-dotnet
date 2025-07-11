using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<AppUserIdentifyingPropertyType>))]
[Serializable]
public readonly record struct AppUserIdentifyingPropertyType : IStringEnum
{
    public static readonly AppUserIdentifyingPropertyType Email = new(Values.Email);

    public static readonly AppUserIdentifyingPropertyType PhoneNumber = new(Values.PhoneNumber);

    public AppUserIdentifyingPropertyType(string value)
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
    public static AppUserIdentifyingPropertyType FromCustom(string value)
    {
        return new AppUserIdentifyingPropertyType(value);
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

    public static bool operator ==(AppUserIdentifyingPropertyType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AppUserIdentifyingPropertyType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AppUserIdentifyingPropertyType value) => value.Value;

    public static explicit operator AppUserIdentifyingPropertyType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Email = "EMAIL";

        public const string PhoneNumber = "PHONE_NUMBER";
    }
}
