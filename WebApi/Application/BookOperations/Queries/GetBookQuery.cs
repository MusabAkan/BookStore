using AutoMapper;
using WebApi.DbContexts;

namespace WebApi.Application.BookOperations.Queries;

public class GetBookQuery
{
    readonly ILibaryDbContext _dbContext;
    readonly IMapper _mapper;
    public GetBookQuery(ILibaryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<BooksViewModel> Handle()
    {
        var booksList = _dbContext.Books.OrderBy(x => x.Id).ToList();
        List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(booksList);
        return vm;
    }
}
public class BooksViewModel
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }

}