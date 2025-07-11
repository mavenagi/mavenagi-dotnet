using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StringEnumSerializer<ConversationField>))]
[Serializable]
public readonly record struct ConversationField : IStringEnum
{
    public static readonly ConversationField Category = new(Values.Category);

    public static readonly ConversationField FirstResponseTime = new(Values.FirstResponseTime);

    public static readonly ConversationField HandleTime = new(Values.HandleTime);

    public static readonly ConversationField HumanAgents = new(Values.HumanAgents);

    public static readonly ConversationField HumanAgentsWithInserts = new(
        Values.HumanAgentsWithInserts
    );

    public static readonly ConversationField App = new(Values.App);

    public static readonly ConversationField Sentiment = new(Values.Sentiment);

    public static readonly ConversationField QualityReason = new(Values.QualityReason);

    public static readonly ConversationField ResolutionStatus = new(Values.ResolutionStatus);

    public static readonly ConversationField Quality = new(Values.Quality);

    public static readonly ConversationField Users = new(Values.Users);

    public static readonly ConversationField ResponseLength = new(Values.ResponseLength);

    public static readonly ConversationField ThumbsUpCount = new(Values.ThumbsUpCount);

    public static readonly ConversationField ThumbsDownCount = new(Values.ThumbsDownCount);

    public static readonly ConversationField InsertCount = new(Values.InsertCount);

    public static readonly ConversationField Tags = new(Values.Tags);

    public static readonly ConversationField UserMessageCount = new(Values.UserMessageCount);

    public static readonly ConversationField Languages = new(Values.Languages);

    public static readonly ConversationField Actions = new(Values.Actions);

    public static readonly ConversationField IncompleteActions = new(Values.IncompleteActions);

    public static readonly ConversationField Sources = new(Values.Sources);

    public static readonly ConversationField CreatedAt = new(Values.CreatedAt);

    public ConversationField(string value)
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
    public static ConversationField FromCustom(string value)
    {
        return new ConversationField(value);
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

    public static bool operator ==(ConversationField value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConversationField value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConversationField value) => value.Value;

    public static explicit operator ConversationField(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Category = "Category";

        public const string FirstResponseTime = "FirstResponseTime";

        public const string HandleTime = "HandleTime";

        public const string HumanAgents = "HumanAgents";

        public const string HumanAgentsWithInserts = "HumanAgentsWithInserts";

        public const string App = "App";

        public const string Sentiment = "Sentiment";

        public const string QualityReason = "QualityReason";

        public const string ResolutionStatus = "ResolutionStatus";

        public const string Quality = "Quality";

        public const string Users = "Users";

        public const string ResponseLength = "ResponseLength";

        public const string ThumbsUpCount = "ThumbsUpCount";

        public const string ThumbsDownCount = "ThumbsDownCount";

        public const string InsertCount = "InsertCount";

        public const string Tags = "Tags";

        public const string UserMessageCount = "UserMessageCount";

        public const string Languages = "Languages";

        public const string Actions = "Actions";

        public const string IncompleteActions = "IncompleteActions";

        public const string Sources = "Sources";

        public const string CreatedAt = "CreatedAt";
    }
}
