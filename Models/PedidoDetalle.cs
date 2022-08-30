using System.ComponentModel.DataAnnotations;

namespace PolloRapiApi.Models
{
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        
        [DataType(DataType.Currency)]
        public Decimal Precio { get; set; }
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }

        public int? PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        public int PromocionId { get; set; }
        public Promocion? Promocion { get; set; }

        public int EnumeradoId { get; set; }
        public Enumerado? Enumerado { get; set; }
    }
}
