using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerMais.Models
{
    public class PortfolioModel
    {
        [Key]
        public int ID { get; set; }


        public string? ESPECIALIDADE { get; set; }

        [NotMapped]
        public IFormFile IMAGEM { get; set; }

        public string? IMAGEM_PROFILE { get; set; }


        public double? VALOR_CONSULTA { get; set; }


        public string? FORMAS_PAGAMENTO { get; set; }


        public string? DURACAO_SESSAO { get; set; }


        public string? ATENDE_CONSULTA { get; set; }


        [StringLength(50)]
        public string? TELEFONE { get; set; }


        [StringLength(50)]
        public string? CELULAR { get; set; }


        [StringLength(50)]
        public string? EMAIL { get; set; }


        public string? FORMACAO { get; set; }


        public string? SOBRE { get; set; }

        //relação
        public ProfissionalModel ID_PROFISSIONAL { get; set; }
    }
}
