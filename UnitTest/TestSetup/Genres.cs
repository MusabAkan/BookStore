using WebApi.DbContexts;
using WebApi.Entities;

namespace UnitTest.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this LibaryDbContext context)
        {
            context.Genres.AddRange(
                new Genre() { Name = "Personal Growth", IsActive = true },
                new Genre() { Name = "Science Fiction", IsActive = true },
                new Genre() { Name = "Romance", IsActive = true });
        }
    }
}
