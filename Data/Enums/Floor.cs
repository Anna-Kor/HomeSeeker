using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Floor
    {
        [EnumMember(Value = "Basement")]
        Basement = 0,

        [EnumMember(Value = "1")]
        FirstFloor = 1,

        [EnumMember(Value = "2")]
        SecondFloor = 2,

        [EnumMember(Value = "3")]
        ThirdFloor = 3,

        [EnumMember(Value = "4")]
        FourthFloor = 4
    }
}
