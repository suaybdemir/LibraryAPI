using LibraryAPI.Models.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models.Abstract
{
    public abstract class AbstractLike
    {
        [Key]
        public string UserId { get; set; } = "";

        public int RepresentativeBookId { get; set; }

        [ForeignKey(nameof(UserId))]
        public Member? User { get; set; }

        [ForeignKey(nameof(RepresentativeBookId))]
        public RepresentativeBook? RepresentativeBooks { get; set; }
    }
}
