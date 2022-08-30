namespace PolloRapiApi.Models
{
    public class Comprobante
    {
        public int Id { get; set; }

        public int? MedioPagoId { get; set; }
        public Enumerado? MedioPago { get; set; }
        public int? TipoDocumentoId { get; set; }
        public Enumerado? TipoDocumento { get; set; }
        public int CuentasId { get; set; }
        public Cuentas? Cuentas { get; set; }
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

    }
}
