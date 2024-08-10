using LibraryAPI.Models.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
	public class Library
	{
		[Key]
		[Required]
		[StringLength(800)]
		public string Name { get; set; } = "";

        public List<Book>? Books { get; set; }

        public List<LibraryRepresentativeBookStock>? LibraryRepresentativeBookStocks { get; set; }
    }
}

