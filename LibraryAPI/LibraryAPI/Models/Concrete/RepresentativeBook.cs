using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models.Concrete
{
    
    public class RepresentativeBook
	{
        [Key]
        public int Id { get; set; }

        //ISBN in BookLanguage Class

        [Required]
        [StringLength(2000)]
        public string Title { get; set; } = "";

        [Range(1, short.MaxValue)]
        public short PageCount { get; set; }

        [Range(-4000, 2100)]
        public short PublishingYear { get; set; }

        [StringLength(5000)]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int PrintCount { get; set; }

        [Range(0, 32)]
        public float BookThickness { get; set; }

        public bool Banned { get; set; } = false;

        //BookRatingAraTablosu
        [Range(0, 5)]
        public float Rating { get; set; } = 0;

        //BookPublisherAraTablosu
        //public int? PublisherId { get; set; }

        public List<AuthorRepresentativeBook>? AuthorBooks { get; set; }

        //[JsonIgnore]
        //[ForeignKey(nameof(PublisherId))]
        //public Publisher? Publisher { get; set; }

        //BookImage
        [StringLength(260)]//Windows işletim sistemlerinin kullandığı dosya sistemi, dosya adı uzunluklarını (dosya adının yolu dahil) 260 karakterle sınırlıdır.
        [Column(TypeName = "varchar(260)")]
        public string? Image { get; set; } 

        //[ForeignKey(nameof(AuthordIds))]
        [NotMapped]
        public List<long>? AuthorIds { get; set; }


        [JsonIgnore]
        public List<Book>? Book { get; set; }

        public List<RepresentativeBookCategorySubCategory>? RepresentativeBookCategorySubCategories { get; set; }

        public List<BookLanguage>? BookLanguages { get; set; }

        public List<LibraryRepresentativeBookStock>? LibraryRepresentativeBookStocks { get; set; }

        public List<PublisherRepresentativeBook>? PublisherRepresentativeBooks { get; set; }
    }
}

