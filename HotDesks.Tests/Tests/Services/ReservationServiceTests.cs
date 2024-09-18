using HotDesks.Services;
using HotDesks.Models;
using HotDesks.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HotDesks.Tests.Tests.Services
{
    public class ReservationServiceTests
    {
        [Fact]
        public void AddReservation_ShouldThrowException_IfDeskIsNotAvailable()
        {
            var options = new DbContextOptionsBuilder<HotDeskContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new HotDeskContext(options);

            // Add desk with reservation
            var desk = new Desk
            {
                Id = 1,
                DeskNumber = "A1",
                IsAvailable = true,
                Reservations = new List<Reservation>
                {
                    new Reservation
                    {
                        EmployeeId = 1,
                        DeskId = 1,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(2)
                    }
                }
            };

            context.Desks.Add(desk);
            context.SaveChanges();

            var reservationService = new ReservationService(context);

            //create new reservation to add
            var newReservationDTO = new ReservationDTO
            {
                DeskId = 1,
                EmployeeId = 1,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(3)
            };

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                reservationService.AddReservation(newReservationDTO));

            Assert.Equal("Desk is not available for the selected dates.", exception.Message);
        }
    }
}
