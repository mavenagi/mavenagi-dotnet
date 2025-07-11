// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(ChartResponse.JsonConverter))]
[Serializable]
public record ChartResponse
{
    internal ChartResponse(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ChartResponse with <see cref="ChartResponse.PieChart"/>.
    /// </summary>
    public ChartResponse(ChartResponse.PieChart value)
    {
        Type = "pieChart";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ChartResponse with <see cref="ChartResponse.DateHistogram"/>.
    /// </summary>
    public ChartResponse(ChartResponse.DateHistogram value)
    {
        Type = "dateHistogram";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ChartResponse with <see cref="ChartResponse.BarChart"/>.
    /// </summary>
    public ChartResponse(ChartResponse.BarChart value)
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
    /// Returns the value as a <see cref="MavenagiApi.PieChartResponse"/> if <see cref="Type"/> is 'pieChart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'pieChart'.</exception>
    public MavenagiApi.PieChartResponse AsPieChart() =>
        IsPieChart
            ? (MavenagiApi.PieChartResponse)Value!
            : throw new Exception("ChartResponse.Type is not 'pieChart'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.DateHistogramResponse"/> if <see cref="Type"/> is 'dateHistogram', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'dateHistogram'.</exception>
    public MavenagiApi.DateHistogramResponse AsDateHistogram() =>
        IsDateHistogram
            ? (MavenagiApi.DateHistogramResponse)Value!
            : throw new Exception("ChartResponse.Type is not 'dateHistogram'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.BarChartResponse"/> if <see cref="Type"/> is 'barChart', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'barChart'.</exception>
    public MavenagiApi.BarChartResponse AsBarChart() =>
        IsBarChart
            ? (MavenagiApi.BarChartResponse)Value!
            : throw new Exception("ChartResponse.Type is not 'barChart'");

    public T Match<T>(
        Func<MavenagiApi.PieChartResponse, T> onPieChart,
        Func<MavenagiApi.DateHistogramResponse, T> onDateHistogram,
        Func<MavenagiApi.BarChartResponse, T> onBarChart,
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
        Action<MavenagiApi.PieChartResponse> onPieChart,
        Action<MavenagiApi.DateHistogramResponse> onDateHistogram,
        Action<MavenagiApi.BarChartResponse> onBarChart,
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
    /// Attempts to cast the value to a <see cref="MavenagiApi.PieChartResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsPieChart(out MavenagiApi.PieChartResponse? value)
    {
        if (Type == "pieChart")
        {
            value = (MavenagiApi.PieChartResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.DateHistogramResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsDateHistogram(out MavenagiApi.DateHistogramResponse? value)
    {
        if (Type == "dateHistogram")
        {
            value = (MavenagiApi.DateHistogramResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.BarChartResponse"/> and returns true if successful.
    /// </summary>
    public bool TryAsBarChart(out MavenagiApi.BarChartResponse? value)
    {
        if (Type == "barChart")
        {
            value = (MavenagiApi.BarChartResponse)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ChartResponse(ChartResponse.PieChart value) => new(value);

    public static implicit operator ChartResponse(ChartResponse.DateHistogram value) => new(value);

    public static implicit operator ChartResponse(ChartResponse.BarChart value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ChartResponse>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ChartResponse).IsAssignableFrom(typeToConvert);

        public override ChartResponse Read(
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
                "pieChart" => json.Deserialize<MavenagiApi.PieChartResponse>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.PieChartResponse"
                    ),
                "dateHistogram" => json.Deserialize<MavenagiApi.DateHistogramResponse>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.DateHistogramResponse"
                    ),
                "barChart" => json.Deserialize<MavenagiApi.BarChartResponse>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.BarChartResponse"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ChartResponse(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ChartResponse value,
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
        public PieChart(MavenagiApi.PieChartResponse value)
        {
            Value = value;
        }

        internal MavenagiApi.PieChartResponse Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator PieChart(MavenagiApi.PieChartResponse value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for dateHistogram
    /// </summary>
    [Serializable]
    public struct DateHistogram
    {
        public DateHistogram(MavenagiApi.DateHistogramResponse value)
        {
            Value = value;
        }

        internal MavenagiApi.DateHistogramResponse Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DateHistogram(MavenagiApi.DateHistogramResponse value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for barChart
    /// </summary>
    [Serializable]
    public struct BarChart
    {
        public BarChart(MavenagiApi.BarChartResponse value)
        {
            Value = value;
        }

        internal MavenagiApi.BarChartResponse Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator BarChart(MavenagiApi.BarChartResponse value) => new(value);
    }
}
