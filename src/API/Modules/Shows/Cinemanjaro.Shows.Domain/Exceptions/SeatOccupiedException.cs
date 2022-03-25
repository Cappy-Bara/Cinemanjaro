using Cinemanjaro.Common.Exceptions;
using Cinemanjaro.Shows.Domain.ValueObjects;

namespace Cinemanjaro.Shows.Domain.Exceptions
{
    public class SeatOccupiedException : CinemanjaroException
    {
        public SeatOccupiedException(SeatPosition position) : base($"Seat in row {position.Row} with number {position.Number} is occupied", 400)
        {
        }
    }
}
