using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using LibraryAPI.Models.Abstract;
using LibraryAPI.Models.Concrete;

namespace LibraryAPI.Models
{
	public class Transaction 
	{
        [Key]
        public string Id { get; set; } = "";

        [Required]
        public string UserId { get; set; }

        [Required]
        public int BookId { get; set; }

        public DateTime? BorrowedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        public bool isDelivered { get; set; } = false;
        public bool isDeleted { get; set; } = false;

        [ForeignKey(nameof(UserId))]
        public Member? Member { get; set; }

    }
}

