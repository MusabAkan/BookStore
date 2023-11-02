using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.Create;
using WebApi.Application.AuthorOperations.Commands.Update;
using WebApi.Application.AuthorOperations.Queries;
using WebApi.Application.BookOperations.Commands.Create;
using WebApi.Application.BookOperations.Queries;
using WebApi.Application.GenreOperations.Commands.Create;
using WebApi.Application.GenreOperations.Commands.Update;
using WebApi.Application.GenreOperations.Queries;
using WebApi.Application.UserOperations.Command.Create;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Books
            CreateMap<CreateBookModel, Book>();
            CreateMap<UpdateBookModel, Book>();
            CreateMap<Book, BooksDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (GenrEnum)src.GenreId));//Burası çok önemli ilerde lazım olur keke
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (GenrEnum)src.GenreId));
            #endregion

            #region Genre
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresDetailsViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<UptadeGenreModel, Genre>();
            #endregion

            #region Author

            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorsDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<UpdateAuthorModel, Author>();
            #endregion

            #region User

            CreateMap<CreateUserModel, User>();


            #endregion



        }
    }
}
