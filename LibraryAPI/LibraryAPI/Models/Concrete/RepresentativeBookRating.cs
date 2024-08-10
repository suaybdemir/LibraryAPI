using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Concrete
{
    public class RepresentativeBookRating
    {
        [Key]
        public int Id { get; set; }//RepresentativeBookId

        [Required]
        public int RepresentativeBookId { get; set; }
        [Required]
        public string UserId { get; set; }

        [Range(0,5)]
        public float Rating { get; set; }


    }
}
