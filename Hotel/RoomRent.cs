using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class RoomRent
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int AdminId { get; set; }
        public string GuestIDCrdNo { get; set; }
        public DateTime Accommodation { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
    }
}
