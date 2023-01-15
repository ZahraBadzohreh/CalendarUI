using CalendarUI.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalendarUI.Data.Test.Infrastructure
{
    public class DatabaseTestBase : IDisposable
    {
        protected readonly CalendarContext Context;

        public DatabaseTestBase()
        {
            var options = new DbContextOptionsBuilder<CalendarContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            Context = new CalendarContext(options);

            Context.Database.EnsureCreated();

            DatabaseInitializer.Initialize(Context);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();

            Context.Dispose();
        }
    }
}
