using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoomsQuantity
    {
        [EnumMember(Value = "1 room")]
        One = 1,

        [EnumMember(Value = "2 rooms")]
        Two = 2,

        [EnumMember(Value = "3 rooms")]
        Three = 3,

        [EnumMember(Value = "4 and more")]
        FourAndMore = 4
    }
}
