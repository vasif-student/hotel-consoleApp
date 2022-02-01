using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class RoomRentService
    {
        private List<RoomRent> RoomRents = new List<RoomRent>();


        public bool CreateCheckIn(int RNum, int AId, DateTime ChOutDate, string guestIDCardNo)
        {
            RoomRent roomrent = new RoomRent()
            {
                Id = RoomRents.Count + 1,
                RoomNumber = RNum,
                AdminId = AId,
                GuestIDCrdNo = guestIDCardNo,
                Accommodation = DateTime.Now,
                CheckOutDate = ChOutDate,
            };

            RoomRents.Add(roomrent);

            return true;
        }

        public bool createReservation(int RRNum, int AId, DateTime ChInDate, DateTime ChOutDate, string guestcrdidno)
        {
            RoomRent roomrent2 = new RoomRent()
            {
                Id = RoomRents.Count + 1,
                RoomNumber = RRNum,
                AdminId = AId,
                GuestIDCrdNo = guestcrdidno,
                Accommodation = ChInDate,
                CheckOutDate = ChOutDate
            };

            RoomRents.Add(roomrent2);

            return true;
        }

        public bool cancelReservation(int id)
        {
            RoomRent cancelID = RoomRents.Find(r => r.Id == id);
            RoomRents.Remove(cancelID);
            return true;
        }


        public bool CheckOut(int checkinId)
        {
            RoomRent checkIn = RoomRents.Find(c => c.Id == checkinId);
            checkIn.CheckOutDate = DateTime.Now;
            return true;
        }
        public List<RoomRent> GetAll()
        {
            foreach (var item in RoomRents)
            {
                if (item.Accommodation > DateTime.Now)
                {
                    item.Status = "Not in a hotel yet";
                }
                else if (item.Accommodation == DateTime.Now)
                {
                    item.Status = "currently in hotel";
                }
            }
            return RoomRents;
        }
    }
}
