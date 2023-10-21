using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FloorsQuantity
    {
        [EnumMember(Value = "Parterowy")]
        GroundStory = 1,

        [EnumMember(Value = "Parterowy z użytkowym poddaszem")]
        GroundStoryOneWithUsableAttic = 2,

        [EnumMember(Value = "Jednopiętrowy")]
        SingleStory = 3,

        [EnumMember(Value = "Dwupiętrowy i więcej")]
        TwoStoryAndMore = 4
    }
}
