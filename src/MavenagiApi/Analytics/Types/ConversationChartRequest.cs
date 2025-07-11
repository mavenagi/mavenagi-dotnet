// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(ConversationChartRequest.JsonConverter))]
[Serializable]
public record ConversationChartRequest
{
    internal ConversationChartRequest(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConversationChartRequest with <see cref="ConversationChartRequest.PieChart"/>.
    /// </summary>
    public ConversationChartRequest(ConversationChartRequest.PieChart value)
    {
        Type = "pieChart";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationChartRequest with <see cref="ConversationChartRequest.DateHistogram"/>.
    /// </summary>
    public ConversationChartRequest(ConversationChartRequest.DateHistogram value)
    {
        Type = "dateHistogram";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationChartRequest with <see cref="ConversationChartRequest.BarChart"/>.
    /// </summary>
    public ConversationChartRequest(ConversationChartRequest.BarChart value)
    {
        Type = "barChart";
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
    /// Returns true if <see cref="Type"/> is "pieChart"
    /// </summary>
    public bool IsPieChart => Type == "pieChart";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "dateHistogram"
    /// </summary>
    public bool IsDateHistogram => Type == "dateHistogram";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "barChart"
    /// </summary>
    public bool IsBarChart => Type == "barChart";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationPieChartRequest"/> if <see cref="Type"/> is 'pieChart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'pieChart'.</exception>
    public MavenagiApi.ConversationPieChartRequest AsPieChart() =>
        IsPieChart
            ? (MavenagiApi.ConversationPieChartRequest)Value!
            : throw new Exception("ConversationChartRequest.Type is not 'pieChart'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationDateHistogramRequest"/> if <see cref="Type"/> is 'dateHistogram', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'dateHistogram'.</exception>
    public MavenagiApi.ConversationDateHistogramRequest AsDateHistogram() =>
        IsDateHistogram
            ? (MavenagiApi.ConversationDateHistogramRequest)Value!
            : throw new Exception("ConversationChartRequest.Type is not 'dateHistogram'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationBarChartRequest"/> if <see cref="Type"/> is 'barChart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'barChart'.</exception>
    public MavenagiApi.ConversationBarChartRequest AsBarChart() =>
        IsBarChart
            ? (MavenagiApi.ConversationBarChartRequest)Value!
            : throw new Exception("ConversationChartRequest.Type is not 'barChart'");

    public T Match<T>(
        Func<MavenagiApi.ConversationPieChartRequest, T> onPieChart,
        Func<MavenagiApi.ConversationDateHistogramRequest, T> onDateHistogram,
        Func<MavenagiApi.ConversationBarChartRequest, T> onBarChart,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "pieChart" => onPieChart(AsPieChart()),
            "dateHistogram" => onDateHistogram(AsDateHistogram()),
            "barChart" => onBarChart(AsBarChart()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.ConversationPieChartRequest> onPieChart,
        Action<MavenagiApi.ConversationDateHistogramRequest> onDateHistogram,
        Action<MavenagiApi.ConversationBarChartRequest> onBarChart,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "pieChart":
                onPieChart(AsPieChart());
                break;
            case "dateHistogram":
                onDateHistogram(AsDateHistogram());
                break;
            case "barChart":
                onBarChart(AsBarChart());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationPieChartRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsPieChart(out MavenagiApi.ConversationPieChartRequest? value)
    {
        if (Type == "pieChart")
        {
            value = (MavenagiApi.ConversationPieChartRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationDateHistogramRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsDateHistogram(out MavenagiApi.ConversationDateHistogramRequest? value)
    {
        if (Type == "dateHistogram")
        {
            value = (MavenagiApi.ConversationDateHistogramRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationBarChartRequest"/> and returns true if successful.
    /// </summary>
    public bool TryAsBarChart(out MavenagiApi.ConversationBarChartRequest? value)
    {
        if (Type == "barChart")
        {
            value = (MavenagiApi.ConversationBarChartRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationChartRequest(
        ConversationChartRequest.PieChart value
    ) => new(value);

    public static implicit operator ConversationChartRequest(
        ConversationChartRequest.DateHistogram value
    ) => new(value);

    public static implicit operator ConversationChartRequest(
        ConversationChartRequest.BarChart value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ConversationChartRequest>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConversationChartRequest).IsAssignableFrom(typeToConvert);

        public override ConversationChartRequest Read(
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
                "pieChart" => json.Deserialize<MavenagiApi.ConversationPieChartRequest>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationPieChartRequest"
                    ),
                "dateHistogram" => json.Deserialize<MavenagiApi.ConversationDateHistogramRequest>(
                    options
                )
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationDateHistogramRequest"
                    ),
                "barChart" => json.Deserialize<MavenagiApi.ConversationBarChartRequest>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationBarChartRequest"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ConversationChartRequest(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationChartRequest value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "pieChart" => JsonSerializer.SerializeToNode(value.Value, options),
                    "dateHistogram" => JsonSerializer.SerializeToNode(value.Value, options),
                    "barChart" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for pieChart
    /// </summary>
    [Serializable]
    public struct PieChart
    {
        public PieChart(MavenagiApi.ConversationPieChartRequest value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationPieChartRequest Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator PieChart(MavenagiApi.ConversationPieChartRequest value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for dateHistogram
    /// </summary>
    [Serializable]
    public struct DateHistogram
    {
        public DateHistogram(MavenagiApi.ConversationDateHistogramRequest value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationDateHistogramRequest Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DateHistogram(
            MavenagiApi.ConversationDateHistogramRequest value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for barChart
    /// </summary>
    [Serializable]
    public struct BarChart
    {
        public BarChart(MavenagiApi.ConversationBarChartRequest value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationBarChartRequest Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator BarChart(MavenagiApi.ConversationBarChartRequest value) =>
            new(value);
    }
}
