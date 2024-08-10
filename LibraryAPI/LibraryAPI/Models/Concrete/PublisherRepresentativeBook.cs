using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models.Concrete
{
    public class PublisherRepresentativeBook
    {
        [Key]
        [Required]
        public int Id { get; set; }
        

        public int PublisherId { get; set; } 
        public int RepresentativeBookId { get; set; }

        [ForeignKey(nameof(RepresentativeBookId))]
        public RepresentativeBook? RepresentativeBook { get; set; }
        [ForeignKey(nameof(PublisherId))]
        public Publisher? Publisher { get; set; }
    }
}
