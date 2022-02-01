using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class RoomService
    {
        private List<Room> Rooms = new List<Room>();
        public RoomService()
        {
            Rooms.Add(new Room() { Number = 1, RoomType = "Single", BedSize = "Queen" });
            Rooms.Add(new Room() { Number = 2, RoomType = "Single", BedSize = "Standard" });
            Rooms.Add(new Room() { Number = 3, RoomType = "Single", BedSize = "Standard" });
            Rooms.Add(new Room() { Number = 4, RoomType = "Single", BedSize = "Standard" });
            Rooms.Add(new Room() { Number = 5, RoomType = "Single", BedSize = "King" });
            Rooms.Add(new Room() { Number = 6, RoomType = "Double", BedSize = "Twin" });
            Rooms.Add(new Room() { Number = 7, RoomType = "Double", BedSize = "Standard" });
            Rooms.Add(new Room() { Number = 8, RoomType = "Triple", BedSize = "Standard" });
            Rooms.Add(new Room() { Number = 9, RoomType = "Triple", BedSize = "Rollaway" });
            Rooms.Add(new Room() { Number = 10, RoomType = "Single", BedSize = "Queen" });
        }

        public Room Create(Room model)
        {
            Rooms.Add(model);
            return model;
        }

        public bool Delete(int id)
        {
            Room room = Rooms.Find(b => b.Number == id);
            if (room == null)
            {
                return false;
            }

            Rooms.Remove(room);
            return true;
        }

        public Room Get(int id)
        {
            return Rooms.Find(r => r.Number == id);
        }

        public List<Room> GetAll()
        {
            return Rooms;
        }

        public Room Update(int id, Room model)
        {
            Room room = Rooms.Find(r => r.Number == id);
            room = model;
            return model;
        }
    }
}
