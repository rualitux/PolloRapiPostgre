
using System.ComponentModel.DataAnnotations;

namespace PolloRapiApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Correo { get; set; }
        public int RolId { get; set; }
        public Rol? Rol { get; set; }

        public ICollection<Cuentas>? Cuentas { get; set; }



    }
}
