using WebApi.DbContexts;

namespace WebApi.Application.BookOperations.Commands.Delete
{
    public class DeleteBookCommand
    {
        readonly ILibaryDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(ILibaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Kitap mevcut değil");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}