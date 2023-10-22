using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Data.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FloorsQuantity
    {
        [EnumMember(Value = "Ground-story")]
        GroundStory = 1,

        [EnumMember(Value = "Ground-story with usable attic")]
        GroundStoryWithUsableAttic = 2,

        [EnumMember(Value = "Single-story")]
        SingleStory = 3,

        [EnumMember(Value = "Two-story and more")]
        TwoStoryAndMore = 4
    }
}
