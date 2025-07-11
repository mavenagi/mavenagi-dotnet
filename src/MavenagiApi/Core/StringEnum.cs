using System.Text.Json.Serialization;

namespace MavenagiApi.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
