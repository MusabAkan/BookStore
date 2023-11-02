using AutoMapper;
using FluentAssertions;
using UnitTest.TestSetup;
using WebApi.Application.BookOperations.Commands.Create;
using WebApi.DbContexts;
using WebApi.Entities;
using Xunit;

namespace UnitTest.Application.BookOperations.Commands.Create
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly LibaryDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(LibaryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Fact]
        public void WhenAlreadyExistsBookTitleIsGıven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (hazırlık)
            var book = new Book()
            {
                Title = "WhenAlreadyExistsBookTitleIsGıven_InvalidOperationException_ShouldBeReturn", PageCount = 100,
                PublishDate = new DateTime(2002, 01, 01),
                GenreId = 1,
                Id = 1,
                AuthorId = 1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new (_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //act & assert (çalıştırma - doğrulama )

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");


        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            // arrange
            CreateBookCommand command = new(_context, _mapper);
            CreateBookModel model = new ()
            {
                Title = "Hobbit",
                PageCount = 1000,
                PublishDate = DateTime.Now.Date.AddYears(-11),
                GenreId = 1,
                AuthorId =1
            };

            command.Model = model;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert
            var book = _context.Books.SingleOrDefault(b => b.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            //book.Title.Should().Be(model.Title);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);
        }

    }
}
