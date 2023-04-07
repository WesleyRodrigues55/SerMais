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

        public int POLITICA { get; set; }

        public int ATIVO { get; set; }

        //relação
        public ProfissionalModel ID_PROFISSIONAL { get; set; }

    }

}
