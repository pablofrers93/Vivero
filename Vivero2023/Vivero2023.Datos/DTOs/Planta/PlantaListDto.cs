using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivero2023.Datos.DTOs.Planta
{
    public class PlantaListDto
    {
        public int PlantaId { get; set; }
        public string Descripcion { get; set; }
        public string TipoPlanta { get; set; }
        public string TipoEnvase { get; set; }
    }
}
