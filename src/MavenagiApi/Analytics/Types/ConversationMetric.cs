// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

/// <summary>
/// Defines the metric to be calculated for a column or chart.
/// Only numeric fields are supported, except for ConversationCount and ConversationDistinctCount, which can be applied to any field.
/// </summary>
[JsonConverter(typeof(ConversationMetric.JsonConverter))]
[Serializable]
public record ConversationMetric
{
    internal ConversationMetric(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of ConversationMetric with <see cref="ConversationMetric.Count"/>.
    /// </summary>
    public ConversationMetric(ConversationMetric.Count value)
    {
        Type = "count";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationMetric with <see cref="ConversationMetric.Sum"/>.
    /// </summary>
    public ConversationMetric(ConversationMetric.Sum value)
    {
        Type = "sum";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationMetric with <see cref="ConversationMetric.Average"/>.
    /// </summary>
    public ConversationMetric(ConversationMetric.Average value)
    {
        Type = "average";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationMetric with <see cref="ConversationMetric.Min"/>.
    /// </summary>
    public ConversationMetric(ConversationMetric.Min value)
    {
        Type = "min";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationMetric with <see cref="ConversationMetric.Max"/>.
    /// </summary>
    public ConversationMetric(ConversationMetric.Max value)
    {
        Type = "max";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationMetric with <see cref="ConversationMetric.Percentile"/>.
    /// </summary>
    public ConversationMetric(ConversationMetric.Percentile value)
    {
        Type = "percentile";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationMetric with <see cref="ConversationMetric.Median"/>.
    /// </summary>
    public ConversationMetric(ConversationMetric.Median value)
    {
        Type = "median";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of ConversationMetric with <see cref="ConversationMetric.DistinctCount"/>.
    /// </summary>
    public ConversationMetric(ConversationMetric.DistinctCount value)
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
    /// Returns true if <see cref="Type"/> is "sum"
    /// </summary>
    public bool IsSum => Type == "sum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "average"
    /// </summary>
    public bool IsAverage => Type == "average";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "min"
    /// </summary>
    public bool IsMin => Type == "min";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "max"
    /// </summary>
    public bool IsMax => Type == "max";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "percentile"
    /// </summary>
    public bool IsPercentile => Type == "percentile";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "median"
    /// </summary>
    public bool IsMedian => Type == "median";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "distinctCount"
    /// </summary>
    public bool IsDistinctCount => Type == "distinctCount";

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationCount"/> if <see cref="Type"/> is 'count', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'count'.</exception>
    public MavenagiApi.ConversationCount AsCount() =>
        IsCount
            ? (MavenagiApi.ConversationCount)Value!
            : throw new Exception("ConversationMetric.Type is not 'count'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationSum"/> if <see cref="Type"/> is 'sum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sum'.</exception>
    public MavenagiApi.ConversationSum AsSum() =>
        IsSum
            ? (MavenagiApi.ConversationSum)Value!
            : throw new Exception("ConversationMetric.Type is not 'sum'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationAverage"/> if <see cref="Type"/> is 'average', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'average'.</exception>
    public MavenagiApi.ConversationAverage AsAverage() =>
        IsAverage
            ? (MavenagiApi.ConversationAverage)Value!
            : throw new Exception("ConversationMetric.Type is not 'average'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationMin"/> if <see cref="Type"/> is 'min', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'min'.</exception>
    public MavenagiApi.ConversationMin AsMin() =>
        IsMin
            ? (MavenagiApi.ConversationMin)Value!
            : throw new Exception("ConversationMetric.Type is not 'min'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationMax"/> if <see cref="Type"/> is 'max', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'max'.</exception>
    public MavenagiApi.ConversationMax AsMax() =>
        IsMax
            ? (MavenagiApi.ConversationMax)Value!
            : throw new Exception("ConversationMetric.Type is not 'max'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationPercentile"/> if <see cref="Type"/> is 'percentile', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'percentile'.</exception>
    public MavenagiApi.ConversationPercentile AsPercentile() =>
        IsPercentile
            ? (MavenagiApi.ConversationPercentile)Value!
            : throw new Exception("ConversationMetric.Type is not 'percentile'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationMedian"/> if <see cref="Type"/> is 'median', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'median'.</exception>
    public MavenagiApi.ConversationMedian AsMedian() =>
        IsMedian
            ? (MavenagiApi.ConversationMedian)Value!
            : throw new Exception("ConversationMetric.Type is not 'median'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.ConversationDistinctCount"/> if <see cref="Type"/> is 'distinctCount', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'distinctCount'.</exception>
    public MavenagiApi.ConversationDistinctCount AsDistinctCount() =>
        IsDistinctCount
            ? (MavenagiApi.ConversationDistinctCount)Value!
            : throw new Exception("ConversationMetric.Type is not 'distinctCount'");

    public T Match<T>(
        Func<MavenagiApi.ConversationCount, T> onCount,
        Func<MavenagiApi.ConversationSum, T> onSum,
        Func<MavenagiApi.ConversationAverage, T> onAverage,
        Func<MavenagiApi.ConversationMin, T> onMin,
        Func<MavenagiApi.ConversationMax, T> onMax,
        Func<MavenagiApi.ConversationPercentile, T> onPercentile,
        Func<MavenagiApi.ConversationMedian, T> onMedian,
        Func<MavenagiApi.ConversationDistinctCount, T> onDistinctCount,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "count" => onCount(AsCount()),
            "sum" => onSum(AsSum()),
            "average" => onAverage(AsAverage()),
            "min" => onMin(AsMin()),
            "max" => onMax(AsMax()),
            "percentile" => onPercentile(AsPercentile()),
            "median" => onMedian(AsMedian()),
            "distinctCount" => onDistinctCount(AsDistinctCount()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<MavenagiApi.ConversationCount> onCount,
        Action<MavenagiApi.ConversationSum> onSum,
        Action<MavenagiApi.ConversationAverage> onAverage,
        Action<MavenagiApi.ConversationMin> onMin,
        Action<MavenagiApi.ConversationMax> onMax,
        Action<MavenagiApi.ConversationPercentile> onPercentile,
        Action<MavenagiApi.ConversationMedian> onMedian,
        Action<MavenagiApi.ConversationDistinctCount> onDistinctCount,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "count":
                onCount(AsCount());
                break;
            case "sum":
                onSum(AsSum());
                break;
            case "average":
                onAverage(AsAverage());
                break;
            case "min":
                onMin(AsMin());
                break;
            case "max":
                onMax(AsMax());
                break;
            case "percentile":
                onPercentile(AsPercentile());
                break;
            case "median":
                onMedian(AsMedian());
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
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationCount"/> and returns true if successful.
    /// </summary>
    public bool TryAsCount(out MavenagiApi.ConversationCount? value)
    {
        if (Type == "count")
        {
            value = (MavenagiApi.ConversationCount)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationSum"/> and returns true if successful.
    /// </summary>
    public bool TryAsSum(out MavenagiApi.ConversationSum? value)
    {
        if (Type == "sum")
        {
            value = (MavenagiApi.ConversationSum)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationAverage"/> and returns true if successful.
    /// </summary>
    public bool TryAsAverage(out MavenagiApi.ConversationAverage? value)
    {
        if (Type == "average")
        {
            value = (MavenagiApi.ConversationAverage)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationMin"/> and returns true if successful.
    /// </summary>
    public bool TryAsMin(out MavenagiApi.ConversationMin? value)
    {
        if (Type == "min")
        {
            value = (MavenagiApi.ConversationMin)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationMax"/> and returns true if successful.
    /// </summary>
    public bool TryAsMax(out MavenagiApi.ConversationMax? value)
    {
        if (Type == "max")
        {
            value = (MavenagiApi.ConversationMax)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationPercentile"/> and returns true if successful.
    /// </summary>
    public bool TryAsPercentile(out MavenagiApi.ConversationPercentile? value)
    {
        if (Type == "percentile")
        {
            value = (MavenagiApi.ConversationPercentile)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationMedian"/> and returns true if successful.
    /// </summary>
    public bool TryAsMedian(out MavenagiApi.ConversationMedian? value)
    {
        if (Type == "median")
        {
            value = (MavenagiApi.ConversationMedian)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.ConversationDistinctCount"/> and returns true if successful.
    /// </summary>
    public bool TryAsDistinctCount(out MavenagiApi.ConversationDistinctCount? value)
    {
        if (Type == "distinctCount")
        {
            value = (MavenagiApi.ConversationDistinctCount)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator ConversationMetric(ConversationMetric.Count value) =>
        new(value);

    public static implicit operator ConversationMetric(ConversationMetric.Sum value) => new(value);

    public static implicit operator ConversationMetric(ConversationMetric.Average value) =>
        new(value);

    public static implicit operator ConversationMetric(ConversationMetric.Min value) => new(value);

    public static implicit operator ConversationMetric(ConversationMetric.Max value) => new(value);

    public static implicit operator ConversationMetric(ConversationMetric.Percentile value) =>
        new(value);

    public static implicit operator ConversationMetric(ConversationMetric.Median value) =>
        new(value);

    public static implicit operator ConversationMetric(ConversationMetric.DistinctCount value) =>
        new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ConversationMetric>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(ConversationMetric).IsAssignableFrom(typeToConvert);

        public override ConversationMetric Read(
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
                "count" => json.Deserialize<MavenagiApi.ConversationCount>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationCount"
                    ),
                "sum" => json.Deserialize<MavenagiApi.ConversationSum>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.ConversationSum"),
                "average" => json.Deserialize<MavenagiApi.ConversationAverage>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationAverage"
                    ),
                "min" => json.Deserialize<MavenagiApi.ConversationMin>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.ConversationMin"),
                "max" => json.Deserialize<MavenagiApi.ConversationMax>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.ConversationMax"),
                "percentile" => json.Deserialize<MavenagiApi.ConversationPercentile>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationPercentile"
                    ),
                "median" => json.Deserialize<MavenagiApi.ConversationMedian>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationMedian"
                    ),
                "distinctCount" => json.Deserialize<MavenagiApi.ConversationDistinctCount>(options)
                    ?? throw new JsonException(
                        "Failed to deserialize MavenagiApi.ConversationDistinctCount"
                    ),
                _ => json.Deserialize<object?>(options),
            };
            return new ConversationMetric(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConversationMetric value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "count" => JsonSerializer.SerializeToNode(value.Value, options),
                    "sum" => JsonSerializer.SerializeToNode(value.Value, options),
                    "average" => JsonSerializer.SerializeToNode(value.Value, options),
                    "min" => JsonSerializer.SerializeToNode(value.Value, options),
                    "max" => JsonSerializer.SerializeToNode(value.Value, options),
                    "percentile" => JsonSerializer.SerializeToNode(value.Value, options),
                    "median" => JsonSerializer.SerializeToNode(value.Value, options),
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
        public Count(MavenagiApi.ConversationCount value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationCount Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Count(MavenagiApi.ConversationCount value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sum
    /// </summary>
    [Serializable]
    public struct Sum
    {
        public Sum(MavenagiApi.ConversationSum value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationSum Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Sum(MavenagiApi.ConversationSum value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for average
    /// </summary>
    [Serializable]
    public struct Average
    {
        public Average(MavenagiApi.ConversationAverage value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationAverage Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Average(MavenagiApi.ConversationAverage value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for min
    /// </summary>
    [Serializable]
    public struct Min
    {
        public Min(MavenagiApi.ConversationMin value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationMin Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Min(MavenagiApi.ConversationMin value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for max
    /// </summary>
    [Serializable]
    public struct Max
    {
        public Max(MavenagiApi.ConversationMax value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationMax Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Max(MavenagiApi.ConversationMax value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for percentile
    /// </summary>
    [Serializable]
    public struct Percentile
    {
        public Percentile(MavenagiApi.ConversationPercentile value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationPercentile Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Percentile(MavenagiApi.ConversationPercentile value) =>
            new(value);
    }

    /// <summary>
    /// Discriminated union type for median
    /// </summary>
    [Serializable]
    public struct Median
    {
        public Median(MavenagiApi.ConversationMedian value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationMedian Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Median(MavenagiApi.ConversationMedian value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for distinctCount
    /// </summary>
    [Serializable]
    public struct DistinctCount
    {
        public DistinctCount(MavenagiApi.ConversationDistinctCount value)
        {
            Value = value;
        }

        internal MavenagiApi.ConversationDistinctCount Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DistinctCount(
            MavenagiApi.ConversationDistinctCount value
        ) => new(value);
    }
}
