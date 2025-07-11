// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(BotResponse.JsonConverter))]
[Serializable]
public record BotResponse
{
    internal BotResponse(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of BotResponse with <see cref="BotResponse.Text"/>.
    /// </summary>
    public BotResponse(BotResponse.Text value)
    {
        Type = "text";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of BotResponse with <see cref="BotResponse.ActionForm"/>.
    /// </summary>
    public BotResponse(BotResponse.ActionForm value)
    {
        Type = "actionForm";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of BotResponse with <see cref="BotResponse.Chart"/>.
    /// </summary>
    public BotResponse(BotResponse.Chart value)
    {
        Type = "chart";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of BotResponse with <see cref="BotResponse.Object"/>.
    /// </summary>
    public BotResponse(BotResponse.Object value)
    {
        Type = "object";
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
    /// Returns true if <see cref="Type"/> is "text"
    /// </summary>
    public bool IsText => Type == "text";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "actionForm"
    /// </summary>
    public bool IsActionForm => Type == "actionForm";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "chart"
    /// </summary>
    public bool IsChart => Type == "chart";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "object"
    /// </summary>
    public bool IsObject => Type == "object";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.BotTextResponse"/> if <see cref="Type"/> is 'text', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'text'.</exception>
    public MavenagiApi.BotTextResponse AsText() =>
        IsText
            ? (MavenagiApi.BotTextResponse)Value!
            : throw new Exception("BotResponse.Type is not 'text'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.BotActionFormResponse"/> if <see cref="Type"/> is 'actionForm', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'actionForm'.</exception>
    public MavenagiApi.BotActionFormResponse AsActionForm() =>
        IsActionForm
            ? (MavenagiApi.BotActionFormResponse)Value!
            : throw new Exception("BotResponse.Type is not 'actionForm'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.BotChartResponse"/> if <see cref="Type"/> is 'chart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'chart'.</exception>
    public MavenagiApi.BotChartResponse AsChart() =>
        IsChart
            ? (MavenagiApi.BotChartResponse)Value!
            : throw new Exception("BotResponse.Type is not 'chart'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.BotObjectResponse"/> if <see cref="Type"/> is 'object', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'object'.</exception>
    public MavenagiApi.BotObjectResponse AsObject() =>
        IsObject
            ? (MavenagiApi.BotObjectResponse)Value!
            : throw new Exception("BotResponse.Type is not 'object'");

    public T Match<T>(
        Func<MavenagiApi.BotTextResponse, T> onText,
        Func<MavenagiApi.BotActionFormResponse, T> onActionForm,
        Func<MavenagiApi.BotChartResponse, T> onChart,
        Func<MavenagiApi.BotObjectResponse, T> onObject,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "text" => onText(AsText()),
            "actionForm" => onActionForm(AsActionForm()),
            "chart" => onChart(AsChart()),
            "object" => onObject(AsObject()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.BotTextResponse> onText,
        Action<MavenagiApi.BotActionFormResponse> onActionForm,
        Action<MavenagiApi.BotChartResponse> onChart,
        Action<MavenagiApi.BotObjectResponse> onObject,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "text":
                onText(AsText());
                break;
            case "actionForm":
                onActionForm(AsActionForm());
                break;
            case "chart":
                onChart(AsChart());
                break;
            case "object":
                onObject(AsObject());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.BotTextResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsText(out MavenagiApi.BotTextResponse? value)
    {
        if (Type == "text")
        {
            value = (MavenagiApi.BotTextResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.BotActionFormResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsActionForm(out MavenagiApi.BotActionFormResponse? value)
    {
        if (Type == "actionForm")
        {
            value = (MavenagiApi.BotActionFormResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.BotChartResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsChart(out MavenagiApi.BotChartResponse? value)
    {
        if (Type == "chart")
        {
            value = (MavenagiApi.BotChartResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.BotObjectResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsObject(out MavenagiApi.BotObjectResponse? value)
    {
        if (Type == "object")
        {
            value = (MavenagiApi.BotObjectResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator BotResponse(BotResponse.Text value) => new(value);

    public static implicit operator BotResponse(BotResponse.ActionForm value) => new(value);

    public static implicit operator BotResponse(BotResponse.Chart value) => new(value);

    public static implicit operator BotResponse(BotResponse.Object value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<BotResponse>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(BotResponse).IsAssignableFrom(typeToConvert);

        public override BotResponse Read(
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
                "text" => json.Deserialize<MavenagiApi.BotTextResponse>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.BotTextResponse"),
                "actionForm" => json.Deserialize<MavenagiApi.BotActionFormResponse>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.BotActionFormResponse"
                    ),
                "chart" => json.Deserialize<MavenagiApi.BotChartResponse>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.BotChartResponse"
                    ),
                "object" => json.Deserialize<MavenagiApi.BotObjectResponse>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.BotObjectResponse"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new BotResponse(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BotResponse value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "text" => JsonSerializer.SerializeToNode(value.Value, options),
                    "actionForm" => JsonSerializer.SerializeToNode(value.Value, options),
                    "chart" => JsonSerializer.SerializeToNode(value.Value, options),
                    "object" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for text
    /// </summary>
    [Serializable]
    public struct Text
    {
        public Text(MavenagiApi.BotTextResponse value)
        {
            Value = value;
        }

        internal MavenagiApi.BotTextResponse Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Text(MavenagiApi.BotTextResponse value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for actionForm
    /// </summary>
    [Serializable]
    public struct ActionForm
    {
        public ActionForm(MavenagiApi.BotActionFormResponse value)
        {
            Value = value;
        }

        internal MavenagiApi.BotActionFormResponse Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator ActionForm(MavenagiApi.BotActionFormResponse value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for chart
    /// </summary>
    [Serializable]
    public struct Chart
    {
        public Chart(MavenagiApi.BotChartResponse value)
        {
            Value = value;
        }

        internal MavenagiApi.BotChartResponse Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Chart(MavenagiApi.BotChartResponse value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for object
    /// </summary>
    [Serializable]
    public struct Object
    {
        public Object(MavenagiApi.BotObjectResponse value)
        {
            Value = value;
        }

        internal MavenagiApi.BotObjectResponse Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Object(MavenagiApi.BotObjectResponse value) => new(value);
    }
}
