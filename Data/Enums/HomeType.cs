using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HomeType
    {
        [EnumMember(Value = "For rent")]
        ForRent = 0,

        [EnumMember(Value = "For sale")]
        ForSale = 1
    }
}
