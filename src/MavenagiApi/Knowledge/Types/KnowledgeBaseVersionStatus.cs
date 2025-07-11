using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<KnowledgeBaseVersionStatus>))]
[Serializable]
public readonly record struct KnowledgeBaseVersionStatus : IStringEnum
{
    public static readonly KnowledgeBaseVersionStatus Succeeded = new(Values.Succeeded);

    public static readonly KnowledgeBaseVersionStatus Failed = new(Values.Failed);

    public static readonly KnowledgeBaseVersionStatus InProgress = new(Values.InProgress);

    public KnowledgeBaseVersionStatus(string value)
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
    public static KnowledgeBaseVersionStatus FromCustom(string value)
    {
        return new KnowledgeBaseVersionStatus(value);
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

    public static bool operator ==(KnowledgeBaseVersionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseVersionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseVersionStatus value) => value.Value;

    public static explicit operator KnowledgeBaseVersionStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Succeeded = "SUCCEEDED";

        public const string Failed = "FAILED";

        public const string InProgress = "IN_PROGRESS";
    }
}
