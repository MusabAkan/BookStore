using AutoMapper;
using WebApi.DbContexts;
using WebApi.Middlewares.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Command.Create
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        readonly ILibaryDbContext _dbContext;
        readonly IMapper _mapper;
        readonly IConfiguration _configurationg;
        public CreateTokenCommand(ILibaryDbContext dbContext, IMapper mapper, IConfiguration configurationg)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configurationg = configurationg;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email== Model.Email && x.Password == Model.Password);
            if(user is null)
                throw new InvalidOperationException("Kullancı adı veya şifre yanlış");
            //token yarat
            Middlewares.TokenOperations.TokenHandler handler = new (_configurationg);
            Token token = handler.CreateAccessToken(user);
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();
            return token;
        }
    }
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; } 
    }
}

