using AutoMapper;
using WebApi.DbContexts;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.Create;

public class CreateGenreCommand
{
    public CreateGenreModel Model { get; set; }
    readonly ILibaryDbContext _dbContext;
    readonly IMapper _mapper;
    public CreateGenreCommand(ILibaryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == Model.Id);

        if (genre is not null)
            throw new InvalidOperationException("Kitap türü zaten mevcut");
        genre = new Genre();
        genre.Name = Model.Name;
        genre.IsActive = Model.IsActive;
          

        _dbContext.Genres.Add(genre);
        _dbContext.SaveChanges();
    }
}
public class CreateGenreModel
{

    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}