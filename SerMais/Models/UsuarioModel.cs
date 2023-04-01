using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
 
        [StringLength(50)]
        public string USUARIO { get; set; }
 
        [StringLength(50)]
        public string SENHA { get; set; }

        public int ATIVO { get; set; }

        public int NIVEL { get; set; }

        //relação
        public PessoaModel PessoaModel { get; set; }

    }

}
