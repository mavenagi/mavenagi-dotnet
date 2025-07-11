// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(FieldValue.JsonConverter))]
[Serializable]
public record FieldValue
{
    internal FieldValue(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of FieldValue with <see cref="FieldValue.DateTime"/>.
    /// </summary>
    public FieldValue(FieldValue.DateTime value)
    {
        Type = "dateTime";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of FieldValue with <see cref="FieldValue.String"/>.
    /// </summary>
    public FieldValue(FieldValue.String value)
    {
        Type = "string";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of FieldValue with <see cref="FieldValue.Double"/>.
    /// </summary>
    public FieldValue(FieldValue.Double value)
    {
        Type = "double";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of FieldValue with <see cref="FieldValue.Long"/>.
    /// </summary>
    public FieldValue(FieldValue.Long value)
    {
        Type = "long";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of FieldValue with <see cref="FieldValue.Range"/>.
    /// </summary>
    public FieldValue(FieldValue.Range value)
    {
        Type = "range";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of FieldValue with <see cref="FieldValue.Boolean"/>.
    /// </summary>
    public FieldValue(FieldValue.Boolean value)
    {
        Type = "boolean";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of FieldValue with <see cref="FieldValue.EntityId"/>.
    /// </summary>
    public FieldValue(FieldValue.EntityId value)
    {
        Type = "entityId";
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
    /// Returns true if <see cref="Type"/> is "dateTime"
    /// </summary>
    public bool IsDateTime => Type == "dateTime";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "double"
    /// </summary>
    public bool IsDouble => Type == "double";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "long"
    /// </summary>
    public bool IsLong => Type == "long";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "range"
    /// </summary>
    public bool IsRange => Type == "range";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "boolean"
    /// </summary>
    public bool IsBoolean => Type == "boolean";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "entityId"
    /// </summary>
    public bool IsEntityId => Type == "entityId";

    /// <summary>
    /// Returns the value as a <see cref="DateTime"/> if <see cref="Type"/> is 'dateTime', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'dateTime'.</exception>
    public DateTime AsDateTime() =>
        IsDateTime ? (DateTime)Value! : throw new Exception("FieldValue.Type is not 'dateTime'");

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString ? (string)Value! : throw new Exception("FieldValue.Type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="double"/> if <see cref="Type"/> is 'double', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'double'.</exception>
    public double AsDouble() =>
        IsDouble ? (double)Value! : throw new Exception("FieldValue.Type is not 'double'");

    /// <summary>
    /// Returns the value as a <see cref="long"/> if <see cref="Type"/> is 'long', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'long'.</exception>
    public long AsLong() =>
        IsLong ? (long)Value! : throw new Exception("FieldValue.Type is not 'long'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.Range"/> if <see cref="Type"/> is 'range', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'range'.</exception>
    public MavenagiApi.Range AsRange() =>
        IsRange ? (MavenagiApi.Range)Value! : throw new Exception("FieldValue.Type is not 'range'");

    /// <summary>
    /// Returns the value as a <see cref="bool"/> if <see cref="Type"/> is 'boolean', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'boolean'.</exception>
    public bool AsBoolean() =>
        IsBoolean ? (bool)Value! : throw new Exception("FieldValue.Type is not 'boolean'");

    /// <summary>
    /// Returns the value as a <see cref="MavenagiApi.EntityIdFilter"/> if <see cref="Type"/> is 'entityId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'entityId'.</exception>
    public MavenagiApi.EntityIdFilter AsEntityId() =>
        IsEntityId
            ? (MavenagiApi.EntityIdFilter)Value!
            : throw new Exception("FieldValue.Type is not 'entityId'");

    public T Match<T>(
        Func<DateTime, T> onDateTime,
        Func<string, T> onString,
        Func<double, T> onDouble,
        Func<long, T> onLong,
        Func<MavenagiApi.Range, T> onRange,
        Func<bool, T> onBoolean,
        Func<MavenagiApi.EntityIdFilter, T> onEntityId,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "dateTime" => onDateTime(AsDateTime()),
            "string" => onString(AsString()),
            "double" => onDouble(AsDouble()),
            "long" => onLong(AsLong()),
            "range" => onRange(AsRange()),
            "boolean" => onBoolean(AsBoolean()),
            "entityId" => onEntityId(AsEntityId()),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        Action<DateTime> onDateTime,
        Action<string> onString,
        Action<double> onDouble,
        Action<long> onLong,
        Action<MavenagiApi.Range> onRange,
        Action<bool> onBoolean,
        Action<MavenagiApi.EntityIdFilter> onEntityId,
        Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "dateTime":
                onDateTime(AsDateTime());
                break;
            case "string":
                onString(AsString());
                break;
            case "double":
                onDouble(AsDouble());
                break;
            case "long":
                onLong(AsLong());
                break;
            case "range":
                onRange(AsRange());
                break;
            case "boolean":
                onBoolean(AsBoolean());
                break;
            case "entityId":
                onEntityId(AsEntityId());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="DateTime"/> and returns true if successful.
    /// </summary>
    public bool TryAsDateTime(out DateTime? value)
    {
        if (Type == "dateTime")
        {
            value = (DateTime)Value!;
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
    /// Attempts to cast the value to a <see cref="MavenagiApi.Range"/> and returns true if successful.
    /// </summary>
    public bool TryAsRange(out MavenagiApi.Range? value)
    {
        if (Type == "range")
        {
            value = (MavenagiApi.Range)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="bool"/> and returns true if successful.
    /// </summary>
    public bool TryAsBoolean(out bool? value)
    {
        if (Type == "boolean")
        {
            value = (bool)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="MavenagiApi.EntityIdFilter"/> and returns true if successful.
    /// </summary>
    public bool TryAsEntityId(out MavenagiApi.EntityIdFilter? value)
    {
        if (Type == "entityId")
        {
            value = (MavenagiApi.EntityIdFilter)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator FieldValue(FieldValue.DateTime value) => new(value);

    public static implicit operator FieldValue(FieldValue.String value) => new(value);

    public static implicit operator FieldValue(FieldValue.Double value) => new(value);

    public static implicit operator FieldValue(FieldValue.Long value) => new(value);

    public static implicit operator FieldValue(FieldValue.Range value) => new(value);

    public static implicit operator FieldValue(FieldValue.Boolean value) => new(value);

    public static implicit operator FieldValue(FieldValue.EntityId value) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FieldValue>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(FieldValue).IsAssignableFrom(typeToConvert);

        public override FieldValue Read(
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
                "dateTime" => json.GetProperty("value").Deserialize<DateTime>(options),
                "string" => json.GetProperty("value").Deserialize<string>(options)
                    ?? throw new JsonException("Failed to deserialize string"),
                "double" => json.GetProperty("value").Deserialize<double>(options),
                "long" => json.GetProperty("value").Deserialize<long>(options),
                "range" => json.Deserialize<MavenagiApi.Range>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.Range"),
                "boolean" => json.GetProperty("value").Deserialize<bool>(options),
                "entityId" => json.Deserialize<MavenagiApi.EntityIdFilter>(options)
                    ?? throw new JsonException("Failed to deserialize MavenagiApi.EntityIdFilter"),
                _ => json.Deserialize<object?>(options),
            };
            return new FieldValue(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldValue value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "dateTime" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "string" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "double" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "long" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "range" => JsonSerializer.SerializeToNode(value.Value, options),
                    "boolean" => new JsonObject
                    {
                        ["value"] = JsonSerializer.SerializeToNode(value.Value, options),
                    },
                    "entityId" => JsonSerializer.SerializeToNode(value.Value, options),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }
    }

    /// <summary>
    /// Discriminated union type for dateTime
    /// </summary>
    [Serializable]
    public struct DateTime
    {
        public DateTime(DateTime value)
        {
            Value = value;
        }

        internal DateTime Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator DateTime(DateTime value) => new(value);
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
    /// Discriminated union type for range
    /// </summary>
    [Serializable]
    public struct Range
    {
        public Range(MavenagiApi.Range value)
        {
            Value = value;
        }

        internal MavenagiApi.Range Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Range(MavenagiApi.Range value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for boolean
    /// </summary>
    [Serializable]
    public struct Boolean
    {
        public Boolean(bool value)
        {
            Value = value;
        }

        internal bool Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator Boolean(bool value) => new(value);
    }

    /// <summary>
    /// Discriminated union type for entityId
    /// </summary>
    [Serializable]
    public struct EntityId
    {
        public EntityId(MavenagiApi.EntityIdFilter value)
        {
            Value = value;
        }

        internal MavenagiApi.EntityIdFilter Value { get; set; }

        public override string ToString() => Value.ToString();

        public static implicit operator EntityId(MavenagiApi.EntityIdFilter value) => new(value);
    }
}
