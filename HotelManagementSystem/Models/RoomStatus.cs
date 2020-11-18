using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class RoomStatus
    {
        public int RoomStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
