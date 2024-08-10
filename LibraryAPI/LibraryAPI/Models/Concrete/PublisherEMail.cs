using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Concrete
{
    public class PublisherEMail
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int PublisherId { get; set; } 

        [StringLength(345)]
        [Column(TypeName = "varchar(345)")]
        public string? EMail { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public Publisher? Publisher { get; set; }
    }
}
