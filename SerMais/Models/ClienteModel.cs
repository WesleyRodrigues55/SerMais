using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class ClienteModel
    {
        [Key]
        public int ID { get; set; }

        [StringLength(200)]
        public string NOME_COMPLETO { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(14)]
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        public DateTime DT_NASCIMENTO { get; set; }

        [StringLength(50)]
        public string TELEFONE { get; set; }

        public int ATIVO { get; set; } = 1;
    }
}
