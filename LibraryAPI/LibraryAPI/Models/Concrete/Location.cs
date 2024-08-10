using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models
{
    public class Location
    {
        [Key]
        [Required]
        public UInt16 Id { get; set; }
        
        [StringLength(6,MinimumLength = 3)]
        [Column(TypeName = "varchar(6)")]
        public string Shelf { get; set; } = "";
        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}

