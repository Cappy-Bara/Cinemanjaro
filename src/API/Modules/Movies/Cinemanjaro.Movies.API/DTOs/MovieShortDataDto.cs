using Cinemanjaro.Movies.Core.Entities;

namespace Cinemanjaro.Movies.API.DTOs;

public class MovieShortDataDto
{
    public string Id { get; }
    public string Title { get; }
    public string PhotoURL { get; }

    public MovieShortDataDto(MovieShortData shortData)
    {
        Id = shortData.Id;
        Title = shortData.Title;
        PhotoURL = shortData.PhotoURL;
    }
}
