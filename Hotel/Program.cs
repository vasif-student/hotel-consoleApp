using System;
using System.Threading;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                GuestService guestService = new GuestService();
                RoomService roomService = new RoomService();
                RoomRentService roomRentService = new RoomRentService();
                AdminService adminService = new AdminService();

                byte loginAttempt = 0;
                Admin loggedinAdmin;

                Console.Write(".");
                Thread.Sleep(400);
                Console.Write(".");
                Thread.Sleep(400);
                Console.Write(".");
                Thread.Sleep(400);

                for (int i = 0; i <= 100; i++)
                {
                    Console.Write($"\rProgress: {i}%   ");
                    Thread.Sleep(15);
                }

                Console.Write("\r              ");
                Thread.Sleep(500);

                Console.WriteLine("\n\n\t\t\t\t************ Welcome to Code Hotel ************");


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t```````````````````````````````````````````````");
                Thread.Sleep(1000);
                Console.WriteLine();

                do
                {
                    Console.WriteLine("Enter your username:");
                    string username = Console.ReadLine();

                    while (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                    {
                        Console.WriteLine("You can't skip this field. Please enter your username:");
                        username = Console.ReadLine();
                    }

                    Console.WriteLine("Enter your password:");
                    string password = Console.ReadLine();

                    while (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                    {
                        Console.WriteLine("You can't skip this field. Please enter your password:");
                        password = Console.ReadLine();
                    }

                    Console.WriteLine();

                    loggedinAdmin = adminService.GetAll().Find(a => a.UserName.ToLower() == username.ToLower() && a.Password.ToLower() == password.ToLower());

                    if (loggedinAdmin == null)
                    {
                        loginAttempt++;
                    }
                    else
                    {
                        break;
                    }

                } while (loginAttempt < 3);

                if (loggedinAdmin != null)
                {

                    Console.WriteLine("You have successfully logged in");
                    Console.WriteLine();
                    Console.WriteLine();

                    byte process = 1;

                    do
                    {

                        Console.WriteLine(" -PRESS 1 FOR CHECK-IN");
                        Console.WriteLine(" -PRESS 2 FOR CHECK-OUT");
                        Console.WriteLine(" -PRESS 3 FOR BOOKING REPORT SECTION -> see guests and rooms(available/unavailable)");
                        Console.WriteLine(" -PRESS 4 FOR RESERVATION SECTION -> create/cancel/see all reservations");
                        Console.WriteLine(" -PRESS 5 TO FIND AVAILABLE ROOM BY DATE");
                        Console.WriteLine(" -PRESS 6 FOR ROOM SECTION -> create/update/remove/see a room");
                        Console.WriteLine(" -PRESS 7 FOR ADMIN SECTION -> hire/update/fire(remove)/see an employee(admin)");
                        Console.WriteLine(" -PRESS 0 TO EXIT");
                        Console.WriteLine();
                        Console.WriteLine("********************************************");
                        Console.WriteLine();

                        byte choice;

                        while (!byte.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("Number only!");
                        }

                        switch (choice)
                        {
                            case 1:
                                byte checksection = 1;
                                do
                                {
                                    Console.WriteLine("=> Press 1 if a guest has a reservation already");
                                    Console.WriteLine("=> Press 2 to check a guest in");
                                    Console.WriteLine("=> Press 0 to Exit from section");
                                    byte ch2 = Convert.ToByte(Console.ReadLine());
                                    switch (ch2)
                                    {
                                        case 1:
                                            Console.WriteLine("Enter your reservation ID:");
                                            int resID = Convert.ToInt32(Console.ReadLine());

                                            RoomRent roomRent = roomRentService.GetAll().Find(r => r.Id == resID);

                                            if (roomRent != null)
                                            {
                                                Console.WriteLine("Enter guest name:");
                                                string name1 = Console.ReadLine();

                                                while (string.IsNullOrEmpty(name1) || string.IsNullOrWhiteSpace(name1))
                                                {
                                                    Console.WriteLine("You can't skip this field. Please enter your name:");
                                                    name1 = Console.ReadLine();
                                                }

                                                Console.WriteLine("Enter guest surname:");
                                                string surname1 = Console.ReadLine();

                                                while (string.IsNullOrEmpty(surname1) || string.IsNullOrWhiteSpace(surname1))
                                                {
                                                    Console.WriteLine("You can't skip this field. Please enter your name:");
                                                    surname1 = Console.ReadLine();
                                                }

                                                Console.WriteLine("Enter ID Card No:");
                                                string idCardNo1 = Console.ReadLine();

                                                while (string.IsNullOrEmpty(idCardNo1) || string.IsNullOrWhiteSpace(idCardNo1))
                                                {
                                                    Console.WriteLine("You can't skip this field. Please enter your name:");
                                                    idCardNo1 = Console.ReadLine();
                                                }

                                                Console.WriteLine("Enter guest phone number:");
                                                string phoneNumber1 = Console.ReadLine();

                                                while (string.IsNullOrEmpty(phoneNumber1) || string.IsNullOrWhiteSpace(phoneNumber1))
                                                {
                                                    Console.WriteLine("You can't skip this field. Please enter your name:");
                                                    phoneNumber1 = Console.ReadLine();
                                                }

                                                Console.WriteLine("Enter guest country:");
                                                string country1 = Console.ReadLine();

                                                while (string.IsNullOrEmpty(country1) || string.IsNullOrWhiteSpace(country1))
                                                {
                                                    Console.WriteLine("You can't skip this field. Please enter your name:");
                                                    country1 = Console.ReadLine();
                                                }

                                                Console.WriteLine("Enter guest age:");
                                                byte age1;

                                                while (!byte.TryParse(Console.ReadLine(), out age1))
                                                {
                                                    Console.WriteLine("Number only!");
                                                }

                                                Guest guest1 = new Guest()
                                                {
                                                    Id = guestService.GetAll().Count + 1,
                                                    Name = name1,
                                                    Surname = surname1,
                                                    Age = age1,
                                                    Phone = phoneNumber1,
                                                    Country = country1,
                                                    ID_Card_No = idCardNo1,
                                                };

                                                guestService.Create(guest1);
                                                Console.WriteLine("Guest has checked in");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Not found reservation with such ID");
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("Enter guest name:");
                                            string name = Console.ReadLine();

                                            while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter guest's name:");
                                                name = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter guest surname:");
                                            string surname = Console.ReadLine();

                                            while (string.IsNullOrEmpty(surname) || string.IsNullOrWhiteSpace(surname))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter guest's surname:");
                                                surname = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter ID Card No:");
                                            string idCardNo = Console.ReadLine();

                                            while (string.IsNullOrEmpty(idCardNo) || string.IsNullOrWhiteSpace(idCardNo))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter guest's ID Card No:");
                                                idCardNo = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter guest's phone number:");
                                            string phoneNumber = Console.ReadLine();


                                            while (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter guest's phone number:");
                                                phoneNumber = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter guest's country:");
                                            string country = Console.ReadLine();

                                            while (string.IsNullOrEmpty(country) || string.IsNullOrWhiteSpace(country))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter guest's country:");
                                                country = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter guest's age:");
                                            byte age;

                                            while (!byte.TryParse(Console.ReadLine(), out age))
                                            {
                                                Console.WriteLine("Number only!");
                                            }

                                            Guest guest = new Guest()
                                            {
                                                Id = guestService.GetAll().Count + 1,
                                                Name = name,
                                                Surname = surname,
                                                Age = age,
                                                Phone = phoneNumber,
                                                Country = country,
                                                ID_Card_No = idCardNo
                                            };

                                            guestService.Create(guest);

                                            Console.WriteLine("What type of room does guest want (single,double,triple etc.) ?");
                                            string roomtype = Console.ReadLine();
                                            Room room = roomService.GetAll().Find(r => r.RoomType.ToLower() == roomtype.ToLower());


                                            Console.WriteLine("Enter date when he/she is leaving hotel (yyyy,mm,dd)");
                                            DateTime checkout = Convert.ToDateTime(Console.ReadLine());

                                            while (checkout < DateTime.Now)
                                            {
                                                Console.WriteLine("Please enter check-out date in correct format");
                                                checkout = Convert.ToDateTime(Console.ReadLine());
                                            }

                                            Console.WriteLine("Guest has checked in");

                                            roomRentService.CreateCheckIn(room.Number, loggedinAdmin.Id, checkout, idCardNo);
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 0:
                                            checksection = 0;
                                            break;
                                        default:
                                            Console.WriteLine("Enter number within 0-2");
                                            break;
                                    }
                                } while (checksection != 0);
                                Console.WriteLine();
                                Console.WriteLine("********************************************");
                                Console.WriteLine();
                                break;

                            case 2:
                                Console.WriteLine("Please enter guest's ID:");
                                int DId;

                                while (!int.TryParse(Console.ReadLine(), out DId))
                                {
                                    Console.WriteLine("Number only!");
                                }


                                guestService.Delete(DId);

                                roomRentService.CheckOut(DId);
                                Console.WriteLine("Guest has checked out");
                                Console.WriteLine();
                                Console.WriteLine("********************************************");
                                Console.WriteLine();
                                break;
                            case 3:
                                byte bookingprocess = 1;
                                do
                                {
                                    Console.WriteLine("=> Press 1 to see all guests");
                                    Console.WriteLine("=> Press 2 to see rented rooms");
                                    Console.WriteLine("=> Press 3 to see available rooms");
                                    Console.WriteLine("=> Press 0 to Exit from section");

                                    byte ch3 = Convert.ToByte(Console.ReadLine());
                                    switch (ch3)
                                    {
                                        case 1:
                                            if (guestService.GetAll().Count > 0)
                                            {
                                                foreach (var item in guestService.GetAll())
                                                {
                                                    foreach (var item2 in roomRentService.GetAll())
                                                    {
                                                        if (item.ID_Card_No == item2.GuestIDCrdNo)
                                                        {
                                                            Console.WriteLine($"ID: {item.Id},  Name: {item.Name},  Surname: {item.Surname},  Age: {item.Age},  ID Card No: {item.ID_Card_No},  Phone: {item.Phone},  Country: {item.Country},  Room number: {item2.RoomNumber}");
                                                            Console.WriteLine();
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Hotel has no guest");
                                            }

                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 2:
                                            if (roomRentService.GetAll().Count > 0)
                                            {
                                                foreach (var item in roomRentService.GetAll())
                                                {
                                                    Console.WriteLine($"Rental ID: {item.Id},  Room number: {item.RoomNumber},  ID of Admin who got order: {item.AdminId},  Accommodation date: {item.Accommodation.ToString("dd.MM.yyyy")}  Check-out date: {item.CheckOutDate.ToString("dd.MM.yyyy")}");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No rented room");
                                            }

                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 3:
                                            if (roomRentService.GetAll().Count > 0)
                                            {
                                                foreach (var item in roomService.GetAll())
                                                {
                                                    foreach (var item2 in roomRentService.GetAll())
                                                    {
                                                        if (item.Number != item2.RoomNumber)
                                                        {
                                                            Console.WriteLine($"Room Number: {item.Number} Roomtype: {item.RoomType} BedSize: {item.BedSize}");
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                foreach (var item in roomService.GetAll())
                                                {
                                                    Console.WriteLine($"Room Number: {item.Number} Roomtype: {item.RoomType} BedSize: {item.BedSize}");
                                                }
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 0:
                                            bookingprocess = 0;
                                            break;
                                        default:
                                            Console.WriteLine("Enter number within 0-3");
                                            break;
                                    }
                                } while (bookingprocess != 0);
                                Console.WriteLine();
                                Console.WriteLine("********************************************");
                                Console.WriteLine();
                                break;
                            case 4:
                                byte roomSection = 1;
                                do
                                {
                                    Console.WriteLine("=> Press 1 to Make a reservation");
                                    Console.WriteLine("=> Press 2 to Cancel a reservation");
                                    Console.WriteLine("=> Press 3 to See all reservations");
                                    Console.WriteLine("=> Press 0 to Exit from room section");
                                    Console.WriteLine();
                                    byte ch6;

                                    while (!byte.TryParse(Console.ReadLine(), out ch6))
                                    {
                                        Console.WriteLine("Number only!");
                                    }

                                    switch (ch6)
                                    {
                                        case 1:
                                            Console.WriteLine("What type of room do you want (single,double,triple etc.) ?");
                                            string Rroomtype = Console.ReadLine();
                                            Room Rroom = roomService.GetAll().Find(r => r.RoomType.ToLower() == Rroomtype.ToLower());


                                            Console.WriteLine("Enter date when you come (yyyy,mm,dd)");
                                            DateTime Rcheckin = Convert.ToDateTime(Console.ReadLine());

                                            Console.WriteLine("Enter date when you are leaving hotel (yyyy,mm,dd)");
                                            DateTime Rcheckout = Convert.ToDateTime(Console.ReadLine());

                                            Console.WriteLine("Enter your ID Card No: ");
                                            string idcrdno = Console.ReadLine();

                                            roomRentService.createReservation(Rroom.Number, loggedinAdmin.Id, Rcheckin, Rcheckout, idcrdno);
                                            Console.WriteLine("Reservation accepted. This is reservation ID:");

                                            RoomRent bnm = roomRentService.GetAll()[roomRentService.GetAll().Count - 1];
                                            Console.WriteLine(bnm.Id);

                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("In order to cancel reservation,please enter reservation ID:");
                                            int cancID = Convert.ToInt32(Console.ReadLine());
                                            roomRentService.cancelReservation(cancID);
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 3:
                                            if (roomRentService.GetAll().Count > 0)
                                            {
                                                foreach (var item in roomRentService.GetAll())
                                                {
                                                    if (item.Status == "Not in a hotel yet")
                                                    {
                                                        Console.WriteLine($"Rental ID: {item.Id}, Room number: {item.RoomNumber}, ID of admin who registered a reservation {item.AdminId}, \nGuest ID Card No: {item.GuestIDCrdNo}, Date when guest will arrive: {item.Accommodation.ToString("dd.MM.yyyy")}, Check out date {item.CheckOutDate.ToString("dd.MM.yyyy")}");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No reservation");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No reservation");
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 0:
                                            roomSection = 0;
                                            break;
                                        default:
                                            Console.WriteLine("Enter number within 0-3");
                                            break;
                                    }
                                } while (roomSection != 0);
                                Console.WriteLine();
                                Console.WriteLine("********************************************");
                                Console.WriteLine();

                                break;
                            case 5:
                                Console.WriteLine("Please enter start date:");
                                DateTime startdate = Convert.ToDateTime(Console.ReadLine());

                                while (startdate < DateTime.Now)
                                {
                                    Console.WriteLine("Please enter start date in correct format");
                                    startdate = Convert.ToDateTime(Console.ReadLine());
                                }

                                Console.WriteLine("Please enter end date:");
                                DateTime enddate = Convert.ToDateTime(Console.ReadLine());

                                while (enddate < DateTime.Now)
                                {
                                    Console.WriteLine("Please enter end date in correct format");
                                    enddate = Convert.ToDateTime(Console.ReadLine());
                                }

                                while (startdate > enddate)
                                {
                                    Console.WriteLine("Please enter dates in correct format");
                                    Console.WriteLine("Enter start date:");
                                    startdate = Convert.ToDateTime(Console.ReadLine());

                                    Console.WriteLine("Enter end date:");
                                    enddate = Convert.ToDateTime(Console.ReadLine());

                                }

                                if (roomRentService.GetAll().Count > 0)
                                {
                                    foreach (var item in roomService.GetAll())
                                    {
                                        foreach (var item2 in roomRentService.GetAll())
                                        {
                                            if (item.Number == item2.RoomNumber)
                                            {
                                                if ((startdate < item2.Accommodation && enddate < item2.Accommodation) || (startdate > item2.CheckOutDate && enddate > item2.CheckOutDate))
                                                {
                                                    Console.WriteLine("Room number: " + item.Number + ", Room type: " + item.RoomType + ", Bed size: " + item.BedSize);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Room number: " + item.Number + ", Room type: " + item.RoomType + ", Bed size: " + item.BedSize);
                                            }
                                        }
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("********************************************");
                                    Console.WriteLine();
                                    break;
                                }
                                else
                                {
                                    foreach (var item in roomService.GetAll())
                                    {
                                        Console.WriteLine("Room number: " + item.Number + ", Room type: " + item.RoomType + ", Bed size: " + item.BedSize);
                                    }
                                }
                                Console.WriteLine();
                                Console.WriteLine("********************************************");
                                Console.WriteLine();
                                break;
                            case 6:
                                byte ch8 = 1;
                                do
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("=> Press 1 to create a room");
                                    Console.WriteLine("=> Press 2 to remove a room");
                                    Console.WriteLine("=> Press 3 to update a room");
                                    Console.WriteLine("=> Press 4 to see a room");
                                    Console.WriteLine("=> Press 5 to see all room");
                                    Console.WriteLine("=> Press 0 to Exit from section");
                                    Console.WriteLine();
                                    byte roomswitch;

                                    while (!byte.TryParse(Console.ReadLine(), out roomswitch))
                                    {
                                        Console.WriteLine("Number only!");
                                    }


                                    switch (roomswitch)
                                    {
                                        case 1:
                                            Room newroom = new Room();
                                            Console.WriteLine("Enter room type:");
                                            string newroomtype = Console.ReadLine();

                                            Console.WriteLine("Enter bed size");
                                            string newroombed = Console.ReadLine();

                                            newroom.Number = roomService.GetAll().Count + 1;
                                            newroom.RoomType = newroomtype;
                                            newroom.BedSize = newroombed;

                                            roomService.Create(newroom);
                                            Console.WriteLine("New room created.");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("Enter id of room you want to delete:");
                                            int delrid = Convert.ToInt32(Console.ReadLine());

                                            roomService.Delete(delrid);
                                            Console.WriteLine("Room deleted.");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 3:
                                            Console.WriteLine("Enter id of room you want to update");
                                            int updateId = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Enter room type:");
                                            string updateRoomType = Console.ReadLine();

                                            Console.WriteLine("Enter bed size:");
                                            string updateBedSize = Console.ReadLine();

                                            Room updatedRoom = new Room()
                                            {
                                                RoomType = updateRoomType,
                                                BedSize = updateBedSize
                                            };

                                            roomService.Update(updateId, updatedRoom);
                                            Console.WriteLine("Data is updated");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 4:
                                            Console.WriteLine("Enter id of room you want to see:");
                                            int idOfRoom = Convert.ToInt32(Console.ReadLine());

                                            Room room4 = roomService.Get(idOfRoom);
                                            Console.WriteLine($"Room number {room4.Number}, Room type: {room4.RoomType}, Bed size: {room4.BedSize}");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 5:
                                            foreach (var item in roomService.GetAll())
                                            {
                                                Console.WriteLine($"Room number: {item.Number}, Room type: {item.RoomType}, Bed Size: {item.BedSize}");
                                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 0:
                                            ch8 = 0;
                                            break;
                                        default:
                                            Console.WriteLine("Enter number within 0-5");
                                            break;
                                    }
                                } while (ch8 != 0);
                                Console.WriteLine();
                                Console.WriteLine("********************************************");
                                Console.WriteLine();
                                break;
                            case 7:
                                byte eprocess = 1;

                                do
                                {
                                    Console.WriteLine("=> Press 1 to hire an Employee(admin)");
                                    Console.WriteLine("=> Press 2 to fire(remove) an Employee(admin)");
                                    Console.WriteLine("=> Press 3 to update Employee's(admin) information");
                                    Console.WriteLine("=> Press 4 to see an employee(admin)");
                                    Console.WriteLine("=> Press 5 to see all employees(admin)");
                                    Console.WriteLine("=> Press 0 to Exit from section");
                                    Console.WriteLine();
                                    Console.WriteLine("********************************************");
                                    Console.WriteLine();

                                    byte ch7;

                                    while (!byte.TryParse(Console.ReadLine(), out ch7))
                                    {
                                        Console.WriteLine("Number only!");
                                    }
                                    switch (ch7)
                                    {
                                        case 1:
                                            Console.WriteLine("Enter name:");
                                            string Ename = Console.ReadLine();

                                            while (string.IsNullOrEmpty(Ename) || string.IsNullOrWhiteSpace(Ename))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter name:");
                                                Ename = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter surname:");
                                            string Esurname = Console.ReadLine();

                                            while (string.IsNullOrEmpty(Esurname) || string.IsNullOrWhiteSpace(Esurname))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter surname:");
                                                Esurname = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter phone number");
                                            string Ephone = Console.ReadLine();

                                            while (string.IsNullOrEmpty(Ephone) || string.IsNullOrWhiteSpace(Ephone))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter phone number:");
                                                Ephone = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter email address:");
                                            string Eemail = Console.ReadLine();

                                            while (string.IsNullOrEmpty(Eemail) || string.IsNullOrWhiteSpace(Eemail))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter email address:");
                                                Eemail = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter username:");
                                            string Eusername = Console.ReadLine();

                                            while (string.IsNullOrEmpty(Eusername) || string.IsNullOrWhiteSpace(Eusername))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter username:");
                                                Eusername = Console.ReadLine();
                                            }

                                            Console.WriteLine("Enter password");
                                            string Epassword = Console.ReadLine();

                                            while (string.IsNullOrEmpty(Epassword) || string.IsNullOrWhiteSpace(Epassword))
                                            {
                                                Console.WriteLine("You can't skip this field. Please enter password:");
                                                Epassword = Console.ReadLine();
                                            }

                                            Admin newadmin = new Admin()
                                            {
                                                Name = Ename,
                                                Surname = Esurname,
                                                Phone = Ephone,
                                                Email = Eemail,
                                                UserName = Eusername,
                                                Password = Epassword,
                                                CreatedDate = DateTime.Now,
                                                Id = adminService.GetAll().Count + 1
                                            };

                                            adminService.Create(newadmin);
                                            Console.WriteLine("The new employee is hired");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("Enter Employee's ID:");
                                            int eId;
                                            while (!int.TryParse(Console.ReadLine(), out eId))
                                            {
                                                Console.WriteLine("Number only!");
                                            }

                                            adminService.Delete(eId);

                                            Console.WriteLine("The employee is fired");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 3:
                                            Console.WriteLine("Enter admin ID:");
                                            int emId = Convert.ToInt32(Console.ReadLine());


                                            Console.WriteLine("Enter updated email address:");
                                            string emailem = Console.ReadLine();

                                            Console.WriteLine("Enter updated phone number:");
                                            string emphone = Console.ReadLine();

                                            Console.WriteLine("Enter updated username:");
                                            string emusername = Console.ReadLine();

                                            Console.WriteLine("Enter updated password:");
                                            string empassword = Console.ReadLine();

                                            Admin updateadmin = new Admin()
                                            {
                                                Email = emailem,
                                                Phone = emphone,
                                                UserName = emusername,
                                                Password = empassword
                                            };

                                            adminService.Update(emId, updateadmin);

                                            Console.WriteLine("Data is updated");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 4:
                                            Console.WriteLine("Enter ID of employee you want to see:");
                                            int id4 = Convert.ToInt32(Console.ReadLine());

                                            Admin admin4 = adminService.Get(id4);
                                            Console.WriteLine($"Admin ID: {admin4.Id}, Admin name: {admin4.Name}, Admin surname: {admin4.Surname}, \nAdmin phone: {admin4.Phone}, Admin email:{admin4.Email}, Admin username: {admin4.UserName}, Admin password: {admin4.Password}, Hire date: {admin4.CreatedDate.ToString("dd.MM.yyyy")}");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 5:
                                            foreach (var item in adminService.GetAll())
                                            {
                                                Console.WriteLine($"Admin ID: {item.Id}, Admin name: {item.Name}, Admin surname: {item.Surname}, \nAdmin phone: {item.Phone}, Admin email:{item.Email}, Admin username: {item.UserName}, Admin password: {item.Password}, Hire date: {item.CreatedDate.ToString("dd.MM.yyyy")}");
                                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                        case 0:
                                            eprocess = 0;
                                            break;
                                        default:
                                            Console.WriteLine("Enter number within 0-5");
                                            Console.WriteLine();
                                            Console.WriteLine("********************************************");
                                            Console.WriteLine();
                                            break;
                                    }
                                } while (eprocess != 0);
                                Console.WriteLine();
                                Console.WriteLine("********************************************");
                                Console.WriteLine();
                                break;
                            case 0:
                                Console.WriteLine("The program has been completed");
                                process = 0;
                                Console.WriteLine();
                                Console.WriteLine("********************************************");
                                Console.WriteLine();
                                break;
                            default:
                                Console.WriteLine("Please enter number within 0 - 7");
                                break;
                        }

                    } while (process != 0);
                }
                else
                {
                    Console.WriteLine("Wrong username or password!");
                }
            }
            catch
            {
                Console.WriteLine("Something gone wrong. Please try again!");
            }

        }
    }
}
