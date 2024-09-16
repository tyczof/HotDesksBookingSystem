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
                var location1 = new Location { Name = "Main Office" };
                var location2 = new Location { Name = "Branch Office" };

                context.Locations.AddRange(location1, location2);
                context.SaveChanges();
            }

            if (!context.Desks.Any())
            {
                var mainOffice = context.Locations.FirstOrDefault(l => l.Name == "Main Office");
                var branchOffice = context.Locations.FirstOrDefault(l => l.Name == "Branch Office");

                var desk1 = new Desk { DeskNumber = "A1", IsAvailable = true, LocationId = mainOffice.Id };
                var desk2 = new Desk { DeskNumber = "A2", IsAvailable = true, LocationId = mainOffice.Id };
                var desk3 = new Desk { DeskNumber = "B1", IsAvailable = true, LocationId = branchOffice.Id };

                context.Desks.AddRange(desk1, desk2, desk3);
                context.SaveChanges();
            }
        }
    }

}
