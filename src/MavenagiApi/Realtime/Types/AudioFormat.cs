using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<AudioFormat>))]
public enum AudioFormat
{
    [EnumMember(Value = "PCM16")]
    Pcm16,

    [EnumMember(Value = "G711_ULAW")]
    G711Ulaw,
}
