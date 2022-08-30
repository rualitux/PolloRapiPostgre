using System.ComponentModel.DataAnnotations;

namespace PolloRapiApi.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
     
        [DataType(DataType.Currency)]
        public decimal PrecioBruto { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Descuento { get; set; }
        [DataType(DataType.Currency)]
        public decimal PrecioNeto { get; set; }

        public string Imagen { get; set; }

        public ICollection<ProductoPromocion>? ProductoPromociones { get; set; }
        public ICollection<PedidoDetalle>? PedidoDetalles { get; set; }

    }
}
