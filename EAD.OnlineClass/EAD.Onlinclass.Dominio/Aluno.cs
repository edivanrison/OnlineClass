using System.ComponentModel.DataAnnotations;

namespace EAD.Onlineclass.Dominio
{
    public class Aluno : Logon
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string AlunoNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string AlunoEmail { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string AlunoRG { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string AlunoTelefone { get; set; }
    }
}