using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class TipoConsultaModel
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string NOME_TIPO_CONSULTA { get; set; }
    }
}
