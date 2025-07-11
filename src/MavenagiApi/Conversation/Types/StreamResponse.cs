// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(StreamResponse.JsonConverter))]
[Serializable]
public record StreamResponse
{
    internal StreamResponse(string type, object? value)
    {
        EventType = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of StreamResponse with <see cref="StreamResponse.Text"/>.
    /// </summary>
    public StreamResponse(StreamResponse.Text value)
    {
        EventType = "text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of StreamResponse with <see cref="StreamResponse.Action"/>.
    /// </summary>
    public StreamResponse(StreamResponse.Action value)
    {
        EventType = "action";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of StreamResponse with <see cref="StreamResponse.Chart"/>.
    /// </summary>
    public StreamResponse(StreamResponse.Chart value)
    {
        EventType = "chart";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of StreamResponse with <see cref="StreamResponse.Metadata"/>.
    /// </summary>
    public StreamResponse(StreamResponse.Metadata value)
    {
        EventType = "metadata";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of StreamResponse with <see cref="StreamResponse.Start"/>.
    /// </summary>
    public StreamResponse(StreamResponse.Start value)
    {
        EventType = "start";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of StreamResponse with <see cref="StreamResponse.End"/>.
    /// </summary>
    public StreamResponse(StreamResponse.End value)
    {
        EventType = "end";
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
    /// Returns true if <see cref="EventType"/> is "text"
    /// </summary>
    public bool IsText => EventType == "text";

    /// <summary>
    /// Returns true if <see cref="EventType"/> is "action"
    /// </summary>
    public bool IsAction => EventType == "action";

    /// <summary>
    /// Returns true if <see cref="EventType"/> is "chart"
    /// </summary>
    public bool IsChart => EventType == "chart";

    /// <summary>
    /// Returns true if <see cref="EventType"/> is "metadata"
    /// </summary>
    public bool IsMetadata => EventType == "metadata";

    /// <summary>
    /// Returns true if <see cref="EventType"/> is "start"
    /// </summary>
    public bool IsStart => EventType == "start";

    /// <summary>
    /// Returns true if <see cref="EventType"/> is "end"
    /// </summary>
    public bool IsEnd => EventType == "end";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.AskStreamTextEvent"/> if <see cref="EventType"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="EventType"/> is not 'text'.</exception>
    public MavenagiApi.AskStreamTextEvent AsText() =>
        IsText
            ? (MavenagiApi.AskStreamTextEvent)Value!
            : throw new Exception("StreamResponse.EventType is not 'text'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.AskStreamActionEvent"/> if <see cref="EventType"/> is 'action', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="EventType"/> is not 'action'.</exception>
    public MavenagiApi.AskStreamActionEvent AsAction() =>
        IsAction
            ? (MavenagiApi.AskStreamActionEvent)Value!
            : throw new Exception("StreamResponse.EventType is not 'action'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.AskStreamChartEvent"/> if <see cref="EventType"/> is 'chart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="EventType"/> is not 'chart'.</exception>
    public MavenagiApi.AskStreamChartEvent AsChart() =>
        IsChart
            ? (MavenagiApi.AskStreamChartEvent)Value!
            : throw new Exception("StreamResponse.EventType is not 'chart'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.AskStreamMetadataEvent"/> if <see cref="EventType"/> is 'metadata', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="EventType"/> is not 'metadata'.</exception>
    public MavenagiApi.AskStreamMetadataEvent AsMetadata() =>
        IsMetadata
            ? (MavenagiApi.AskStreamMetadataEvent)Value!
            : throw new Exception("StreamResponse.EventType is not 'metadata'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.AskStreamStartEvent"/> if <see cref="EventType"/> is 'start', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="EventType"/> is not 'start'.</exception>
    public MavenagiApi.AskStreamStartEvent AsStart() =>
        IsStart
            ? (MavenagiApi.AskStreamStartEvent)Value!
            : throw new Exception("StreamResponse.EventType is not 'start'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.AskStreamEndEvent"/> if <see cref="EventType"/> is 'end', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="EventType"/> is not 'end'.</exception>
    public MavenagiApi.AskStreamEndEvent AsEnd() =>
        IsEnd
            ? (MavenagiApi.AskStreamEndEvent)Value!
            : throw new Exception("StreamResponse.EventType is not 'end'");

    public T Match<T>(
        Func<MavenagiApi.AskStreamTextEvent, T> onText,
        Func<MavenagiApi.AskStreamActionEvent, T> onAction,
        Func<MavenagiApi.AskStreamChartEvent, T> onChart,
        Func<MavenagiApi.AskStreamMetadataEvent, T> onMetadata,
        Func<MavenagiApi.AskStreamStartEvent, T> onStart,
        Func<MavenagiApi.AskStreamEndEvent, T> onEnd,
        Func<string, object?, T> onUnknown_
    )
    {
        return EventType switch
        {
            "text" => onText(AsText()),
            "action" => onAction(AsAction()),
            "chart" => onChart(AsChart()),
            "metadata" => onMetadata(AsMetadata()),
            "start" => onStart(AsStart()),
            "end" => onEnd(AsEnd()),
            _ => onUnknown_(EventType, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.AskStreamTextEvent> onText,
        Action<MavenagiApi.AskStreamActionEvent> onAction,
        Action<MavenagiApi.AskStreamChartEvent> onChart,
        Action<MavenagiApi.AskStreamMetadataEvent> onMetadata,
        Action<MavenagiApi.AskStreamStartEvent> onStart,
        Action<MavenagiApi.AskStreamEndEvent> onEnd,
        Action<string, object?> onUnknown_
    )
    {
        switch (EventType)
        {
            case "text":
                onText(AsText());
                break;
            case "action":
                onAction(AsAction());
                break;
            case "chart":
                onChart(AsChart());
                break;
            case "metadata":
                onMetadata(AsMetadata());
                break;
            case "start":
                onStart(AsStart());
                break;
            case "end":
                onEnd(AsEnd());
                break;
            default:
                onUnknown_(EventType, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.AskStreamTextEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out MavenagiApi.AskStreamTextEvent? value)
    {
        if (EventType == "text")
        {
            value = (MavenagiApi.AskStreamTextEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.AskStreamActionEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsAction(out MavenagiApi.AskStreamActionEvent? value)
    {
        if (EventType == "action")
        {
            value = (MavenagiApi.AskStreamActionEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.AskStreamChartEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsChart(out MavenagiApi.AskStreamChartEvent? value)
    {
        if (EventType == "chart")
        {
            value = (MavenagiApi.AskStreamChartEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.AskStreamMetadataEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsMetadata(out MavenagiApi.AskStreamMetadataEvent? value)
    {
        if (EventType == "metadata")
        {
            value = (MavenagiApi.AskStreamMetadataEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.AskStreamStartEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsStart(out MavenagiApi.AskStreamStartEvent? value)
    {
        if (EventType == "start")
        {
            value = (MavenagiApi.AskStreamStartEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.AskStreamEndEvent"/> and returns true if successful.
    /// </summary>
    public bool TryAsEnd(out MavenagiApi.AskStreamEndEvent? value)
    {
        if (EventType == "end")
        {
            value = (MavenagiApi.AskStreamEndEvent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator StreamResponse(StreamResponse.Text value) => new(value);

    public static implicit operator StreamResponse(StreamResponse.Action value) => new(value);

    public static implicit operator StreamResponse(StreamResponse.Chart value) => new(value);

    public static implicit operator StreamResponse(StreamResponse.Metadata value) => new(value);

    public static implicit operator StreamResponse(StreamResponse.Start value) => new(value);

    public static implicit operator StreamResponse(StreamResponse.End value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<StreamResponse>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(StreamResponse).IsAssignableFrom(typeToConvert);

        public override StreamResponse Read(
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
                "text" => json.Deserialize<MavenagiApi.AskStreamTextEvent>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.AskStreamTextEvent"
                    ),
                "action" => json.Deserialize<MavenagiApi.AskStreamActionEvent>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.AskStreamActionEvent"
                    ),
                "chart" => json.Deserialize<MavenagiApi.AskStreamChartEvent>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.AskStreamChartEvent"
                    ),
                "metadata" => json.Deserialize<MavenagiApi.AskStreamMetadataEvent>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.AskStreamMetadataEvent"
                    ),
                "start" => json.Deserialize<MavenagiApi.AskStreamStartEvent>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.AskStreamStartEvent"
                    ),
                "end" => json.Deserialize<MavenagiApi.AskStreamEndEvent>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.AskStreamEndEvent"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new StreamResponse(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StreamResponse value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.EventType switch
                {
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "action" => JsonSerializer.SerializeToNode(value.Value, options),
                    "chart" => JsonSerializer.SerializeToNode(value.Value, options),
                    "metadata" => JsonSerializer.SerializeToNode(value.Value, options),
                    "start" => JsonSerializer.SerializeToNode(value.Value, options),
                    "end" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["eventType"] = value.EventType;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(MavenagiApi.AskStreamTextEvent value)
        {
            Value = value;
        }

        internal MavenagiApi.AskStreamTextEvent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Text(MavenagiApi.AskStreamTextEvent value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for action
    /// </summary>
    [Serializable]
    public struct Action
    {
        public Action(MavenagiApi.AskStreamActionEvent value)
        {
            Value = value;
        }

        internal MavenagiApi.AskStreamActionEvent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Action(MavenagiApi.AskStreamActionEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for chart
    /// </summary>
    [Serializable]
    public struct Chart
    {
        public Chart(MavenagiApi.AskStreamChartEvent value)
        {
            Value = value;
        }

        internal MavenagiApi.AskStreamChartEvent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Chart(MavenagiApi.AskStreamChartEvent value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for metadata
    /// </summary>
    [Serializable]
    public struct Metadata
    {
        public Metadata(MavenagiApi.AskStreamMetadataEvent value)
        {
            Value = value;
        }

        internal MavenagiApi.AskStreamMetadataEvent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Metadata(MavenagiApi.AskStreamMetadataEvent value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for start
    /// </summary>
    [Serializable]
    public struct Start
    {
        public Start(MavenagiApi.AskStreamStartEvent value)
        {
            Value = value;
        }

        internal MavenagiApi.AskStreamStartEvent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Start(MavenagiApi.AskStreamStartEvent value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for end
    /// </summary>
    [Serializable]
    public struct End
    {
        public End(MavenagiApi.AskStreamEndEvent value)
        {
            Value = value;
        }

        internal MavenagiApi.AskStreamEndEvent Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator End(MavenagiApi.AskStreamEndEvent value) => new(value);
    }
}
