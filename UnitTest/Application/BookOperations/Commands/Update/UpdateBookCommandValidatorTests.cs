using FluentAssertions;
using UnitTest.TestSetup;
using WebApi.Application.BookOperations.Commands.Update;
using Xunit;

namespace UnitTest.Application.BookOperations.Commands.Update
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private UpdateBookCommandValidator _validator;

        public UpdateBookCommandValidatorTests()
        {
            _validator = new();
        }

        [NUnit.Framework.Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void WhenBookIdIsInvalid_Validator_ShouldHaveError(int bookId)
        {
            // arrange
            var model = new UpdateBookModel { Title = "Right Title", GenreId = 3, AuthorId = 3 };
            UpdateBookCommand command = new(null,null);
            command.Model = model;
            command.BookId = bookId;

            // act
            var result = _validator.Validate(command);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [NUnit.Framework.Theory]
        [InlineData("", 0, 0)]
        [InlineData(null, 0, 0)]
        [InlineData("x", 1, 1)]
        [InlineData("123", 2, 2)]
        public void WhenModelIsInvalid_Validator_ShouldHaveError(string title, int genreId, int authorId)
        {
            // arrange
            var model = new UpdateBookModel { Title = title, GenreId = genreId, AuthorId = authorId };
            UpdateBookCommand updateCommand = new(null, null) ;
            updateCommand.BookId = 1;
            updateCommand.Model = model;

            // act
            var result = _validator.Validate(updateCommand);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [NUnit.Framework.Theory]
        [InlineData("Title", 1, 1)]
        [InlineData("Long Title", 2, 2)]
        public void WhenInputsAreValid_Validator_ShouldNotHaveError(string title, int genreId, int authorId)
        {
            // arrange
            var model = new UpdateBookModel { Title = title, GenreId = genreId, AuthorId = authorId };
            UpdateBookCommand updateCommand = new(null,null);
            updateCommand.BookId = 2;
            updateCommand.Model = model;

            // act
            var result = _validator.Validate(updateCommand);

            // assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
