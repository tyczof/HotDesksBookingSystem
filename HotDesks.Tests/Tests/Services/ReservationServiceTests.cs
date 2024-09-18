using Moq;
using Xunit;
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
            // Arrange
            var options = new DbContextOptionsBuilder<HotDeskContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new HotDeskContext(options);

            // Dodaj biurko i istniejącą rezerwację
            var desk = new Desk
            {
                Id = 1,
                IsAvailable = true,
                Reservations = new List<Reservation>
                {
                    new Reservation
                    {
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(2)
                    }
                }
            };

            context.Desks.Add(desk);
            context.SaveChanges();

            // Utwórz serwis
            var deskService = new DeskService(context);
            var reservationService = new ReservationService(context);

            var newReservationDTO = new ReservationDTO
            {
                DeskId = 1,
                EmployeeId = 1,
                StartDate = DateTime.Now.AddDays(1), // Konflikt z istniejącą rezerwacją
                EndDate = DateTime.Now.AddDays(3)
            };

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
                reservationService.AddReservation(newReservationDTO));

            Assert.Equal("Desk is not available in the selected time range.", exception.Message);
        }
    }
}
