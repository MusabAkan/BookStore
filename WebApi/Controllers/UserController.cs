using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.UserOperations.Command.Create;
using WebApi.DbContexts;
using WebApi.Middlewares.TokenOperations.Models;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly LibaryDbContext _context;
        readonly IMapper _mapper;
        IConfiguration _config;

        public UserController(LibaryDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new (_context, _mapper);
            command.Model = newUser;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new(_context, _mapper, _config);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpPost("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] CreateTokenModel login)
        {
            RefreshTokenCommand command = new(_context, _mapper, _config);
            command.RefreshToken = token;
            command.Model = login;
            var token = command.Handle();
            return token;
        }




    }
}
