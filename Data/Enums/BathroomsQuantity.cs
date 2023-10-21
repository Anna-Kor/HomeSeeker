using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BathroomsQuantity
    {
        [EnumMember(Value = "1 łazienka")]
        One = 1,

        [EnumMember(Value = "2 łazienki")]
        Two = 2,

        [EnumMember(Value = "3 łazienki")]
        Three = 3,

        [EnumMember(Value = "4 i więcej")]
        FourAndMore = 4
    }
}
