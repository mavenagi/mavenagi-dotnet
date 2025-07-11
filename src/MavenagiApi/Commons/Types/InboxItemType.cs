using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<InboxItemType>))]
[Serializable]
public readonly record struct InboxItemType : IStringEnum
{
    /// <summary>
    /// The inbox item is a duplicate document.
    /// </summary>
    public static readonly InboxItemType DuplicateDocument = new(Values.DuplicateDocument);

    /// <summary>
    /// The inbox item is a duplicate knowledge base.
    /// </summary>
    public static readonly InboxItemType DuplicateKnowledgeBase = new(
        Values.DuplicateKnowledgeBase
    );

    /// <summary>
    /// The inbox item is missing knowledge.
    /// </summary>
    public static readonly InboxItemType MissingKnowledge = new(Values.MissingKnowledge);

    /// <summary>
    /// The inbox item is related to a low quality knowledge base.
    /// </summary>
    public static readonly InboxItemType LowQualityKnowledgeBase = new(
        Values.LowQualityKnowledgeBase
    );

    public InboxItemType(string value)
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
    public static InboxItemType FromCustom(string value)
    {
        return new InboxItemType(value);
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

    public static bool operator ==(InboxItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(InboxItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(InboxItemType value) => value.Value;

    public static explicit operator InboxItemType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        /// <summary>
        /// The inbox item is a duplicate document.
        /// </summary>
        public const string DuplicateDocument = "DUPLICATE_DOCUMENT";

        /// <summary>
        /// The inbox item is a duplicate knowledge base.
        /// </summary>
        public const string DuplicateKnowledgeBase = "DUPLICATE_KNOWLEDGE_BASE";

        /// <summary>
        /// The inbox item is missing knowledge.
        /// </summary>
        public const string MissingKnowledge = "MISSING_KNOWLEDGE";

        /// <summary>
        /// The inbox item is related to a low quality knowledge base.
        /// </summary>
        public const string LowQualityKnowledgeBase = "LOW_QUALITY_KNOWLEDGE_BASE";
    }
}
