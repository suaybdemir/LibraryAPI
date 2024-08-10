using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Concrete
{
    public class PublisherPhone
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
      
        public int PublisherId { get; set; } 

        //[Phone]
        //[StringLength(13)]
        //[Range(7,15)]
        //[Column(TypeName = "varchar(13)")]
        //public string? Phone { get; set; }

        [StringLength(13)]
        [Column(TypeName = "varchar(13)")]
        public string? Phone { get; set; }


        [ForeignKey(nameof(PublisherId))]
        public Publisher? Publisher { get; set; }
    }
}
