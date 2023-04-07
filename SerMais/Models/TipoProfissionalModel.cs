using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class TipoProfissionalModel
    {
        [Key]
        public int ID { get; set; }
        public string NOME_TIPO_PROFISSIONAL { get; set; }
        public int ATIVO { get; set; }
    }
}
