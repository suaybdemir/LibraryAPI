using LibraryAPI.Models.Abstract;

namespace LibraryAPI.Models
{
    public class Member : AbstractPerson
    {
        public int? TotalFine { get; set; }
        public byte EducationalStatus { get; set; }

    }
}
