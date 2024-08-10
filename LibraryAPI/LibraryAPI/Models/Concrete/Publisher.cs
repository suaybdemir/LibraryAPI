using LibraryAPI.Models.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class Publisher
	{
        [Key]
        [Required]
        public int Id { get; set; }
        
        [StringLength(800)]
        public string Name { get; set; } = "";

        [StringLength(800)]
        public string? ContactPerson { get; set; }

        public List<PublisherEMail>? PublisherEMails { get; set; } = new();
        public List<PublisherPhone>? PublisherPhones { get; set; } = new();

        public List<PublisherRepresentativeBook>? PublisherRepresentativeBooks { get; set; } = new();
    }
}

