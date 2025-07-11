// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(Precondition.JsonConverter))]
[Serializable]
public record Precondition
{
    internal Precondition(string type, object? value)
    {
        PreconditionType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of Precondition with <see cref="Precondition.User"/>.
    /// </summary>
    public Precondition(Precondition.User value)
    {
        PreconditionType = "user";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Precondition with <see cref="Precondition.Conversation"/>.
    /// </summary>
    public Precondition(Precondition.Conversation value)
    {
        PreconditionType = "conversation";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of Precondition with <see cref="Precondition.Group"/>.
    /// </summary>
    public Precondition(Precondition.Group value)
    {
        PreconditionType = "group";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("preconditionType")]
    public string PreconditionType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="PreconditionType"/> is "user"
    /// </summary>
    public bool IsUser => PreconditionType == "user";

    /// <summary>
    /// Returns true if <see cref="PreconditionType"/> is "conversation"
    /// </summary>
    public bool IsConversation => PreconditionType == "conversation";

    /// <summary>
    /// Returns true if <see cref="PreconditionType"/> is "group"
    /// </summary>
    public bool IsGroup => PreconditionType == "group";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.MetadataPrecondition"/> if <see cref="PreconditionType"/> is 'user', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="PreconditionType"/> is not 'user'.</exception>
    public MavenagiApi.MetadataPrecondition AsUser() =>
        IsUser
            ? (MavenagiApi.MetadataPrecondition)Value!
            : throw new Exception("Precondition.PreconditionType is not 'user'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationPrecondition"/> if <see cref="PreconditionType"/> is 'conversation', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="PreconditionType"/> is not 'conversation'.</exception>
    public MavenagiApi.ConversationPrecondition AsConversation() =>
        IsConversation
            ? (MavenagiApi.ConversationPrecondition)Value!
            : throw new Exception("Precondition.PreconditionType is not 'conversation'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.PreconditionGroup"/> if <see cref="PreconditionType"/> is 'group', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="PreconditionType"/> is not 'group'.</exception>
    public MavenagiApi.PreconditionGroup AsGroup() =>
        IsGroup
            ? (MavenagiApi.PreconditionGroup)Value!
            : throw new Exception("Precondition.PreconditionType is not 'group'");

    public T Match<T>(
        Func<MavenagiApi.MetadataPrecondition, T> onUser,
        Func<MavenagiApi.ConversationPrecondition, T> onConversation,
        Func<MavenagiApi.PreconditionGroup, T> onGroup,
        Func<string, object?, T> onUnknown_
    )
    {
        return PreconditionType switch
        {
            "user" => onUser(AsUser()),
            "conversation" => onConversation(AsConversation()),
            "group" => onGroup(AsGroup()),
            _ => onUnknown_(PreconditionType, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.MetadataPrecondition> onUser,
        Action<MavenagiApi.ConversationPrecondition> onConversation,
        Action<MavenagiApi.PreconditionGroup> onGroup,
        Action<string, object?> onUnknown_
    )
    {
        switch (PreconditionType)
        {
            case "user":
                onUser(AsUser());
                break;
            case "conversation":
                onConversation(AsConversation());
                break;
            case "group":
                onGroup(AsGroup());
                break;
            default:
                onUnknown_(PreconditionType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.MetadataPrecondition"/> and returns true if successful.
    /// </summary>
    public bool TryAsUser(out MavenagiApi.MetadataPrecondition? value)
    {
        if (PreconditionType == "user")
        {
            value = (MavenagiApi.MetadataPrecondition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationPrecondition"/> and returns true if successful.
    /// </summary>
    public bool TryAsConversation(out MavenagiApi.ConversationPrecondition? value)
    {
        if (PreconditionType == "conversation")
        {
            value = (MavenagiApi.ConversationPrecondition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.PreconditionGroup"/> and returns true if successful.
    /// </summary>
    public bool TryAsGroup(out MavenagiApi.PreconditionGroup? value)
    {
        if (PreconditionType == "group")
        {
            value = (MavenagiApi.PreconditionGroup)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator Precondition(Precondition.User value) => new(value);

    public static implicit operator Precondition(Precondition.Conversation value) => new(value);

    public static implicit operator Precondition(Precondition.Group value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<Precondition>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(Precondition).IsAssignableFrom(typeToConvert);

        public override Precondition Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("preconditionType", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'preconditionType'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'preconditionType' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'preconditionType' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'preconditionType' is null");

            var value = discriminator switch
            {
                "user" => json.Deserialize<MavenagiApi.MetadataPrecondition>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.MetadataPrecondition"
                    ),
                "conversation" => json.GetProperty("value")
                    .Deserialize<MavenagiApi.ConversationPrecondition>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationPrecondition"
                    ),
                "group" => json.Deserialize<MavenagiApi.PreconditionGroup>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.PreconditionGroup"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new Precondition(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Precondition value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.PreconditionType switch
                {
                    "user" => JsonSerializer.SerializeToNode(value.Value, options),
                    "conversation" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "group" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["preconditionType"] = value.PreconditionType;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for user
    /// </summary>
    [Serializable]
    public struct User
    {
        public User(MavenagiApi.MetadataPrecondition value)
        {
            Value = value;
        }

        internal MavenagiApi.MetadataPrecondition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator User(MavenagiApi.MetadataPrecondition value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for conversation
    /// </summary>
    [Serializable]
    public struct Conversation
    {
        public Conversation(MavenagiApi.ConversationPrecondition value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationPrecondition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Conversation(MavenagiApi.ConversationPrecondition value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for group
    /// </summary>
    [Serializable]
    public struct Group
    {
        public Group(MavenagiApi.PreconditionGroup value)
        {
            Value = value;
        }

        internal MavenagiApi.PreconditionGroup Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Group(MavenagiApi.PreconditionGroup value) => new(value);
    }
}
