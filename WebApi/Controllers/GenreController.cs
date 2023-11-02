using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using WebApi.Application.GenreOperations.Commands.Create;
using WebApi.Application.GenreOperations.Commands.Delete;
using WebApi.Application.GenreOperations.Commands.Update;
using WebApi.Application.GenreOperations.Queries;
using WebApi.DbContexts;

namespace WebApi.Controllers
{
    [Authorize]

    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        readonly ILibaryDbContext _context;
        readonly IMapper _mapper;
        public GenreController(ILibaryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenreQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetGenreDetailQuery query = new(_context, _mapper)
            {
                GenreId = id
            };
            var result = query.Handle();
            return Ok(result);
        }

        //Post
        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new(_context, _mapper);
            CreateGenreCommandValidator validator = new();
            command.Model = newGenre;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UptadeGenreModel updateGenre)
        {
            UpdateGenreCommand command = new(_context, _mapper)
            {
                GenreId = id,
                Model = updateGenre
            };
            UpdateGenreCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new(_context)
            {
                GenreId = id
            };
            //DeleteGenreCommandValidator validator = new();
            //validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
