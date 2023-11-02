using AutoMapper;
using WebApi.DbContexts;

namespace WebApi.Application.AuthorOperations.Queries
{
    public class GetAuthorQuery
    {
        readonly ILibaryDbContext _dbContext;
        readonly IMapper _mapper;
        public GetAuthorQuery(ILibaryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _dbContext.Authors.OrderBy(x => x.Id).ToList();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authorList);
            return vm;
        }
    }
    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
