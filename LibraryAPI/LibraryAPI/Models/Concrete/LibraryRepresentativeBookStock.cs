using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Concrete
{
    public class LibraryRepresentativeBookStock
    {
        [Required]
        public int RepresentativeBookId { get; set; }

        [Required]
        public string LibraryName { get; set; }

        public int Quantity { get; set; } = 0;

        public RepresentativeBook? RepresentativeBook { get; set; }
        public Library? Library { get; set; }
    }
}
