using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class ConsultaModel
    {
        [Key]
        public int ID { get; set; }
        public string QUEIXA { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; } = "PENDENTE";

        public string TIPO_REUNIAO { get; set; }

        public AgendaProfissionalModel ID_AGENDA_PROFISSIONAL { get; set; }
        public ClienteModel ID_CLIENTE { get; set; }
    }
}
