using System.ComponentModel.DataAnnotations;

namespace PolloRapiApi.Models
{
    public class Pedido
    {


        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Hora { get; set; }

        public int EnumeradoId { get; set; }

        public Enumerado? Estado { get; set; }

        public ICollection<PedidoDetalle>? PedidoDetalles { get; set; }




    }
}
