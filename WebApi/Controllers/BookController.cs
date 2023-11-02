using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Commands.Create;
using WebApi.Application.BookOperations.Commands.Delete;
using WebApi.Application.BookOperations.Commands.Update;
using WebApi.Application.BookOperations.Queries;
using WebApi.DbContexts;


namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        readonly ILibaryDbContext _context;
        readonly IMapper _mapper;
        public BookController(ILibaryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailQuery query = new(_context, _mapper)
            {
                BookId = id
            };
            var result = query.Handle();
            return Ok(result);
        }

        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new(_context, _mapper);
            CreateBookCommandValidator validator = new();
            command.Model = newBook;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {
            UpdateBookCommand command = new(_context, _mapper)
            {
                BookId = id,
                Model = updateBook
            };
            UpdateBookCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new(_context)
            {
                BookId = id
            };
            DeleteBookCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}
