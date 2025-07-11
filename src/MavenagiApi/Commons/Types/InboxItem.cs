// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(InboxItem.JsonConverter))]
[Serializable]
public record InboxItem
{
    internal InboxItem(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of InboxItem with <see cref="InboxItem.DuplicateKnowledgeBase"/>.
    /// </summary>
    public InboxItem(InboxItem.DuplicateKnowledgeBase value)
    {
        Type = "duplicateKnowledgeBase";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of InboxItem with <see cref="InboxItem.DuplicateDocuments"/>.
    /// </summary>
    public InboxItem(InboxItem.DuplicateDocuments value)
    {
        Type = "duplicateDocuments";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of InboxItem with <see cref="InboxItem.KnowledgeBaseAlert"/>.
    /// </summary>
    public InboxItem(InboxItem.KnowledgeBaseAlert value)
    {
        Type = "knowledgeBaseAlert";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of InboxItem with <see cref="InboxItem.MissingKnowledge"/>.
    /// </summary>
    public InboxItem(InboxItem.MissingKnowledge value)
    {
        Type = "missingKnowledge";
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
    /// Returns true if <see cref="Type"/> is "duplicateKnowledgeBase"
    /// </summary>
    public bool IsDuplicateKnowledgeBase => Type == "duplicateKnowledgeBase";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "duplicateDocuments"
    /// </summary>
    public bool IsDuplicateDocuments => Type == "duplicateDocuments";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "knowledgeBaseAlert"
    /// </summary>
    public bool IsKnowledgeBaseAlert => Type == "knowledgeBaseAlert";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "missingKnowledge"
    /// </summary>
    public bool IsMissingKnowledge => Type == "missingKnowledge";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.InboxItemDuplicateKnowledgeBase"/> if <see cref="Type"/> is 'duplicateKnowledgeBase', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'duplicateKnowledgeBase'.</exception>
    public MavenagiApi.InboxItemDuplicateKnowledgeBase AsDuplicateKnowledgeBase() =>
        IsDuplicateKnowledgeBase
            ? (MavenagiApi.InboxItemDuplicateKnowledgeBase)Value!
            : throw new Exception("InboxItem.Type is not 'duplicateKnowledgeBase'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.InboxItemDuplicateDocuments"/> if <see cref="Type"/> is 'duplicateDocuments', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'duplicateDocuments'.</exception>
    public MavenagiApi.InboxItemDuplicateDocuments AsDuplicateDocuments() =>
        IsDuplicateDocuments
            ? (MavenagiApi.InboxItemDuplicateDocuments)Value!
            : throw new Exception("InboxItem.Type is not 'duplicateDocuments'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.InboxItemKnowledgeBaseAlert"/> if <see cref="Type"/> is 'knowledgeBaseAlert', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'knowledgeBaseAlert'.</exception>
    public MavenagiApi.InboxItemKnowledgeBaseAlert AsKnowledgeBaseAlert() =>
        IsKnowledgeBaseAlert
            ? (MavenagiApi.InboxItemKnowledgeBaseAlert)Value!
            : throw new Exception("InboxItem.Type is not 'knowledgeBaseAlert'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.InboxItemMissingKnowledge"/> if <see cref="Type"/> is 'missingKnowledge', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'missingKnowledge'.</exception>
    public MavenagiApi.InboxItemMissingKnowledge AsMissingKnowledge() =>
        IsMissingKnowledge
            ? (MavenagiApi.InboxItemMissingKnowledge)Value!
            : throw new Exception("InboxItem.Type is not 'missingKnowledge'");

    public T Match<T>(
        Func<MavenagiApi.InboxItemDuplicateKnowledgeBase, T> onDuplicateKnowledgeBase,
        Func<MavenagiApi.InboxItemDuplicateDocuments, T> onDuplicateDocuments,
        Func<MavenagiApi.InboxItemKnowledgeBaseAlert, T> onKnowledgeBaseAlert,
        Func<MavenagiApi.InboxItemMissingKnowledge, T> onMissingKnowledge,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "duplicateKnowledgeBase" => onDuplicateKnowledgeBase(AsDuplicateKnowledgeBase()),
            "duplicateDocuments" => onDuplicateDocuments(AsDuplicateDocuments()),
            "knowledgeBaseAlert" => onKnowledgeBaseAlert(AsKnowledgeBaseAlert()),
            "missingKnowledge" => onMissingKnowledge(AsMissingKnowledge()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.InboxItemDuplicateKnowledgeBase> onDuplicateKnowledgeBase,
        Action<MavenagiApi.InboxItemDuplicateDocuments> onDuplicateDocuments,
        Action<MavenagiApi.InboxItemKnowledgeBaseAlert> onKnowledgeBaseAlert,
        Action<MavenagiApi.InboxItemMissingKnowledge> onMissingKnowledge,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "duplicateKnowledgeBase":
                onDuplicateKnowledgeBase(AsDuplicateKnowledgeBase());
                break;
            case "duplicateDocuments":
                onDuplicateDocuments(AsDuplicateDocuments());
                break;
            case "knowledgeBaseAlert":
                onKnowledgeBaseAlert(AsKnowledgeBaseAlert());
                break;
            case "missingKnowledge":
                onMissingKnowledge(AsMissingKnowledge());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.InboxItemDuplicateKnowledgeBase"/> and returns true if successful.
    /// </summary>
    public bool TryAsDuplicateKnowledgeBase(out MavenagiApi.InboxItemDuplicateKnowledgeBase? value)
    {
        if (Type == "duplicateKnowledgeBase")
        {
            value = (MavenagiApi.InboxItemDuplicateKnowledgeBase)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.InboxItemDuplicateDocuments"/> and returns true if successful.
    /// </summary>
    public bool TryAsDuplicateDocuments(out MavenagiApi.InboxItemDuplicateDocuments? value)
    {
        if (Type == "duplicateDocuments")
        {
            value = (MavenagiApi.InboxItemDuplicateDocuments)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.InboxItemKnowledgeBaseAlert"/> and returns true if successful.
    /// </summary>
    public bool TryAsKnowledgeBaseAlert(out MavenagiApi.InboxItemKnowledgeBaseAlert? value)
    {
        if (Type == "knowledgeBaseAlert")
        {
            value = (MavenagiApi.InboxItemKnowledgeBaseAlert)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.InboxItemMissingKnowledge"/> and returns true if successful.
    /// </summary>
    public bool TryAsMissingKnowledge(out MavenagiApi.InboxItemMissingKnowledge? value)
    {
        if (Type == "missingKnowledge")
        {
            value = (MavenagiApi.InboxItemMissingKnowledge)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator InboxItem(InboxItem.DuplicateKnowledgeBase value) => new(value);

    public static implicit operator InboxItem(InboxItem.DuplicateDocuments value) => new(value);

    public static implicit operator InboxItem(InboxItem.KnowledgeBaseAlert value) => new(value);

    public static implicit operator InboxItem(InboxItem.MissingKnowledge value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<InboxItem>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(InboxItem).IsAssignableFrom(typeToConvert);

        public override InboxItem Read(
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
                "duplicateKnowledgeBase" =>
                    json.Deserialize<MavenagiApi.InboxItemDuplicateKnowledgeBase>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize MavenagiApi.InboxItemDuplicateKnowledgeBase"
                        ),
                "duplicateDocuments" => json.Deserialize<MavenagiApi.InboxItemDuplicateDocuments>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.InboxItemDuplicateDocuments"
                    ),
                "knowledgeBaseAlert" => json.Deserialize<MavenagiApi.InboxItemKnowledgeBaseAlert>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.InboxItemKnowledgeBaseAlert"
                    ),
                "missingKnowledge" => json.Deserialize<MavenagiApi.InboxItemMissingKnowledge>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.InboxItemMissingKnowledge"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new InboxItem(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InboxItem value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "duplicateKnowledgeBase" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "duplicateDocuments" => JsonSerializer.SerializeToNode(value.Value, options),
                    "knowledgeBaseAlert" => JsonSerializer.SerializeToNode(value.Value, options),
                    "missingKnowledge" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for duplicateKnowledgeBase
    /// </summary>
    [Serializable]
    public struct DuplicateKnowledgeBase
    {
        public DuplicateKnowledgeBase(MavenagiApi.InboxItemDuplicateKnowledgeBase value)
        {
            Value = value;
        }

        internal MavenagiApi.InboxItemDuplicateKnowledgeBase Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DuplicateKnowledgeBase(
            MavenagiApi.InboxItemDuplicateKnowledgeBase value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for duplicateDocuments
    /// </summary>
    [Serializable]
    public struct DuplicateDocuments
    {
        public DuplicateDocuments(MavenagiApi.InboxItemDuplicateDocuments value)
        {
            Value = value;
        }

        internal MavenagiApi.InboxItemDuplicateDocuments Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DuplicateDocuments(
            MavenagiApi.InboxItemDuplicateDocuments value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for knowledgeBaseAlert
    /// </summary>
    [Serializable]
    public struct KnowledgeBaseAlert
    {
        public KnowledgeBaseAlert(MavenagiApi.InboxItemKnowledgeBaseAlert value)
        {
            Value = value;
        }

        internal MavenagiApi.InboxItemKnowledgeBaseAlert Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator KnowledgeBaseAlert(
            MavenagiApi.InboxItemKnowledgeBaseAlert value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for missingKnowledge
    /// </summary>
    [Serializable]
    public struct MissingKnowledge
    {
        public MissingKnowledge(MavenagiApi.InboxItemMissingKnowledge value)
        {
            Value = value;
        }

        internal MavenagiApi.InboxItemMissingKnowledge Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator MissingKnowledge(
            MavenagiApi.InboxItemMissingKnowledge value
        ) => new(value);
    }
}
