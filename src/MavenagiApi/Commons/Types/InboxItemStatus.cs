using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<InboxItemStatus>))]
[Serializable]
public readonly record struct InboxItemStatus : IStringEnum
{
    /// <summary>
    /// The inbox item is open.
    /// </summary>
    public static readonly InboxItemStatus Open = new(Values.Open);

    /// <summary>
    /// The inbox item was resolved by the user.
    /// </summary>
    public static readonly InboxItemStatus UserResolved = new(Values.UserResolved);

    /// <summary>
    /// The inbox item was resolved by the system.
    /// </summary>
    public static readonly InboxItemStatus SystemResolved = new(Values.SystemResolved);

    /// <summary>
    /// The inbox item has regressed.
    /// </summary>
    public static readonly InboxItemStatus Regressed = new(Values.Regressed);

    /// <summary>
    /// The inbox item was ignored.
    /// </summary>
    public static readonly InboxItemStatus Ignored = new(Values.Ignored);

    public InboxItemStatus(string value)
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
    public static InboxItemStatus FromCustom(string value)
    {
        return new InboxItemStatus(value);
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

    public static bool operator ==(InboxItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InboxItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InboxItemStatus value) => value.Value;

    public static explicit operator InboxItemStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// The inbox item is open.
        /// </summary>
        public const string Open = "OPEN";

        /// <summary>
        /// The inbox item was resolved by the user.
        /// </summary>
        public const string UserResolved = "USER_RESOLVED";

        /// <summary>
        /// The inbox item was resolved by the system.
        /// </summary>
        public const string SystemResolved = "SYSTEM_RESOLVED";

        /// <summary>
        /// The inbox item has regressed.
        /// </summary>
        public const string Regressed = "REGRESSED";

        /// <summary>
        /// The inbox item was ignored.
        /// </summary>
        public const string Ignored = "IGNORED";
    }
}
