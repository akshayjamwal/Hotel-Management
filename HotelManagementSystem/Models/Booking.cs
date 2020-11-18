using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int BookingStatusId { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? CheckoutTime { get; set; }

        public Room Room { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
