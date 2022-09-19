using System.ComponentModel.DataAnnotations;

namespace APIDesafio.Models {
    public class Atendimento {
        [Key]
        public int ID { get; set; }
        public int Mesa { get; set; }
        public DateTime DtAtendimento { get; set; }
    }
}
