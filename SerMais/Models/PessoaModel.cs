using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class PessoaModel
    {
        [Key]
        public int ID { get; set; }
        public int CRP { get; set; }

        [StringLength(100)]
        public string NOME { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [DataType(DataType.Date)]
        public DateTime DT_NASCIMENTO { get; set; }

        [StringLength(50)]
        public string CELULAR { get; set; }

        [StringLength(14)]
        public string CPF { get; set; }

        [StringLength(12)]
        public string RG { get; set; }

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

        public int ATIVO { get; set; }

    }
}
