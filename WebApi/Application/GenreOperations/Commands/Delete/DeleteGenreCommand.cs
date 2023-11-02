using WebApi.DbContexts;

namespace WebApi.Application.GenreOperations.Commands.Delete
{
    public class DeleteGenreCommand
    {
        public DeleteGenreCommand Model { get; set; }
        readonly ILibaryDbContext _dbContext;

        public int GenreId { get; set; }
        public DeleteGenreCommand(ILibaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("Kitap türü mevcut değil");

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }

}
