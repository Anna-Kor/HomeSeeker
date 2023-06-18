﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSeeker_API.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("rooms_number")]
        public string RoomsNumber { get; set; }
    }
}
