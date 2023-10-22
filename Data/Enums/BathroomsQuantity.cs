using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BathroomsQuantity
    {
        [EnumMember(Value = "1 bathroom")]
        One = 1,

        [EnumMember(Value = "2 bathrooms")]
        Two = 2,

        [EnumMember(Value = "3 bathrooms")]
        Three = 3,

        [EnumMember(Value = "4 and more")]
        FourAndMore = 4
    }
}
