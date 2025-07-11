using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<InboxItemFixType>))]
[Serializable]
public readonly record struct InboxItemFixType : IStringEnum
{
    /// <summary>
    /// The inbox item fix is to deactivate a knowledge base document.
    /// </summary>
    public static readonly InboxItemFixType RemoveDocument = new(Values.RemoveDocument);

    /// <summary>
    /// The inbox item fix is to add a new knowledge base document.
    /// </summary>
    public static readonly InboxItemFixType AddDocument = new(Values.AddDocument);

    public InboxItemFixType(string value)
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
    public static InboxItemFixType FromCustom(string value)
    {
        return new InboxItemFixType(value);
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

    public static bool operator ==(InboxItemFixType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InboxItemFixType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InboxItemFixType value) => value.Value;

    public static explicit operator InboxItemFixType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// The inbox item fix is to deactivate a knowledge base document.
        /// </summary>
        public const string RemoveDocument = "REMOVE_DOCUMENT";

        /// <summary>
        /// The inbox item fix is to add a new knowledge base document.
        /// </summary>
        public const string AddDocument = "ADD_DOCUMENT";
    }
}
