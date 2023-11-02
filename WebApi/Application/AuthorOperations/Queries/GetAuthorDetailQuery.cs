using AutoMapper;
using WebApi.DbContexts;

namespace WebApi.Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQuery
    {
        readonly ILibaryDbContext _dbContext;
        readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(ILibaryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorsDetailViewModel Handle()
        {
            var author = _dbContext.Authors.FirstOrDefault(x => x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Yazar mevcut değil");
            AuthorsDetailViewModel vm = _mapper.Map<AuthorsDetailViewModel>(author);
            return vm;
        }
    }

    public class AuthorsDetailViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string BirthDate { get; set; } 
    }
}
