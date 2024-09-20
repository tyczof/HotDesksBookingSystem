namespace HotDesks
{
    using HotDesks.DTOs;
    using HotDesks.Models;

    public static class DatabaseSeed
    {
        public static void SeedData(HotDeskContext context)
        {
            if (!context.Locations.Any())
            {
                var location1 = new Location { Name = "Main Office 1st Floor" };
                var location2 = new Location { Name = "Branch Office" };
                var location3 = new Location { Name = "Main Office 2nd Floor" };

                context.Locations.AddRange(location1, location2, location3);
                context.SaveChanges();
            }

            if (!context.Desks.Any())
            {

                var desk1 = new Desk { DeskNumber = "A1", IsAvailable = false, LocationId = 1 };
                var desk2 = new Desk { DeskNumber = "A2", IsAvailable = true, LocationId = 1 };
                var desk3 = new Desk { DeskNumber = "A3", IsAvailable = true, LocationId = 1 };
                var desk4 = new Desk { DeskNumber = "A4", IsAvailable = true, LocationId = 1 };
                var desk5 = new Desk { DeskNumber = "A5", IsAvailable = true, LocationId = 1 };
                var desk6 = new Desk { DeskNumber = "B1", IsAvailable = true, LocationId = 2 };
                var desk7 = new Desk { DeskNumber = "B2", IsAvailable = true, LocationId = 2 };
                var desk8 = new Desk { DeskNumber = "B3", IsAvailable = false, LocationId = 2 };
                var desk9 = new Desk { DeskNumber = "B4", IsAvailable = true, LocationId = 2 };


                context.Desks.AddRange(desk1, desk2, desk3, desk4, desk5, desk6, desk7, desk8, desk9);
                context.SaveChanges();
            }
            if (!context.Employees.Any())
            {

                var employee1 = new Employee { FirstName = "Barbara", LastName = "Kowalska", Email = "b.kowalska@challenge.com", IsAdmin = false };
                var employee2 = new Employee { FirstName = "Andrzej", LastName = "Nowak", Email = "a.nowak@challenge.com", IsAdmin = true };

                context.Employees.AddRange(employee1, employee2);
                context.SaveChanges();
            }
            if (!context.Reservations.Any())
            {

                var reservation1 = new Reservation
                {
                    DeskId = 2,
                    EmployeeId = 2,
                    StartDate = new DateTime(2024, 9, 20, 8, 20, 0),
                    EndDate = new DateTime(2024, 9, 20, 16, 30, 0)
                };

                var reservation2 = new Reservation
                {
                    DeskId = 3,
                    EmployeeId = 1,
                    StartDate = new DateTime(2024, 10, 1, 9, 0, 0),
                    EndDate = new DateTime(2024, 10, 1, 17, 0, 0)
                };

                var reservation3 = new Reservation
                {
                    DeskId = 2,
                    EmployeeId = 1,
                    StartDate = new DateTime(2024, 11, 5, 10, 15, 0),
                    EndDate = new DateTime(2024, 11, 5, 18, 0, 0),
                    IsCancelled = true,
                };

                var reservation4 = new Reservation
                {
                    DeskId = 6,
                    EmployeeId = 2,
                    StartDate = new DateTime(2024, 9, 25, 9, 0, 0),
                    EndDate = new DateTime(2024, 9, 27, 17, 0, 0)
                };

                var reservation5 = new Reservation
                {
                    DeskId = 6,
                    EmployeeId = 2,
                    StartDate = new DateTime(2024, 12, 1, 9, 0, 0),
                    EndDate = new DateTime(2024, 12, 3, 17, 0, 0)
                };

                var reservation6 = new Reservation
                {
                    DeskId = 7,
                    EmployeeId = 1,
                    StartDate = new DateTime(2023, 12, 10, 9, 0, 0),
                    EndDate = new DateTime(2023, 12, 10, 17, 0, 0)
                };

                var reservation7 = new Reservation
                {
                    DeskId = 8,
                    EmployeeId = 1,
                    StartDate = new DateTime(2024, 8, 15, 9, 0, 0),
                    EndDate = new DateTime(2024, 8, 17, 17, 0, 0)
                };

                var reservation8 = new Reservation
                {
                    DeskId = 7,
                    EmployeeId = 2,
                    StartDate = new DateTime(2024, 9, 30, 9, 0, 0),
                    EndDate = new DateTime(2024, 10, 2, 17, 0, 0)
                };

                context.Reservations.AddRange(reservation1, reservation2, reservation3, reservation4, reservation5, reservation6, reservation7, reservation8);

                context.SaveChanges();
            }
        }
    }

}
