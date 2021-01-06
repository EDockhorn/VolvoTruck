using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace VolvoTruck.Test
{
    public class UnitTest1 : DbContext
    {
        private readonly VolvoTruckAppContext _context;

        [Fact]
        public void ListTruckIndexTest()
        {
            var controller = new App.Controllers.TrucksController(_context);

            var mockSet = new Mock<DbSet<App.Models.Truck>>();


        }
        public BooksContext(DbContextOptions<VolvoTruckAppContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
