// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(CellData.JsonConverter))]
[Serializable]
public record CellData
{
    internal CellData(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of CellData with <see cref="CellData.Double"/>.
    /// </summary>
    public CellData(CellData.Double value)
    {
        Type = "double";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CellData with <see cref="CellData.Long"/>.
    /// </summary>
    public CellData(CellData.Long value)
    {
        Type = "long";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CellData with <see cref="CellData.Millisecond"/>.
    /// </summary>
    public CellData(CellData.Millisecond value)
    {
        Type = "millisecond";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of CellData with <see cref="CellData.String"/>.
    /// </summary>
    public CellData(CellData.String value)
    {
        Type = "string";
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
    /// Returns true if <see cref="Type"/> is "double"
    /// </summary>
    public bool IsDouble => Type == "double";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "long"
    /// </summary>
    public bool IsLong => Type == "long";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "millisecond"
    /// </summary>
    public bool IsMillisecond => Type == "millisecond";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString => Type == "string";

    /// <summary>
    /// Returns the value as a <see cref="double"/> if <see cref="Type"/> is 'double', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'double'.</exception>
    public double AsDouble() =>
        IsDouble ? (double)Value! : throw new Exception("CellData.Type is not 'double'");

    /// <summary>
    /// Returns the value as a <see cref="long"/> if <see cref="Type"/> is 'long', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'long'.</exception>
    public long AsLong() =>
        IsLong ? (long)Value! : throw new Exception("CellData.Type is not 'long'");

    /// <summary>
    /// Returns the value as a <see cref="double"/> if <see cref="Type"/> is 'millisecond', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'millisecond'.</exception>
    public double AsMillisecond() =>
        IsMillisecond ? (double)Value! : throw new Exception("CellData.Type is not 'millisecond'");

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString ? (string)Value! : throw new Exception("CellData.Type is not 'string'");

    public T Match<T>(
        Func<double, T> onDouble,
        Func<long, T> onLong,
        Func<double, T> onMillisecond,
        Func<string, T> onString,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "double" => onDouble(AsDouble()),
            "long" => onLong(AsLong()),
            "millisecond" => onMillisecond(AsMillisecond()),
            "string" => onString(AsString()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<double> onDouble,
        Action<long> onLong,
        Action<double> onMillisecond,
        Action<string> onString,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "double":
                onDouble(AsDouble());
                break;
            case "long":
                onLong(AsLong());
                break;
            case "millisecond":
                onMillisecond(AsMillisecond());
                break;
            case "string":
                onString(AsString());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="double"/> and returns true if successful.
    /// </summary>
    public bool TryAsDouble(out double? value)
    {
        if (Type == "double")
        {
            value = (double)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="long"/> and returns true if successful.
    /// </summary>
    public bool TryAsLong(out long? value)
    {
        if (Type == "long")
        {
            value = (long)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="double"/> and returns true if successful.
    /// </summary>
    public bool TryAsMillisecond(out double? value)
    {
        if (Type == "millisecond")
        {
            value = (double)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="string"/> and returns true if successful.
    /// </summary>
    public bool TryAsString(out string? value)
    {
        if (Type == "string")
        {
            value = (string)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator CellData(CellData.Double value) => new(value);

    public static implicit operator CellData(CellData.Long value) => new(value);

    public static implicit operator CellData(CellData.Millisecond value) => new(value);

    public static implicit operator CellData(CellData.String value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CellData>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(CellData).IsAssignableFrom(typeToConvert);

        public override CellData Read(
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
                "double" => json.GetProperty("value").Deserialize<double>(options),
                "long" => json.GetProperty("value").Deserialize<long>(options),
                "millisecond" => json.GetProperty("value").Deserialize<double>(options),
                "string" => json.GetProperty("value").Deserialize<string>(options)
                    ?? throw new JsonException("Failed to deserialize string"),
                _ => json.Deserialize<object?>(options),
            };
            return new CellData(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CellData value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "double" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "long" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "millisecond" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "string" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for double
    /// </summary>
    [Serializable]
    public struct Double
    {
        public Double(double value)
        {
            Value = value;
        }

        internal double Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Double(double value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for long
    /// </summary>
    [Serializable]
    public struct Long
    {
        public Long(long value)
        {
            Value = value;
        }

        internal long Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Long(long value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for millisecond
    /// </summary>
    [Serializable]
    public struct Millisecond
    {
        public Millisecond(double value)
        {
            Value = value;
        }

        internal double Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Millisecond(double value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for string
    /// </summary>
    [Serializable]
    public record String
    {
        public String(string value)
        {
            Value = value;
        }

        internal string Value { get; set; }

        public override string ToString() => Value;

        public static implicit operator String(string value) => new(value);
    }
}
