using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VolvoTruck.App.Extensions;

namespace VolvoTruck.App.Models
{
    public class Truck : Entity
    {
        [CurrentDate(ErrorMessage = "O ano do modelo deve ser maior ou igual ao ano atual")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Ano Modelo")]
        public int ModelYear { get; set; }
        [DisplayName("Ano de Fabricação")]
        public int FabricationYear { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Modelo")]
        public TruckModelEnum TruckModel { get; set; }

        public Truck()
        {
            FabricationYear = DateTime.Now.Year;
        }
    }
}
