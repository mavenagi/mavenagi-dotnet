using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<KnowledgeDocumentContentType>))]
[Serializable]
public readonly record struct KnowledgeDocumentContentType : IStringEnum
{
    public static readonly KnowledgeDocumentContentType Html = new(Values.Html);

    public static readonly KnowledgeDocumentContentType Markdown = new(Values.Markdown);

    public KnowledgeDocumentContentType(string value)
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
    public static KnowledgeDocumentContentType FromCustom(string value)
    {
        return new KnowledgeDocumentContentType(value);
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

    public static bool operator ==(KnowledgeDocumentContentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeDocumentContentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeDocumentContentType value) => value.Value;

    public static explicit operator KnowledgeDocumentContentType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Html = "HTML";

        public const string Markdown = "MARKDOWN";
    }
}
