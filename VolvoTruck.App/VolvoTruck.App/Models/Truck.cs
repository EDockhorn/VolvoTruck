using System;
using System.ComponentModel;
using VolvoTruck.App.Extensions;

namespace VolvoTruck.App.Models
{
    public class Truck : Entity
    {
        [CurrentDate(ErrorMessage = "O ano de fabricação deve ser maior ou igual ao atual")]
        [DisplayName("Ano Modelo")]
        public int ModelYear { get; set; }
        [DisplayName("Ano de Fabricação")]
        public int FabricationYear { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        public TruckModelEnum TruckModel { get; set; }

        public Truck()
        {
            FabricationYear = DateTime.Now.Year;
        }
    }
}
