using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Data.Enums;

using Newtonsoft.Json;

namespace Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public Role Role { get; set; } = Role.User;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [JsonIgnore]
        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        [Required]
        public byte[] Salt { get; set; }
    }
}
