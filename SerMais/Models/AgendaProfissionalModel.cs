using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerMais.Models
{
    public class AgendaProfissionalModel
    {
        [Key]
        public int ID { get; set; }

        public string HORA_START { get; set; }

        public string HORA_END { get; set; }

        public string DIA { get; set; }

        public string REPETE { get; set; }

        public int ATIVO { get; set; } = 1;
        public ProfissionalModel ID_PROFISSIONAL { get; set; }

    }
}
