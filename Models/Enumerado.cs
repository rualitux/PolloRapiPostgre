namespace PolloRapiApi.Models
{
    public class Enumerado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        //  public Enumerado? Padre { get; set; }

        //public ICollection<Enumerado>? Hijo { get; set; }
        public ICollection<EnumeradoJerarquia>? Ancestros { get; set; }
        public ICollection<EnumeradoJerarquia>? Descendientes { get; set; }

        public ICollection<ProductoPromocion>? ProductoPromociones { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
        public ICollection<Comprobante>? MedioPagos { get; set; }
        public ICollection<Comprobante>? TipoDocumentos { get; set; }
    }
}
