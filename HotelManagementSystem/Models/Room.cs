using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string Floor { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomStatusId { get; set; }
        public string Description { get; set; }

        public RoomType RoomType { get; set; }
        public RoomStatus RoomStatus { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public string RoomDetail
        {
            get
            {
                return this.RoomNumber + "(" + this.RoomType.Type + ")";
            }
        }
    }
}
