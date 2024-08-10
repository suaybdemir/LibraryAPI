using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models.Concrete
{
	public class RepresentativeBookCategorySubCategory
	{
		public int RepresentativeBookId { get; set; }

		public short CategoryId { get; set; }

		public short? SubCategoryId { get; set; }

		[ForeignKey(nameof(RepresentativeBookId))]
		public RepresentativeBook? RepresentativeBook { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        [ForeignKey(nameof(SubCategoryId))]
        public virtual SubCategory? SubCategory { get; set; }
	}
}

