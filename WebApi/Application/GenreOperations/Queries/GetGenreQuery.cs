using AutoMapper;
using WebApi.DbContexts;

namespace WebApi.Application.GenreOperations.Queries
{
    public class GetGenreQuery
    {
        readonly ILibaryDbContext _dbContext;
        readonly IMapper _mapper;
        public GetGenreQuery(ILibaryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _dbContext.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> result = _mapper.Map<List<GenresViewModel>>(genres);
            return result;
        }
    }
    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
