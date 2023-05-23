using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerMais.Models
{
    public class UsuarioModel
    {
        [Key]
        public int ID { get; set; }
 
        [StringLength(50)]
        public string EMAIL { get; set; }
 
        [StringLength(64)]
        public string SENHA { get; set; }

        [NotMapped]
        public string SENHA_REPETE { get; set; }

        public int POLITICA { get; set; } = 0;

        public int ATIVO { get; set; } = 0;

        [StringLength(64)]
        [Required(AllowEmptyStrings = false)]
        public string TOKEN_RECUPERAR_SENHA { get; set; }

        //relação
        public ProfissionalModel ID_PROFISSIONAL { get; set; }

    }

}
