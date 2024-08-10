using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LibraryAPI.Models.Concrete;

namespace LibraryAPI.Models
{
	public class Language
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(2,MinimumLength =2)]
        [Column(TypeName = "char(2)")]
        public string Code { get; set; } = "";

        [Required]
        [StringLength(100,MinimumLength =3)]
        [Column(TypeName = "char(3)")]
        public string Name { get; set; } = "";


        public List<BookLanguage>? BookLanguages { get; set; }
    }
}

