using AutoMapper;
using Microsoft.VisualBasic;
using WebApi.DbContexts;
using WebApi.Middlewares.TokenOperations;
using WebApi.Middlewares.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Command.Create
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        readonly ILibaryDbContext _dbContext;
        readonly IMapper _mapper;
        readonly IConfiguration _configurationg;
        public RefreshTokenCommand(ILibaryDbContext dbContext, IMapper mapper, IConfiguration configurationg)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configurationg = configurationg;
        }

        public RefreshTokenModel Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is null)
                throw new InvalidOperationException("Valid bir Refresh Token bulanamadı");
            TokenHandler token = new TokenHandler(_configurationg);
            user.RefreshToken = token.RefreshToken;



            user.RefreshToken =  token


        }
    }
    public class RefreshTokenModel
    {

        public string Email { get; set; }
        public string Password { get; set; } 
    }
}

