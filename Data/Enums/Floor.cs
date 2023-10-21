using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Floor
    {
        [EnumMember(Value = "Suterena")]
        Basement = 0,

        [EnumMember(Value = "Parter")]
        GroundFloor = 1,

        [EnumMember(Value = "1")]
        FirstFloor = 2,

        [EnumMember(Value = "2")]
        SecondFloor = 3,

        [EnumMember(Value = "3")]
        ThirdFloor = 4,

        [EnumMember(Value = "4")]
        FourthFloor = 5
    }
}
