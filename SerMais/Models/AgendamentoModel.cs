using System.ComponentModel.DataAnnotations;

namespace SerMais.Models
{
    public class AgendamentoModel
    {
        [Key]
        public int ID { get; set; }

        //relação
        public ProfissionalModel ID_PROFISSIONAL { get; set; }
        public ClienteModel ID_CLIENTE { get; set; }
    }
}
