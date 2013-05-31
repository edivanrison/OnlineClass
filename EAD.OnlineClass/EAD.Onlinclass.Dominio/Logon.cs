using System.ComponentModel.DataAnnotations;

namespace EAD.Onlineclass.Dominio
{
    public class Logon
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { get; set; }
    }
}
