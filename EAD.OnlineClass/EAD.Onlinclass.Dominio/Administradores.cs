using System.ComponentModel.DataAnnotations;

namespace EAD.Onlineclass.Dominio
{
  public class Administradores:Logon
    {
        public int AdministradorId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string AdministradorNome { get; set; }
    }
}
