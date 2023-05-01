using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class UsuarioModel
    {
        [Key]
        public int ID { get; set; }
 
        [StringLength(50)]
        public string USUARIO { get; set; }
 
        [StringLength(50)]
        public string SENHA { get; set; }

        public int POLITICA { get; set; } = 0;

        public int ATIVO { get; set; } = 0;

        //relação
        public ProfissionalModel ID_PROFISSIONAL { get; set; }

    }

}
