using WebApi.DbContexts;

namespace WebApi.Application.AuthorOperations.Commands.Delete;

public class DeleteAuthorCommand
{
    readonly ILibaryDbContext _dbContext;
    public int AuthorId { get; set; }
    public DeleteAuthorCommand(ILibaryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

        if (author is null)
            throw new InvalidOperationException("Yazar mevcut değil");

        _dbContext.Authors.Remove(author);
        _dbContext.SaveChanges();
    }
}