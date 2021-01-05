using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VolvoTruck.App.Extensions;

namespace VolvoTruck.App.Models
{
    public class Caminhao : Entity
    {
        [CurrentDate(ErrorMessage = "O ano de fabricação deve ser maior ou igual ao atual")]
        [DisplayName("Ano Modelo")]
        public int AnoModelo { get; set; }
        [DisplayName("Ano de Fabricação")]
        public int AnoFabricacao { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public ModeloCaminhaoEnum Modelo { get; set; }

        public Caminhao()
        {
            AnoFabricacao = DateTime.Now.Year;
        }
    }
}
