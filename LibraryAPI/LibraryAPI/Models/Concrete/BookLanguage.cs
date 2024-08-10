using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace LibraryAPI.Models.Concrete
{
	public class BookLanguage
	{
        [StringLength(2, MinimumLength = 2)]
        public string LanguageCode { get; set; } = "";
		public int RepresentativeBookId { get; set; }

        [StringLength(13, MinimumLength = 10)]
        [Column(TypeName = "varchar(13)")]
        public string? ISBN { get; set; }

        public Language? Language { get; set; }
		public RepresentativeBook? RepresentativeBook { get; set; }
	}
}

