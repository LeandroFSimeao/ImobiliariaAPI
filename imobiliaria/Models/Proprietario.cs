using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace imobiliaria.Models
{
    public class Proprietario
    {
        [Key]
        [Required]
        public int IdProprietario { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MinLength(11)]
        public string Cpf { get; set; }
        [JsonIgnore]
        public virtual List<Imovel> Imoveis { get; set; }
    }
}
