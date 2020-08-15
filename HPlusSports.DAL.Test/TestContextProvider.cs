using Microsoft.EntityFrameworkCore;

namespace HPlusSports.DAL.Test
{
    public static class TestContextProvider
    {
        public static HPlusSportsContext GetContext(string name)
        {
            var dbOptions = new DbContextOptionsBuilder<HPlusSportsContext>()
                .UseInMemoryDatabase(name).Options;
            return new HPlusSportsContext(dbOptions);
        }
    }
}
