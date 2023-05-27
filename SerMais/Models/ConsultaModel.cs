using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class ConsultaModel
    {
        [Key]
        public int ID { get; set; }
        public string QUEIXA { get; set; }

        public DateTime DATA_START { get; set; }
        public DateTime DATA_END { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        public string LINK_REUNIAO { get; set; }

        [StringLength(50)]
        public string FORMA_DE_PAGAMENTO { get; set; }

        public AgendamentoModel ID_AGENDAMENTO { get; set; }
    }
}
