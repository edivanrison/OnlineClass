using System.ComponentModel.DataAnnotations;

namespace EAD.Onlineclass.Dominio
{
    public class Cursos
    {
        public int CursoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeDoCurso { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }
    }
}
