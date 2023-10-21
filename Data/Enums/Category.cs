using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        [EnumMember(Value = "Dom")]
        House = 0,

        [EnumMember(Value = "Mieszkanie")]
        Flat = 1
    }
}
