using AutoMapper;
using WebApi.DbContexts;

namespace WebApi.Application.GenreOperations.Commands.Update;

public class UpdateGenreCommand
{
    public UptadeGenreModel Model { get; set; }
    readonly ILibaryDbContext _dbContext;
    readonly IMapper _mapper;

    public int GenreId { get; set; }
    public UpdateGenreCommand(ILibaryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

        if (genre is null)
            throw new InvalidOperationException("Kitap türü mevcut değil");

        if (_dbContext.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
            throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut");

        genre = _mapper.Map(Model, genre);

        _dbContext.Genres.Update(genre);

        _dbContext.SaveChanges();
    }
}
public class UptadeGenreModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}