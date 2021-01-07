using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using VolvoTruck.App.Models;

namespace VolvoTruck.Test
{
    public class Configure
    {
        public static async Task<VolvoTruckAppContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<VolvoTruckAppContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new VolvoTruckAppContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Trucks.CountAsync() <= 0)
            {
                for (int i = 1; i <= 2; i++)
                {
                    databaseContext.Trucks.Add(new Truck()
                    {
                        ModelYear = 2020,
                        FabricationYear = 2021,
                        Description = "Descrição Teste",
                        Plate = "01010-0101"                        
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
    }
}
