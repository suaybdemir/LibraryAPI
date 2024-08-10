using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryAPI.Models.Concrete;

namespace LibraryAPI.Models.Abstract
{
	public class AbstractCategory
	{
        [Key]
        public short Id { get; set; }

        [Required]
        [StringLength(800)]
        [Column(TypeName = "varchar(800)")]
        public string Name { get; set; } = "";

        [StringLength(1500)]
        [Column(TypeName = "varchar(1500)")]
        public string? Description { get; set; }

        public List<RepresentativeBookCategorySubCategory>? RepresentativeBookCategorySubCategories { get; set; }
    }
}

