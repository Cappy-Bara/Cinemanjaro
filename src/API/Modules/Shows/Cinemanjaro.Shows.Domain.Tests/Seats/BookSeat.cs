using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace Cinemanjaro.Shows.Domain.Tests.Seats
{
    public class BookSeat
    {
        [Fact]
        public void BookSeat_SeatFree_ShouldBookSeat()
        {
            Seat seat = new Seat(0,0) { Status = ValueObjects.SeatStatus.Free};

            seat.BookSeat();

            seat.Status.Should().Be(ValueObjects.SeatStatus.Occupied);
        }
        
        [Fact]
        public void BookSeat_SeatOccupied_ShouldThrowException()
        {
            Seat seat = new Seat(0, 0) { Status = ValueObjects.SeatStatus.Occupied , Position = new ValueObjects.SeatPosition(4,4)};

            var action = () => seat.BookSeat();

            action.Should().Throw<SeatOccupiedException>();
        }
    }
}
