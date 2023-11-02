using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbContexts;

namespace UnitTest.TestSetup
{
    public class CommonTestFixture
    {
        public LibaryDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<LibaryDbContext>().UseInMemoryDatabase("BookStoreDB").Options;
            Context = new LibaryDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

        }

    }
}
