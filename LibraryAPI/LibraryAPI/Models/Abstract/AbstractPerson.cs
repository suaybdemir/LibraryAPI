using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models.Abstract
{
    public abstract class AbstractPerson 
    {
        [Key]
        public string Id { get; set; } = "";

        //public List<string>? FavouriteBooks { get; set; }
        [Range(0, 15)]
        public int NumberOfBorrowings { get; set; } = 0;

        public double Fee { get; set; } = 0;
        public List<Book>? LoanedBooks { get; set; }


        [ForeignKey(nameof(Id))]
        public ApplicationUser? ApplicationUser { get; set; }

    }
}

