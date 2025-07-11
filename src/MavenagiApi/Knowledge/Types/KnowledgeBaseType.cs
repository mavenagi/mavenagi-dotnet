using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<KnowledgeBaseType>))]
[Serializable]
public readonly record struct KnowledgeBaseType : IStringEnum
{
    public static readonly KnowledgeBaseType Api = new(Values.Api);

    public KnowledgeBaseType(string value)
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
    public static KnowledgeBaseType FromCustom(string value)
    {
        return new KnowledgeBaseType(value);
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

    public static bool operator ==(KnowledgeBaseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseType value) => value.Value;

    public static explicit operator KnowledgeBaseType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Api = "API";
    }
}
