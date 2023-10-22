using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        [EnumMember(Value = "House")]
        House = 0,

        [EnumMember(Value = "Flat")]
        Flat = 1
    }
}
