using Cinemanjaro.Shows.Domain.Aggregates;
using Cinemanjaro.Shows.Domain.Entities;
using Cinemanjaro.Shows.Domain.Exceptions;
using Cinemanjaro.Shows.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cinemanjaro.Shows.Domain.Tests.Shows
{
    public class BookSeats
    {
        private Show GetShow(SeatStatus status)
        {
            return new Show()
            {
                Seats = new List<Seat>
                {
                    new Seat(1,1) {Status = status },
                    new Seat(1,2) {Status = status },
                    new Seat(1,3) {Status = status },
                    new Seat(1,4) {Status = status },
                    new Seat(1,5) {Status = status },
                }
            };
        }

        [Fact]
        public void BookSeat_BookOcuppiedSeat_ShouldThrowException()
        {
            var show = GetShow(SeatStatus.Occupied);

            var sut = () => show.BookSeats(new List<SeatPosition> { new SeatPosition(1, 1) });

            sut.Should().Throw<SeatOccupiedException>();
        }

        [Fact]
        public void BookSeat_BookNotExistingSeat_ShouldThrowException()
        {
            var show = GetShow(SeatStatus.Occupied);

            var sut = () => show.BookSeats(new List<SeatPosition> { new SeatPosition(211, 1) });

            sut.Should().Throw<SeatDoesNotExistException>();
        }

        [Fact]
        public void BookSeat_BookFreeSeat_ShouldChangeSeatStatus()
        {
            var show = GetShow(SeatStatus.Free);

            var seatPosition = new SeatPosition(1, 1);

            show.BookSeats(new List<SeatPosition> { seatPosition });

            var seat = show.Seats.FirstOrDefault(x => x.Position == seatPosition);

            seat.Status.Should().Be(SeatStatus.Occupied);
        }

        [Fact]
        public void BookSeat_BookMultipleFreeSeats_ShouldBookAllSeats()
        {
            var show = GetShow(SeatStatus.Free);

            var firstSeatPosition = new SeatPosition(1, 1);
            var secondSeatPosition = new SeatPosition(1, 2);
            var thirdSeatPosition = new SeatPosition(1, 3);

            show.BookSeats(new List<SeatPosition> { firstSeatPosition,secondSeatPosition,thirdSeatPosition });

            var seat = show.Seats.FirstOrDefault(x => x.Position == firstSeatPosition);
            var seat2 = show.Seats.FirstOrDefault(x => x.Position == secondSeatPosition);
            var seat3 = show.Seats.FirstOrDefault(x => x.Position == thirdSeatPosition);

            seat.Status.Should().Be(SeatStatus.Occupied);
            seat2.Status.Should().Be(SeatStatus.Occupied);
            seat3.Status.Should().Be(SeatStatus.Occupied);
        }
    }
}
