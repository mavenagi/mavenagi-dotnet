using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<ActionParameterType>))]
[Serializable]
public readonly record struct ActionParameterType : IStringEnum
{
    /// <summary>
    /// String parameter type for text input.
    /// </summary>
    public static readonly ActionParameterType String = new(Values.String);

    /// <summary>
    /// Boolean parameter type for true/false values.
    /// </summary>
    public static readonly ActionParameterType Boolean = new(Values.Boolean);

    /// <summary>
    /// Number parameter type for numeric values.
    /// </summary>
    public static readonly ActionParameterType Number = new(Values.Number);

    /// <summary>
    /// Schema parameter type for complex structured data that adheres to a JSON schema definition. When this type is used this should be the only action parameter (all other parameters should be omitted), the `schema` field must be set and `enumOptions` should not be used.
    /// </summary>
    public static readonly ActionParameterType Schema = new(Values.Schema);

    public ActionParameterType(string value)
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
    public static ActionParameterType FromCustom(string value)
    {
        return new ActionParameterType(value);
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

    public static bool operator ==(ActionParameterType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActionParameterType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActionParameterType value) => value.Value;

    public static explicit operator ActionParameterType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// String parameter type for text input.
        /// </summary>
        public const string String = "STRING";

        /// <summary>
        /// Boolean parameter type for true/false values.
        /// </summary>
        public const string Boolean = "BOOLEAN";

        /// <summary>
        /// Number parameter type for numeric values.
        /// </summary>
        public const string Number = "NUMBER";

        /// <summary>
        /// Schema parameter type for complex structured data that adheres to a JSON schema definition. When this type is used this should be the only action parameter (all other parameters should be omitted), the `schema` field must be set and `enumOptions` should not be used.
        /// </summary>
        public const string Schema = "SCHEMA";
    }
}
