using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LibraryAPI.Models.Concrete;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Range(0,10)]
        public byte? Situation { get; set; }

        public int RepresentativeBookId { get; set; }

        [Range(0,15)]
        public int NumberOfBorrowings { get; set; }

        //[Range(0,10)]
        //public int Situation { get; set; }

        public UInt16? LocationId { get; set; }
        
        //BookLibrary
        public string LibraryName { get; set; } = "";

        [JsonIgnore]
        [ForeignKey(nameof(LocationId))]
        public Location? Location { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(LibraryName))]
        public List<Library>? Libraries { get; set; }

        [ForeignKey(nameof(RepresentativeBookId))]
        public RepresentativeBook? RepresentativeBook { get; set; }

        
    }

}

