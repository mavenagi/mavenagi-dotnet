using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<SystemEventName>))]
[Serializable]
public readonly record struct SystemEventName : IStringEnum
{
    /// <summary>
    /// An app was installed
    /// </summary>
    public static readonly SystemEventName AppInstalled = new(Values.AppInstalled);

    /// <summary>
    /// An app was uninstalled
    /// </summary>
    public static readonly SystemEventName AppUninstalled = new(Values.AppUninstalled);

    /// <summary>
    /// An app was updated
    /// </summary>
    public static readonly SystemEventName AppUpdated = new(Values.AppUpdated);

    public SystemEventName(string value)
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
    public static SystemEventName FromCustom(string value)
    {
        return new SystemEventName(value);
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

    public static bool operator ==(SystemEventName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SystemEventName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SystemEventName value) => value.Value;

    public static explicit operator SystemEventName(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// An app was installed
        /// </summary>
        public const string AppInstalled = "APP_INSTALLED";

        /// <summary>
        /// An app was uninstalled
        /// </summary>
        public const string AppUninstalled = "APP_UNINSTALLED";

        /// <summary>
        /// An app was updated
        /// </summary>
        public const string AppUpdated = "APP_UPDATED";
    }
}
