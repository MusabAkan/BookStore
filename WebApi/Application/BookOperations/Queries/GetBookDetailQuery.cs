using AutoMapper;
using WebApi.DbContexts;

namespace WebApi.Application.BookOperations.Queries;

public class GetBookDetailQuery
{
    readonly ILibaryDbContext _dbContext;
    readonly IMapper _mapper;
    public int BookId { get; set; }
    public GetBookDetailQuery(ILibaryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BooksDetailViewModel Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

        if (book == null)
            throw new InvalidOperationException("Kitap mevcut değil");
        BooksDetailViewModel vm = _mapper.Map<BooksDetailViewModel>(book);
        return vm;
    }
}
public class BooksDetailViewModel
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }

}