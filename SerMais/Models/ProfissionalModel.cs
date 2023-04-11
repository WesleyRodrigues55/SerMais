using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerMais.Models
{
    public class ProfissionalModel
    {
        [Key]
        public int ID { get; set; }

        // DADOS PESSOAIS
        public string CRP { get; set; }

        [StringLength(50)]
        public string NOME { get; set; }

        [StringLength(50)]
        public string SOBRENOME { get; set; }

        [StringLength(200)]
        public string NOME_COMPLETO { get; set; }

        [DataType(DataType.Date)]
        public DateTime DT_NASCIMENTO { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string TELEFONE { get; set; }

        [StringLength(14)]
        public string CPF { get; set; }

        // ENDEREÇO

        [StringLength(10)]
        public string CEP { get; set; }

        [StringLength(100)]
        public string RUA { get; set; }

        [StringLength(100)]
        public string BAIRRO { get; set; }

        [StringLength(100)]
        public string CIDADE { get; set; }

        [StringLength(50)]
        public string NUMERO { get; set; }

        [StringLength(100)]
        public string COMPLEMENTO { get; set; }

        public string OBSERVACAO { get; set; }

        [NotMapped]
        public IFormFile FILE { set; get; }

        public int ATIVO { get; set; }

        public int NIVEL { get; set; }

        public int STATUS { get; set; }

        public TipoProfissionalModel ID_TIPO_PROFISSIONAL { get; set; }
    }
}
