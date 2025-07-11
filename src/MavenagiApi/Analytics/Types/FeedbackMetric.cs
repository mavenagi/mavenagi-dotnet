// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// Defines the metric to be calculated for a column or chart.
/// </summary>
[JsonConverter(typeof(FeedbackMetric.JsonConverter))]
[Serializable]
public record FeedbackMetric
{
    internal FeedbackMetric(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of FeedbackMetric with <see cref="FeedbackMetric.Count"/>.
    /// </summary>
    public FeedbackMetric(FeedbackMetric.Count value)
    {
        Type = "count";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of FeedbackMetric with <see cref="FeedbackMetric.DistinctCount"/>.
    /// </summary>
    public FeedbackMetric(FeedbackMetric.DistinctCount value)
    {
        Type = "distinctCount";
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
    /// Returns true if <see cref="Type"/> is "count"
    /// </summary>
    public bool IsCount => Type == "count";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "distinctCount"
    /// </summary>
    public bool IsDistinctCount => Type == "distinctCount";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.FeedbackCount"/> if <see cref="Type"/> is 'count', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'count'.</exception>
    public MavenagiApi.FeedbackCount AsCount() =>
        IsCount
            ? (MavenagiApi.FeedbackCount)Value!
            : throw new Exception("FeedbackMetric.Type is not 'count'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.FeedbackDistinctCount"/> if <see cref="Type"/> is 'distinctCount', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'distinctCount'.</exception>
    public MavenagiApi.FeedbackDistinctCount AsDistinctCount() =>
        IsDistinctCount
            ? (MavenagiApi.FeedbackDistinctCount)Value!
            : throw new Exception("FeedbackMetric.Type is not 'distinctCount'");

    public T Match<T>(
        Func<MavenagiApi.FeedbackCount, T> onCount,
        Func<MavenagiApi.FeedbackDistinctCount, T> onDistinctCount,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "count" => onCount(AsCount()),
            "distinctCount" => onDistinctCount(AsDistinctCount()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.FeedbackCount> onCount,
        Action<MavenagiApi.FeedbackDistinctCount> onDistinctCount,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "count":
                onCount(AsCount());
                break;
            case "distinctCount":
                onDistinctCount(AsDistinctCount());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.FeedbackCount"/> and returns true if successful.
    /// </summary>
    public bool TryAsCount(out MavenagiApi.FeedbackCount? value)
    {
        if (Type == "count")
        {
            value = (MavenagiApi.FeedbackCount)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.FeedbackDistinctCount"/> and returns true if successful.
    /// </summary>
    public bool TryAsDistinctCount(out MavenagiApi.FeedbackDistinctCount? value)
    {
        if (Type == "distinctCount")
        {
            value = (MavenagiApi.FeedbackDistinctCount)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator FeedbackMetric(FeedbackMetric.Count value) => new(value);

    public static implicit operator FeedbackMetric(FeedbackMetric.DistinctCount value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FeedbackMetric>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(FeedbackMetric).IsAssignableFrom(typeToConvert);

        public override FeedbackMetric Read(
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
                "count" => json.Deserialize<MavenagiApi.FeedbackCount>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.FeedbackCount"),
                "distinctCount" => json.Deserialize<MavenagiApi.FeedbackDistinctCount>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.FeedbackDistinctCount"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new FeedbackMetric(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FeedbackMetric value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "count" => JsonSerializer.SerializeToNode(value.Value, options),
                    "distinctCount" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for count
    /// </summary>
    [Serializable]
    public struct Count
    {
        public Count(MavenagiApi.FeedbackCount value)
        {
            Value = value;
        }

        internal MavenagiApi.FeedbackCount Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Count(MavenagiApi.FeedbackCount value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for distinctCount
    /// </summary>
    [Serializable]
    public struct DistinctCount
    {
        public DistinctCount(MavenagiApi.FeedbackDistinctCount value)
        {
            Value = value;
        }

        internal MavenagiApi.FeedbackDistinctCount Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DistinctCount(MavenagiApi.FeedbackDistinctCount value) =>
            new(value);
    }
}
