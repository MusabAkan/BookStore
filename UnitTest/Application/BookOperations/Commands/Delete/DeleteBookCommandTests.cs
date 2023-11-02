using FluentAssertions;
using UnitTest.TestSetup;
using WebApi.Application.BookOperations.Commands.Delete;
using WebApi.DbContexts;
using Xunit;

namespace UnitTest.Application.BookOperations.Commands.Delete
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly LibaryDbContext context;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenBookIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            // arrange (Hazırlık)

            DeleteBookCommand command = new(context);
            command.BookId = 12;

            // act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("The book to be deleted was not found");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeDeleted()
        {
            // arrange
            DeleteBookCommand command = new(context);
            command.BookId = 1;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert
            var book = context.Books.SingleOrDefault(b => b.Id == command.BookId);
            book.Should().BeNull();
        }
    }
}
