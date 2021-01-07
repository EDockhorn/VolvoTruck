using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using VolvoTruck.App.Models;

namespace VolvoTruck.Test
{
    public class Configure
    {
        public static VolvoTruckAppContext databaseContext { get; set; }

        public static async Task<VolvoTruckAppContext> GetDatabaseMockContext()
        {
            var options = new DbContextOptionsBuilder<VolvoTruckAppContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            databaseContext = new VolvoTruckAppContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Trucks.CountAsync() <= 0)
            {
                for (int i = 1; i <= 1; i++)
                {
                    databaseContext.Trucks.Add(new Truck()
                    {
                        Id = new Guid("bd32eddb-4817-4a6d-a203-b172036a4aa8"),
                        ModelYear = 2020,
                        FabricationYear = 2021,
                        Description = "Descrição Teste",
                        Plate = "01010-0101",
                        TruckModel = TruckModelEnum.FH
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }

            return databaseContext;
        }
        public static Task<Truck> GetTruck()
        {
            return databaseContext.Trucks.FirstOrDefaultAsync();
        }
    }
}
