using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class AdminService : IService<Admin>
    {
        private List<Admin> Admins = new List<Admin>();
        public AdminService()
        {
            Admins.Add(new Admin() { Id = 1, Name = "Emin", Surname = "Aliyev", Phone = "+99999", UserName = "emin79", Email = "emin-ali@gmail.com", Password = "333", CreatedDate = DateTime.Now });
            Admins.Add(new Admin() { Id = 2, Name = "Rauf", Surname = "Memmedov", Phone = "+77777", UserName = "raufm", Email = "raufm@gmail.com", Password = "789", CreatedDate = DateTime.Now });
        }
        public Admin Create(Admin model)
        {
            Admins.Add(model);
            return model;
        }

        public bool Delete(int id)
        {
            Admin admin = Admins.Find(a => a.Id == id);
            if (admin == null)
            {
                return false;
            }

            Admins.Remove(admin);
            return true;
        }

        public Admin Get(int id)
        {
            return Admins.Find(a => a.Id == id);
        }

        public List<Admin> GetAll()
        {
            return Admins;
        }

        public Admin Update(int id, Admin model)
        {
            Admin admin = Admins.Find(a => a.Id == id);
            admin = model;
            return model;
        }
    }
}
