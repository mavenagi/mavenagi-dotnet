// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(ConversationPrecondition.JsonConverter))]
[Serializable]
public record ConversationPrecondition
{
    internal ConversationPrecondition(string type, object? value)
    {
        ConversationPreconditionType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConversationPrecondition with <see cref="ConversationPrecondition.Tags"/>.
    /// </summary>
    public ConversationPrecondition(ConversationPrecondition.Tags value)
    {
        ConversationPreconditionType = "tags";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationPrecondition with <see cref="ConversationPrecondition.Metadata"/>.
    /// </summary>
    public ConversationPrecondition(ConversationPrecondition.Metadata value)
    {
        ConversationPreconditionType = "metadata";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationPrecondition with <see cref="ConversationPrecondition.ActionExecuted"/>.
    /// </summary>
    public ConversationPrecondition(ConversationPrecondition.ActionExecuted value)
    {
        ConversationPreconditionType = "actionExecuted";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationPrecondition with <see cref="ConversationPrecondition.ResponseConfig"/>.
    /// </summary>
    public ConversationPrecondition(ConversationPrecondition.ResponseConfig value)
    {
        ConversationPreconditionType = "responseConfig";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationPrecondition with <see cref="ConversationPrecondition.App"/>.
    /// </summary>
    public ConversationPrecondition(ConversationPrecondition.App value)
    {
        ConversationPreconditionType = "app";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("conversationPreconditionType")]
    public string ConversationPreconditionType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="ConversationPreconditionType"/> is "tags"
    /// </summary>
    public bool IsTags => ConversationPreconditionType == "tags";

    /// <summary>
    /// Returns true if <see cref="ConversationPreconditionType"/> is "metadata"
    /// </summary>
    public bool IsMetadata => ConversationPreconditionType == "metadata";

    /// <summary>
    /// Returns true if <see cref="ConversationPreconditionType"/> is "actionExecuted"
    /// </summary>
    public bool IsActionExecuted => ConversationPreconditionType == "actionExecuted";

    /// <summary>
    /// Returns true if <see cref="ConversationPreconditionType"/> is "responseConfig"
    /// </summary>
    public bool IsResponseConfig => ConversationPreconditionType == "responseConfig";

    /// <summary>
    /// Returns true if <see cref="ConversationPreconditionType"/> is "app"
    /// </summary>
    public bool IsApp => ConversationPreconditionType == "app";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.TagsPrecondition"/> if <see cref="ConversationPreconditionType"/> is 'tags', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ConversationPreconditionType"/> is not 'tags'.</exception>
    public MavenagiApi.TagsPrecondition AsTags() =>
        IsTags
            ? (MavenagiApi.TagsPrecondition)Value!
            : throw new Exception(
                "ConversationPrecondition.ConversationPreconditionType is not 'tags'"
            );

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.MetadataPrecondition"/> if <see cref="ConversationPreconditionType"/> is 'metadata', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ConversationPreconditionType"/> is not 'metadata'.</exception>
    public MavenagiApi.MetadataPrecondition AsMetadata() =>
        IsMetadata
            ? (MavenagiApi.MetadataPrecondition)Value!
            : throw new Exception(
                "ConversationPrecondition.ConversationPreconditionType is not 'metadata'"
            );

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationExecutedActionPrecondition"/> if <see cref="ConversationPreconditionType"/> is 'actionExecuted', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ConversationPreconditionType"/> is not 'actionExecuted'.</exception>
    public MavenagiApi.ConversationExecutedActionPrecondition AsActionExecuted() =>
        IsActionExecuted
            ? (MavenagiApi.ConversationExecutedActionPrecondition)Value!
            : throw new Exception(
                "ConversationPrecondition.ConversationPreconditionType is not 'actionExecuted'"
            );

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ResponseConfigPrecondition"/> if <see cref="ConversationPreconditionType"/> is 'responseConfig', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ConversationPreconditionType"/> is not 'responseConfig'.</exception>
    public MavenagiApi.ResponseConfigPrecondition AsResponseConfig() =>
        IsResponseConfig
            ? (MavenagiApi.ResponseConfigPrecondition)Value!
            : throw new Exception(
                "ConversationPrecondition.ConversationPreconditionType is not 'responseConfig'"
            );

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.AppPrecondition"/> if <see cref="ConversationPreconditionType"/> is 'app', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="ConversationPreconditionType"/> is not 'app'.</exception>
    public MavenagiApi.AppPrecondition AsApp() =>
        IsApp
            ? (MavenagiApi.AppPrecondition)Value!
            : throw new Exception(
                "ConversationPrecondition.ConversationPreconditionType is not 'app'"
            );

    public T Match<T>(
        Func<MavenagiApi.TagsPrecondition, T> onTags,
        Func<MavenagiApi.MetadataPrecondition, T> onMetadata,
        Func<MavenagiApi.ConversationExecutedActionPrecondition, T> onActionExecuted,
        Func<MavenagiApi.ResponseConfigPrecondition, T> onResponseConfig,
        Func<MavenagiApi.AppPrecondition, T> onApp,
        Func<string, object?, T> onUnknown_
    )
    {
        return ConversationPreconditionType switch
        {
            "tags" => onTags(AsTags()),
            "metadata" => onMetadata(AsMetadata()),
            "actionExecuted" => onActionExecuted(AsActionExecuted()),
            "responseConfig" => onResponseConfig(AsResponseConfig()),
            "app" => onApp(AsApp()),
            _ => onUnknown_(ConversationPreconditionType, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.TagsPrecondition> onTags,
        Action<MavenagiApi.MetadataPrecondition> onMetadata,
        Action<MavenagiApi.ConversationExecutedActionPrecondition> onActionExecuted,
        Action<MavenagiApi.ResponseConfigPrecondition> onResponseConfig,
        Action<MavenagiApi.AppPrecondition> onApp,
        Action<string, object?> onUnknown_
    )
    {
        switch (ConversationPreconditionType)
        {
            case "tags":
                onTags(AsTags());
                break;
            case "metadata":
                onMetadata(AsMetadata());
                break;
            case "actionExecuted":
                onActionExecuted(AsActionExecuted());
                break;
            case "responseConfig":
                onResponseConfig(AsResponseConfig());
                break;
            case "app":
                onApp(AsApp());
                break;
            default:
                onUnknown_(ConversationPreconditionType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.TagsPrecondition"/> and returns true if successful.
    /// </summary>
    public bool TryAsTags(out MavenagiApi.TagsPrecondition? value)
    {
        if (ConversationPreconditionType == "tags")
        {
            value = (MavenagiApi.TagsPrecondition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.MetadataPrecondition"/> and returns true if successful.
    /// </summary>
    public bool TryAsMetadata(out MavenagiApi.MetadataPrecondition? value)
    {
        if (ConversationPreconditionType == "metadata")
        {
            value = (MavenagiApi.MetadataPrecondition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationExecutedActionPrecondition"/> and returns true if successful.
    /// </summary>
    public bool TryAsActionExecuted(out MavenagiApi.ConversationExecutedActionPrecondition? value)
    {
        if (ConversationPreconditionType == "actionExecuted")
        {
            value = (MavenagiApi.ConversationExecutedActionPrecondition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ResponseConfigPrecondition"/> and returns true if successful.
    /// </summary>
    public bool TryAsResponseConfig(out MavenagiApi.ResponseConfigPrecondition? value)
    {
        if (ConversationPreconditionType == "responseConfig")
        {
            value = (MavenagiApi.ResponseConfigPrecondition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.AppPrecondition"/> and returns true if successful.
    /// </summary>
    public bool TryAsApp(out MavenagiApi.AppPrecondition? value)
    {
        if (ConversationPreconditionType == "app")
        {
            value = (MavenagiApi.AppPrecondition)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationPrecondition(ConversationPrecondition.Tags value) =>
        new(value);

    public static implicit operator ConversationPrecondition(
        ConversationPrecondition.Metadata value
    ) => new(value);

    public static implicit operator ConversationPrecondition(
        ConversationPrecondition.ActionExecuted value
    ) => new(value);

    public static implicit operator ConversationPrecondition(
        ConversationPrecondition.ResponseConfig value
    ) => new(value);

    public static implicit operator ConversationPrecondition(ConversationPrecondition.App value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ConversationPrecondition>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConversationPrecondition).IsAssignableFrom(typeToConvert);

        public override ConversationPrecondition Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("conversationPreconditionType", out var discriminatorElement))
            {
                throw new JsonException(
                    "Missing discriminator property 'conversationPreconditionType'"
                );
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException(
                        "Discriminator property 'conversationPreconditionType' is null"
                    );
                }

                throw new JsonException(
                    $"Discriminator property 'conversationPreconditionType' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException(
                    "Discriminator property 'conversationPreconditionType' is null"
                );

            var value = discriminator switch
            {
                "tags" => json.Deserialize<MavenagiApi.TagsPrecondition>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.TagsPrecondition"
                    ),
                "metadata" => json.Deserialize<MavenagiApi.MetadataPrecondition>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.MetadataPrecondition"
                    ),
                "actionExecuted" =>
                    json.Deserialize<MavenagiApi.ConversationExecutedActionPrecondition>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize MavenagiApi.ConversationExecutedActionPrecondition"
                        ),
                "responseConfig" => json.Deserialize<MavenagiApi.ResponseConfigPrecondition>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ResponseConfigPrecondition"
                    ),
                "app" => json.Deserialize<MavenagiApi.AppPrecondition>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.AppPrecondition"),
                _ => json.Deserialize<object?>(options),
            };
            return new ConversationPrecondition(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationPrecondition value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.ConversationPreconditionType switch
                {
                    "tags" => JsonSerializer.SerializeToNode(value.Value, options),
                    "metadata" => JsonSerializer.SerializeToNode(value.Value, options),
                    "actionExecuted" => JsonSerializer.SerializeToNode(value.Value, options),
                    "responseConfig" => JsonSerializer.SerializeToNode(value.Value, options),
                    "app" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["conversationPreconditionType"] = value.ConversationPreconditionType;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for tags
    /// </summary>
    [Serializable]
    public struct Tags
    {
        public Tags(MavenagiApi.TagsPrecondition value)
        {
            Value = value;
        }

        internal MavenagiApi.TagsPrecondition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Tags(MavenagiApi.TagsPrecondition value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for metadata
    /// </summary>
    [Serializable]
    public struct Metadata
    {
        public Metadata(MavenagiApi.MetadataPrecondition value)
        {
            Value = value;
        }

        internal MavenagiApi.MetadataPrecondition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Metadata(MavenagiApi.MetadataPrecondition value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for actionExecuted
    /// </summary>
    [Serializable]
    public struct ActionExecuted
    {
        public ActionExecuted(MavenagiApi.ConversationExecutedActionPrecondition value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationExecutedActionPrecondition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ActionExecuted(
            MavenagiApi.ConversationExecutedActionPrecondition value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for responseConfig
    /// </summary>
    [Serializable]
    public struct ResponseConfig
    {
        public ResponseConfig(MavenagiApi.ResponseConfigPrecondition value)
        {
            Value = value;
        }

        internal MavenagiApi.ResponseConfigPrecondition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ResponseConfig(
            MavenagiApi.ResponseConfigPrecondition value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for app
    /// </summary>
    [Serializable]
    public struct App
    {
        public App(MavenagiApi.AppPrecondition value)
        {
            Value = value;
        }

        internal MavenagiApi.AppPrecondition Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator App(MavenagiApi.AppPrecondition value) => new(value);
    }
}
