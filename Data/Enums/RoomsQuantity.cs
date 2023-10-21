using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoomsQuantity
    {
        [EnumMember(Value = "1 pokój")]
        One = 1,

        [EnumMember(Value = "2 pokoje")]
        Two = 2,

        [EnumMember(Value = "3 pokoje")]
        Three = 3,

        [EnumMember(Value = "4 i więcej")]
        FourAndMore = 4
    }
}
