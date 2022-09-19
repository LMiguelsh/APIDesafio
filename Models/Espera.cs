using APIDesafio.Data;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIDesafio.Models {
    public class Espera {
        public Espera() {
            atendimentos = new Collection<Atendimento>();
        }
        public int ID { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "1-Normal e 2-Prioritário")]
        public int TipoAtendimento { get; set; }
        public bool StatusPainel { get; set; }
        public DateTime DtEmissao { get; set; }

        public ICollection<Atendimento> atendimentos { get; set; }
     
    }
}
