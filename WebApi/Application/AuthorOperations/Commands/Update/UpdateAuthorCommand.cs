using AutoMapper;
using WebApi.DbContexts;

namespace WebApi.Application.AuthorOperations.Commands.Update
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        readonly ILibaryDbContext _dbContext;
        readonly IMapper _mapper;

        public int AuthorId { get; set; }
        public UpdateAuthorCommand(ILibaryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Yazar mevcut değil");

            author = _mapper.Map(Model, author);

            _dbContext.Authors.Update(author);
            _dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
