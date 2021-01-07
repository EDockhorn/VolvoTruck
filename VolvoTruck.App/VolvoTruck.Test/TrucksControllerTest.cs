using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace VolvoTruck.Test
{
    public class TrucksControllerTest
    {
        [Fact]
        public async Task Should_Return_A_Valid_Truck_Object_When_Calling_Index_Without_Parameters()
        {
            var dbContextMock = await Configure.GetDatabaseMockContext();

            using (var trucksController = new VolvoTruck.App.Controllers.TrucksController(dbContextMock))
            {
                var trucks = await trucksController.Index();
                Assert.NotNull(trucks);
            }
        }

        [Fact]
        public async Task Should_Return_A_Single_Truck_When_Calling_ListTrucks_Without_Parameters()
        {
            var dbContextMock = await Configure.GetDatabaseMockContext();

            using (var trucksController = new VolvoTruck.App.Controllers.TrucksController(dbContextMock))
            {
                var trucks = await trucksController.ListTrucks();
                Assert.Single(trucks);
            }
        }

        [Theory, MemberData(nameof(Guids))]
        public async Task Should_Return_A_Truck_With_Valid_Object_When_Calling_Details_With_Guid_Parameter(Guid id)
        {
            var dbContextMock = await Configure.GetDatabaseMockContext();

            using (var trucksController = new VolvoTruck.App.Controllers.TrucksController(dbContextMock))
            {
                var trucks = await trucksController.Details(id);
                Assert.NotNull(trucks);
            }
        }


        [Fact]
        public async Task Should_Return_A_Valid_CreateView_When_Calling_Create_Without_Parameters()
        {
            var dbContextMock = await Configure.GetDatabaseMockContext();

            using (var trucksController = new VolvoTruck.App.Controllers.TrucksController(dbContextMock))
            {
                var trucks = trucksController.Create();
                Assert.NotNull(trucks);
            }
        }
        [Fact]
        public async Task Should_Return_A_Confirmation_Of_Create_When_Calling_Create_Without_Parameters()
        {
            var dbContextMock = await Configure.GetDatabaseMockContext();

            using (var trucksController = new VolvoTruck.App.Controllers.TrucksController(dbContextMock))
            {
                var trucks = trucksController.CreatePost(await Configure.GetTruck());
                Assert.NotNull(trucks);
            }
        }

        [Fact]
        public async Task Should_Return_A_ActualYear_When_Calling_ModelYearList_Without_Parameters()
        {
            var dbContextMock = await Configure.GetDatabaseMockContext();

            using (var trucksController = new VolvoTruck.App.Controllers.TrucksController(dbContextMock))
            {
                var trucks = trucksController.ModelYearLists();
                Assert.Equal(System.DateTime.Now.Year.ToString(), trucks[0].ToString());
            }
        }

        public static IEnumerable<object[]> Guids
        {
            get
            {
                yield return new object[] { new Guid("bd32eddb-4817-4a6d-a203-b172036a4aa8") };
            }
        }


    }
}
