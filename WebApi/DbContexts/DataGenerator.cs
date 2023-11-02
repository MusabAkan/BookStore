using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbContexts
{
    public class DataGenerator
    {
        //add ile addrange arasındaki fark range olursa birden fazla demek
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibaryDbContext(serviceProvider.GetRequiredService<DbContextOptions<LibaryDbContext>>()))
            {

                #region Author

                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(
                        new Author()
                        {
                            Name = "John",
                            SurName = "Smith",
                            BirthDate = new DateTime(1972,10,1)
                        },
                        new Author()
                        {
                            Name = "Emily",
                            SurName = "Brown",
                            BirthDate = new DateTime(1944, 6, 17)

                        },
                        new Author()
                        {
                            Name = "Daniel",
                            SurName = "Taylor",
                            BirthDate = new DateTime(1986, 1, 6)

                        });
                    context.SaveChanges();
                }

                #endregion

                #region Genre
                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(
                    new Genre()
                    {
                        Name = "Personal Growth",
                        IsActive = true
                    },
                    new Genre()
                    {
                        Name = "Science Fiction",
                        IsActive = true
                    },
                    new Genre()
                    {
                        Name = "Romance",
                        IsActive = true
                    });
                    context.SaveChanges();
                }


                #endregion

                #region Books

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book()
                        {
                            //Id = 1,
                            Title = "Lean Startup",
                            GenreId = 1,
                            PageCount = 200,
                            PublishDate = new DateTime(2001, 06, 12),
                            AuthorId = 1
                        },
                        new Book()
                        {
                            //Id = 2,
                            Title = "Herland",
                            GenreId = 2,
                            PageCount = 250,
                            PublishDate = new DateTime(2010, 05, 23),
                            AuthorId = 2
                        },
                        new Book()
                        {
                            //Id = 3,
                            Title = "Dune",
                            GenreId = 2,
                            PageCount = 540,
                            PublishDate = new DateTime(2001, 12, 21),
                            AuthorId = 3
                        }
                    );
                    context.SaveChanges();
                }

                #endregion
            }
        }
    }
}
