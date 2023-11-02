using AutoMapper;
using WebApi.DbContexts;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.Create
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        readonly ILibaryDbContext _dbContext;
        readonly IMapper _mapper;
        public CreateAuthorCommand(ILibaryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            //var book = _dbContext.Authors.SingleOrDefault();// Aynı ad ve soyadan farklı bir  yazar olabilir 

            var author = _mapper.Map<Author>(Model);
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
