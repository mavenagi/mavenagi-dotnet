// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EventResponse.JsonConverter))]
[Serializable]
public record EventResponse
{
    internal EventResponse(string type, object? value)
    {
        EventType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of EventResponse with <see cref="EventResponse.UserEvent"/>.
    /// </summary>
    public EventResponse(EventResponse.UserEvent value)
    {
        EventType = "userEvent";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of EventResponse with <see cref="EventResponse.SystemEvent"/>.
    /// </summary>
    public EventResponse(EventResponse.SystemEvent value)
    {
        EventType = "systemEvent";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("eventType")]
    public string EventType { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="EventType"/> is "userEvent"
    /// </summary>
    public bool IsUserEvent => EventType == "userEvent";

    /// <summary>
    /// Returns true if <see cref="EventType"/> is "systemEvent"
    /// </summary>
    public bool IsSystemEvent => EventType == "systemEvent";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.UserEvent"/> if <see cref="EventType"/> is 'userEvent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="EventType"/> is not 'userEvent'.</exception>
    public MavenagiApi.UserEvent AsUserEvent() =>
        IsUserEvent
            ? (MavenagiApi.UserEvent)Value!
            : throw new Exception("EventResponse.EventType is not 'userEvent'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.SystemEvent"/> if <see cref="EventType"/> is 'systemEvent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="EventType"/> is not 'systemEvent'.</exception>
    public MavenagiApi.SystemEvent AsSystemEvent() =>
        IsSystemEvent
            ? (MavenagiApi.SystemEvent)Value!
            : throw new Exception("EventResponse.EventType is not 'systemEvent'");

    public T Match<T>(
        Func<MavenagiApi.UserEvent, T> onUserEvent,
        Func<MavenagiApi.SystemEvent, T> onSystemEvent,
        Func<string, object?, T> onUnknown_
    )
    {
        return EventType switch
        {
            "userEvent" => onUserEvent(AsUserEvent()),
            "systemEvent" => onSystemEvent(AsSystemEvent()),
            _ => onUnknown_(EventType, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.UserEvent> onUserEvent,
        Action<MavenagiApi.SystemEvent> onSystemEvent,
        Action<string, object?> onUnknown_
    )
    {
        switch (EventType)
        {
            case "userEvent":
                onUserEvent(AsUserEvent());
                break;
            case "systemEvent":
                onSystemEvent(AsSystemEvent());
                break;
            default:
                onUnknown_(EventType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.UserEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsUserEvent(out MavenagiApi.UserEvent? value)
    {
        if (EventType == "userEvent")
        {
            value = (MavenagiApi.UserEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.SystemEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsSystemEvent(out MavenagiApi.SystemEvent? value)
    {
        if (EventType == "systemEvent")
        {
            value = (MavenagiApi.SystemEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator EventResponse(EventResponse.UserEvent value) => new(value);

    public static implicit operator EventResponse(EventResponse.SystemEvent value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventResponse>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(EventResponse).IsAssignableFrom(typeToConvert);

        public override EventResponse Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("eventType", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'eventType'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'eventType' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'eventType' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'eventType' is null");

            var value = discriminator switch
            {
                "userEvent" => json.Deserialize<MavenagiApi.UserEvent>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.UserEvent"),
                "systemEvent" => json.Deserialize<MavenagiApi.SystemEvent>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.SystemEvent"),
                _ => json.Deserialize<object?>(options),
            };
            return new EventResponse(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventResponse value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.EventType switch
                {
                    "userEvent" => JsonSerializer.SerializeToNode(value.Value, options),
                    "systemEvent" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["eventType"] = value.EventType;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for userEvent
    /// </summary>
    [Serializable]
    public struct UserEvent
    {
        public UserEvent(MavenagiApi.UserEvent value)
        {
            Value = value;
        }

        internal MavenagiApi.UserEvent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator UserEvent(MavenagiApi.UserEvent value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for systemEvent
    /// </summary>
    [Serializable]
    public struct SystemEvent
    {
        public SystemEvent(MavenagiApi.SystemEvent value)
        {
            Value = value;
        }

        internal MavenagiApi.SystemEvent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator SystemEvent(MavenagiApi.SystemEvent value) => new(value);
    }
}
