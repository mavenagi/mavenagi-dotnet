// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(InboxItemFix.JsonConverter))]
[Serializable]
public record InboxItemFix
{
    internal InboxItemFix(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of InboxItemFix with <see cref="InboxItemFix.AddDocument"/>.
    /// </summary>
    public InboxItemFix(InboxItemFix.AddDocument value)
    {
        Type = "addDocument";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of InboxItemFix with <see cref="InboxItemFix.DeactivateDocument"/>.
    /// </summary>
    public InboxItemFix(InboxItemFix.DeactivateDocument value)
    {
        Type = "deactivateDocument";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of InboxItemFix with <see cref="InboxItemFix.DeactivateKnowledgeBase"/>.
    /// </summary>
    public InboxItemFix(InboxItemFix.DeactivateKnowledgeBase value)
    {
        Type = "deactivateKnowledgeBase";
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
    /// Returns true if <see cref="Type"/> is "addDocument"
    /// </summary>
    public bool IsAddDocument => Type == "addDocument";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "deactivateDocument"
    /// </summary>
    public bool IsDeactivateDocument => Type == "deactivateDocument";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "deactivateKnowledgeBase"
    /// </summary>
    public bool IsDeactivateKnowledgeBase => Type == "deactivateKnowledgeBase";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.InboxItemFixAddDocument"/> if <see cref="Type"/> is 'addDocument', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'addDocument'.</exception>
    public MavenagiApi.InboxItemFixAddDocument AsAddDocument() =>
        IsAddDocument
            ? (MavenagiApi.InboxItemFixAddDocument)Value!
            : throw new Exception("InboxItemFix.Type is not 'addDocument'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.InboxItemFixDeactivateDocument"/> if <see cref="Type"/> is 'deactivateDocument', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'deactivateDocument'.</exception>
    public MavenagiApi.InboxItemFixDeactivateDocument AsDeactivateDocument() =>
        IsDeactivateDocument
            ? (MavenagiApi.InboxItemFixDeactivateDocument)Value!
            : throw new Exception("InboxItemFix.Type is not 'deactivateDocument'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.InboxItemFixDeactivateKnowledgeBase"/> if <see cref="Type"/> is 'deactivateKnowledgeBase', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'deactivateKnowledgeBase'.</exception>
    public MavenagiApi.InboxItemFixDeactivateKnowledgeBase AsDeactivateKnowledgeBase() =>
        IsDeactivateKnowledgeBase
            ? (MavenagiApi.InboxItemFixDeactivateKnowledgeBase)Value!
            : throw new Exception("InboxItemFix.Type is not 'deactivateKnowledgeBase'");

    public T Match<T>(
        Func<MavenagiApi.InboxItemFixAddDocument, T> onAddDocument,
        Func<MavenagiApi.InboxItemFixDeactivateDocument, T> onDeactivateDocument,
        Func<MavenagiApi.InboxItemFixDeactivateKnowledgeBase, T> onDeactivateKnowledgeBase,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "addDocument" => onAddDocument(AsAddDocument()),
            "deactivateDocument" => onDeactivateDocument(AsDeactivateDocument()),
            "deactivateKnowledgeBase" => onDeactivateKnowledgeBase(AsDeactivateKnowledgeBase()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.InboxItemFixAddDocument> onAddDocument,
        Action<MavenagiApi.InboxItemFixDeactivateDocument> onDeactivateDocument,
        Action<MavenagiApi.InboxItemFixDeactivateKnowledgeBase> onDeactivateKnowledgeBase,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "addDocument":
                onAddDocument(AsAddDocument());
                break;
            case "deactivateDocument":
                onDeactivateDocument(AsDeactivateDocument());
                break;
            case "deactivateKnowledgeBase":
                onDeactivateKnowledgeBase(AsDeactivateKnowledgeBase());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.InboxItemFixAddDocument"/> and returns true if successful.
    /// </summary>
    public bool TryAsAddDocument(out MavenagiApi.InboxItemFixAddDocument? value)
    {
        if (Type == "addDocument")
        {
            value = (MavenagiApi.InboxItemFixAddDocument)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.InboxItemFixDeactivateDocument"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeactivateDocument(out MavenagiApi.InboxItemFixDeactivateDocument? value)
    {
        if (Type == "deactivateDocument")
        {
            value = (MavenagiApi.InboxItemFixDeactivateDocument)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.InboxItemFixDeactivateKnowledgeBase"/> and returns true if successful.
    /// </summary>
    public bool TryAsDeactivateKnowledgeBase(
        out MavenagiApi.InboxItemFixDeactivateKnowledgeBase? value
    )
    {
        if (Type == "deactivateKnowledgeBase")
        {
            value = (MavenagiApi.InboxItemFixDeactivateKnowledgeBase)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator InboxItemFix(InboxItemFix.AddDocument value) => new(value);

    public static implicit operator InboxItemFix(InboxItemFix.DeactivateDocument value) =>
        new(value);

    public static implicit operator InboxItemFix(InboxItemFix.DeactivateKnowledgeBase value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<InboxItemFix>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(InboxItemFix).IsAssignableFrom(typeToConvert);

        public override InboxItemFix Read(
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
                "addDocument" => json.Deserialize<MavenagiApi.InboxItemFixAddDocument>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.InboxItemFixAddDocument"
                    ),
                "deactivateDocument" =>
                    json.Deserialize<MavenagiApi.InboxItemFixDeactivateDocument>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize MavenagiApi.InboxItemFixDeactivateDocument"
                        ),
                "deactivateKnowledgeBase" =>
                    json.Deserialize<MavenagiApi.InboxItemFixDeactivateKnowledgeBase>(options)
                        ?? throw new JsonException(
                            "Failed to deserialize MavenagiApi.InboxItemFixDeactivateKnowledgeBase"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new InboxItemFix(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            InboxItemFix value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "addDocument" => JsonSerializer.SerializeToNode(value.Value, options),
                    "deactivateDocument" => JsonSerializer.SerializeToNode(value.Value, options),
                    "deactivateKnowledgeBase" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for addDocument
    /// </summary>
    [Serializable]
    public struct AddDocument
    {
        public AddDocument(MavenagiApi.InboxItemFixAddDocument value)
        {
            Value = value;
        }

        internal MavenagiApi.InboxItemFixAddDocument Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator AddDocument(MavenagiApi.InboxItemFixAddDocument value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for deactivateDocument
    /// </summary>
    [Serializable]
    public struct DeactivateDocument
    {
        public DeactivateDocument(MavenagiApi.InboxItemFixDeactivateDocument value)
        {
            Value = value;
        }

        internal MavenagiApi.InboxItemFixDeactivateDocument Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DeactivateDocument(
            MavenagiApi.InboxItemFixDeactivateDocument value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for deactivateKnowledgeBase
    /// </summary>
    [Serializable]
    public struct DeactivateKnowledgeBase
    {
        public DeactivateKnowledgeBase(MavenagiApi.InboxItemFixDeactivateKnowledgeBase value)
        {
            Value = value;
        }

        internal MavenagiApi.InboxItemFixDeactivateKnowledgeBase Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DeactivateKnowledgeBase(
            MavenagiApi.InboxItemFixDeactivateKnowledgeBase value
        ) => new(value);
    }
}
