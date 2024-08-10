using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
	public class Author
	{
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(800, ErrorMessage = "800 den fazla karakter girilemez.")]
        public string FullName { get; set; } = "";// = default; ...

        public string? Biography { get; set; }
        [Range(-4000, 2100)]
        public short BirthYear { get; set; }
        [Range(-4000, 2100)]
        public short? DeathYear { get; set; }
        public List<AuthorRepresentativeBook>? AuthorBooks { get; set; }
    }
}

