using AutoMapper;
using WebApi.DbContexts;

namespace WebApi.Application.GenreOperations.Queries
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        readonly ILibaryDbContext _dbContext;
        readonly IMapper _mapper;
        public GetGenreDetailQuery(ILibaryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenresDetailsViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null) throw new InvalidOperationException("Kitap Türü bulunamadı");
            GenresDetailsViewModel result = _mapper.Map<GenresDetailsViewModel>(genre);
            return result;
        }
    }
    public class GenresDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
