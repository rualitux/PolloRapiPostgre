

namespace PolloRapiApi.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Modulo { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
