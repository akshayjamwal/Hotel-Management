using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
