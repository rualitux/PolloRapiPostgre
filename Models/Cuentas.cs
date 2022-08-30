namespace PolloRapiApi.Models
{
    public class Cuentas
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
