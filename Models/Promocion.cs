using System.ComponentModel.DataAnnotations;

namespace PolloRapiApi.Models
{
    public class Promocion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]

        public DateTime? FechaFin { get; set; }

        public ICollection<ProductoPromocion>? ProductoPromociones { get; set; }

        public ICollection<PedidoDetalle>? PedidoDetalles { get; set; }

    }
}
