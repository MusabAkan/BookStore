using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.Create;
using WebApi.Application.AuthorOperations.Commands.Delete;
using WebApi.Application.AuthorOperations.Commands.Update;
using WebApi.Application.AuthorOperations.Queries;
using WebApi.DbContexts;

namespace WebApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        readonly ILibaryDbContext _context;
        readonly IMapper _mapper;
        public AuthorController(ILibaryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetAuthorDetailQuery query = new(_context, _mapper)
            {
                AuthorId = id
            };
            var result = query.Handle();
            return Ok(result);
        }

        //Post
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new(_context, _mapper);
            CreateAuthorCommandValidator validator = new();
            command.Model = newAuthor;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor)
        {
            UpdateAuthorCommand command = new(_context, _mapper)
            {
                AuthorId = id,
                Model = updateAuthor
            };
            UpdateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new(_context)
            {
                AuthorId = id
            };
            DeleteAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}
