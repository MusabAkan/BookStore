 

namespace BookStoreTest.TestSetup
{
    internal class CommonTestFixture
    {
        public LibaryDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
    }
}
