using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace VolvoTruck.Test
{
    public class TrucksControllerTest : DbContext
    {
        [Fact]
        public async Task Should_Return_All_Trucks_When_Calling_Index_Without_Parameters()
        {            
            var dbContext = await Configure.GetDatabaseContext();
           
            var TrucksController = new VolvoTruck.App.Controllers.TrucksController(dbContext);
            var trucks = await TrucksController.Index();
            
            Assert.NotNull(trucks);
        }
    }
}
