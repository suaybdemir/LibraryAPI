using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryAPI.Models.Abstract;
using LibraryAPI.Models.Concrete;

namespace LibraryAPI.Models
{
	public class Favourite
	{
		
		public string UserId { get; set; } = "";

		public int RepresentativeBookId { get; set; }

		[ForeignKey(nameof(UserId))]
		public Member? User { get; set; }

		[ForeignKey(nameof(RepresentativeBookId))]
        public RepresentativeBook? RepresentativeBooks { get; set; }

	}
}

