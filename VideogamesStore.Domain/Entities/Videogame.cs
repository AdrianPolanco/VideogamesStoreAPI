using VideogamesStore.Domain.Abstractions.Primitives;
using VideogamesStore.Domain.Shared.Errors;
using VideogamesStore.Domain.Shared.Utils;
using VideogamesStore.Domain.Value_Objects;

namespace VideogamesStore.Domain.Entities
{
    public class Videogame: AggregateRoot
    {
        public Videogame(Guid Id) : base(Id) { }
        public string Name { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Rating Rating { get; private set; }
        public Guid CompanyId { get; set; }
        private List<Guid> _PlatformsId = new();
        private List<Guid> _GenresId = new();
        public IReadOnlyCollection<Guid> PlatformsId => _PlatformsId;
        public IReadOnlyCollection<Guid> GenresId => _GenresId;

        public Error? SetName(string name)
        {
            Error? error = Check.ValueIsNotEmpty(name, ErrorMessages.EmptyOrNullRequiredValue, nameof(name));
            if (error is null) return error;
            Name = name;
            return null;
        }

        public Error? SeteReleaseDate(DateTime releaseDate) {
            DateTime currentDate = DateTime.Now;
            DateTime fiveYearsAgo = currentDate.AddYears(-5);
            DateTime twoYearsInFuture = currentDate.AddYears(2);

            if(releaseDate < fiveYearsAgo) return new Error(ErrorCause.InvalidPastReleaseDate, ErrorMessages.InvalidPastReleaseDate, nameof(releaseDate));
            if (releaseDate > twoYearsInFuture) return new Error(ErrorCause.InvalidFutureReleaseDate, ErrorMessages.InvalidFutureReleaseDate, nameof(releaseDate));

            ReleaseDate = releaseDate;
            return null;
        }

        public void SetRating(Rating rating)
        {
            Rating = rating;
        }

        public Error? SetCompany(Guid companyId)
        {
            Error? error = Check.GuidIsNotEmpty(companyId, ErrorMessages.GuidIsNull, nameof(companyId));

            if(error is not null) return error;

            CompanyId = companyId;
            return null;
        }

        public Error? AddPlatform(Guid platformId)
        {
            Error? error = Check.GuidIsNotEmpty(platformId, ErrorMessages.GuidIsNull, nameof(platformId));
            if (error is not null) return error;

            _PlatformsId.Add(platformId);
            return null;
        }

        public Error? AddGenre(Guid genreId)
        {
            Error? error = Check.GuidIsNotEmpty(genreId, ErrorMessages.GuidIsNull, nameof(genreId));
            if (error is not null) return error;

            _GenresId.Add(genreId);
            return null;
        }

    }
}
