using AutoMapper;
using WebApi.DbContexts;

public class UpdateBookCommand
{
    public UpdateBookModel Model { get; set; }
    readonly ILibaryDbContext _dbContext;
    readonly IMapper _mapper;

    public int BookId { get; set; }
    public UpdateBookCommand(ILibaryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

        if (book is null)
            throw new InvalidOperationException("Kitap mevcut değil");

        book = _mapper.Map(Model, book);

        _dbContext.Books.Update(book);
        _dbContext.SaveChanges();
    }
}
public class UpdateBookModel
{
    public string Title { get; set; }
    public int GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
    public int AuthorId { get; set; }
}