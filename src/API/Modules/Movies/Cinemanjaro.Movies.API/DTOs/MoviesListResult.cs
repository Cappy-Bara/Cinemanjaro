namespace Cinemanjaro.Movies.API.DTOs;

public class MoviesListResult
{
    public List<MovieShortDataDto> Movies { get; init; }
    public int Amount { get; init; }
}
