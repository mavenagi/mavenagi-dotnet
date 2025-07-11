using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<QualityReason>))]
[Serializable]
public readonly record struct QualityReason : IStringEnum
{
    public static readonly QualityReason MissingKnowledge = new(Values.MissingKnowledge);

    public static readonly QualityReason MissingUserInformation = new(
        Values.MissingUserInformation
    );

    public static readonly QualityReason MissingAction = new(Values.MissingAction);

    public static readonly QualityReason NeedsUserClarification = new(
        Values.NeedsUserClarification
    );

    public static readonly QualityReason UnsupportedFormat = new(Values.UnsupportedFormat);

    public static readonly QualityReason Interrupted = new(Values.Interrupted);

    public static readonly QualityReason UnsupportedUserBehavior = new(
        Values.UnsupportedUserBehavior
    );

    public static readonly QualityReason Unknown = new(Values.Unknown);

    public QualityReason(string value)
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
    public static QualityReason FromCustom(string value)
    {
        return new QualityReason(value);
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

    public static bool operator ==(QualityReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QualityReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QualityReason value) => value.Value;

    public static explicit operator QualityReason(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string MissingKnowledge = "MISSING_KNOWLEDGE";

        public const string MissingUserInformation = "MISSING_USER_INFORMATION";

        public const string MissingAction = "MISSING_ACTION";

        public const string NeedsUserClarification = "NEEDS_USER_CLARIFICATION";

        public const string UnsupportedFormat = "UNSUPPORTED_FORMAT";

        public const string Interrupted = "INTERRUPTED";

        public const string UnsupportedUserBehavior = "UNSUPPORTED_USER_BEHAVIOR";

        public const string Unknown = "UNKNOWN";
    }
}
