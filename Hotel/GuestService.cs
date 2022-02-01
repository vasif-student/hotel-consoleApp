using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class GuestService : IService<Guest>
    {
        private List<Guest> Guests = new List<Guest>();

        public Guest Create(Guest model)
        {
            Guests.Add(model);
            return model;
        }

        public bool Delete(int id)
        {
            Guest guest = Guests.Find(g => g.Id == id);
            if (guest == null)
            {
                return false;
            }
            Guests.Remove(guest);
            return true;
        }

        public Guest Get(int id)
        {
            return Guests.Find(g => g.Id == id);
        }

        public List<Guest> GetAll()
        {
            return Guests;
        }

        public Guest Update(int id, Guest model)
        {
            Guest guest = Guests.Find(g => g.Id == id);
            guest = model;
            return model;
        }

        public Guest SearchByIdCardNo(string id_card_no)
        {
            return Guests.Find(g => g.ID_Card_No.ToUpper() == id_card_no.ToUpper());
        }
    }
}
