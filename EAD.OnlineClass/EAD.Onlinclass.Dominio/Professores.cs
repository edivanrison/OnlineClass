using System.ComponentModel.DataAnnotations;

namespace EAD.Onlineclass.Dominio
{
    public class Professores:Logon
    {
        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ProfessorNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ProfessorEmail { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ProfessorRG { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ProfessorTelefone { get; set; }
    }
}
