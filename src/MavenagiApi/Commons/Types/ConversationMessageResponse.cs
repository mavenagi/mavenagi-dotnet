// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(ConversationMessageResponse.JsonConverter))]
[Serializable]
public record ConversationMessageResponse
{
    internal ConversationMessageResponse(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConversationMessageResponse with <see cref="ConversationMessageResponse.User"/>.
    /// </summary>
    public ConversationMessageResponse(ConversationMessageResponse.User value)
    {
        Type = "user";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationMessageResponse with <see cref="ConversationMessageResponse.Bot"/>.
    /// </summary>
    public ConversationMessageResponse(ConversationMessageResponse.Bot value)
    {
        Type = "bot";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "user"
    /// </summary>
    public bool IsUser => Type == "user";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "bot"
    /// </summary>
    public bool IsBot => Type == "bot";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.UserMessage"/> if <see cref="Type"/> is 'user', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'user'.</exception>
    public MavenagiApi.UserMessage AsUser() =>
        IsUser
            ? (MavenagiApi.UserMessage)Value!
            : throw new Exception("ConversationMessageResponse.Type is not 'user'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.BotMessage"/> if <see cref="Type"/> is 'bot', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'bot'.</exception>
    public MavenagiApi.BotMessage AsBot() =>
        IsBot
            ? (MavenagiApi.BotMessage)Value!
            : throw new Exception("ConversationMessageResponse.Type is not 'bot'");

    public T Match<T>(
        Func<MavenagiApi.UserMessage, T> onUser,
        Func<MavenagiApi.BotMessage, T> onBot,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "user" => onUser(AsUser()),
            "bot" => onBot(AsBot()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.UserMessage> onUser,
        Action<MavenagiApi.BotMessage> onBot,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "user":
                onUser(AsUser());
                break;
            case "bot":
                onBot(AsBot());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.UserMessage"/> and returns true if successful.
    /// </summary>
    public bool TryAsUser(out MavenagiApi.UserMessage? value)
    {
        if (Type == "user")
        {
            value = (MavenagiApi.UserMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.BotMessage"/> and returns true if successful.
    /// </summary>
    public bool TryAsBot(out MavenagiApi.BotMessage? value)
    {
        if (Type == "bot")
        {
            value = (MavenagiApi.BotMessage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationMessageResponse(
        ConversationMessageResponse.User value
    ) => new(value);

    public static implicit operator ConversationMessageResponse(
        ConversationMessageResponse.Bot value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ConversationMessageResponse>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConversationMessageResponse).IsAssignableFrom(typeToConvert);

        public override ConversationMessageResponse Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            var value = discriminator switch
            {
                "user" => json.Deserialize<MavenagiApi.UserMessage>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.UserMessage"),
                "bot" => json.Deserialize<MavenagiApi.BotMessage>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.BotMessage"),
                _ => json.Deserialize<object?>(options),
            };
            return new ConversationMessageResponse(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationMessageResponse value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "user" => JsonSerializer.SerializeToNode(value.Value, options),
                    "bot" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for user
    /// </summary>
    [Serializable]
    public struct User
    {
        public User(MavenagiApi.UserMessage value)
        {
            Value = value;
        }

        internal MavenagiApi.UserMessage Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator User(MavenagiApi.UserMessage value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for bot
    /// </summary>
    [Serializable]
    public struct Bot
    {
        public Bot(MavenagiApi.BotMessage value)
        {
            Value = value;
        }

        internal MavenagiApi.BotMessage Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Bot(MavenagiApi.BotMessage value) => new(value);
    }
}
