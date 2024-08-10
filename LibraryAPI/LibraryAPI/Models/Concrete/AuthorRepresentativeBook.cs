using LibraryAPI.Models.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models
{
    public class AuthorRepresentativeBook
    {

        public long AuthorsId { get; set; }

        public int RepresentativeBooksId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(AuthorsId))]
        public Author? Author { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(RepresentativeBooksId))]
        public RepresentativeBook? RepresentativeBook { get; set; }
    }
}

