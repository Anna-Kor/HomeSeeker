using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HomeType
    {
        [EnumMember(Value = "Na wynajem")]
        ForRent = 0,

        [EnumMember(Value = "Na sprzedaż")]
        ForSale = 1
    }
}
