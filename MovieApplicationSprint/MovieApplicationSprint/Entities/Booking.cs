using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApplicationSprint.Entities
{
    public class Booking
    {
        [Key]
        public string BookingId { get; set; }

        [ForeignKey("UserNavigation")]
        public string UserId { get; set; }// Foreign Key to User table
        [ForeignKey("MovieNavigation")]
        public string MovieId { get; set; }

        [ForeignKey("TheaterNavigation")]

        public string TheaterId { get; set; }
        [ForeignKey("ShowTimeNavigation")]
        public string ShowTimeId { get; set; } 

        public DateTime BookingDate { get; set; } 
        public int NumberOfSeats { get; set; } 

        public int TotalPrice { get; set; }

        public string Status { get; set; } // Example: confirmed, canceled, etc.

        // Navigation properties
        public User UserNavigation { get; set; }
        public ShowTime ShowTimeNavigation { get; set; }
        public Movie MovieNavigation { get; set; }

        public Theater TheaterNavigation { get; set; }
    }
}
