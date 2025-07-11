using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<ResolutionStatus>))]
[Serializable]
public readonly record struct ResolutionStatus : IStringEnum
{
    public static readonly ResolutionStatus Resolved = new(Values.Resolved);

    public static readonly ResolutionStatus Escalated = new(Values.Escalated);

    public static readonly ResolutionStatus InProgress = new(Values.InProgress);

    public ResolutionStatus(string value)
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
    public static ResolutionStatus FromCustom(string value)
    {
        return new ResolutionStatus(value);
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

    public static bool operator ==(ResolutionStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ResolutionStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ResolutionStatus value) => value.Value;

    public static explicit operator ResolutionStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Resolved = "RESOLVED";

        public const string Escalated = "ESCALATED";

        public const string InProgress = "IN_PROGRESS";
    }
}
