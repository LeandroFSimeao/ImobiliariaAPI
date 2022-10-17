using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace imobiliaria.Models
{
    public class Imovel
    {
        [Key]
        [Required]
        public int IdImovel { get; set; }
        [Required]
        public int QtQuartos { get; set; }
        [Required]
        public int QtBanheiros { get; set; }
        public virtual Endereco Endereco { get; set; }
        [Required]
        public int IdEndereco { get; set; }
        public virtual Proprietario Proprietario { get; set; }
        [Required]
        public int IdProprietario { get; set; }
        [JsonIgnore]
        public virtual List<ContratoAluguel> Contratos { get; set; }
    }
}
