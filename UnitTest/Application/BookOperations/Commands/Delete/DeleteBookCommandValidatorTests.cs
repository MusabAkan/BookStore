using FluentAssertions;
using UnitTest.TestSetup;
using WebApi.Application.BookOperations.Commands.Delete;
using WebApi.Application.BookOperations.Commands.Update;
using Xunit;

namespace UnitTest.Application.BookOperations.Commands.Delete
{
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private DeleteBookCommandValidator _validator;

        public DeleteBookCommandValidatorTests()
        {
            _validator = new();
        }

        [NUnit.Framework.Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void WhenBookIdLessThanOrEqualZero_ValidationShouldReturnError(int bookId)
        {
            // arrange
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;

            // act
            var result = _validator.Validate(command);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenBookIdGreaterThanZero_ValidationShouldNotReturnError()
        {
            // arrange
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = 12;

            // act
            var result = _validator.Validate(command);

            // assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
