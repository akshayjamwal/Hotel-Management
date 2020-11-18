using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class BookingStatus
    {
        public int BookingStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
