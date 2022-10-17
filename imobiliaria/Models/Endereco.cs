using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace imobiliaria.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int IdEndereco { get; set; }
        [Required]
        [MinLength(8)]
        public string Cep { get; set; }
        [Required]
        [MaxLength(100)]
        public string Logradouro { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        [MaxLength(100)]
        public string Cidade { get; set; }
        [Required]
        [MaxLength(100)]
        public string Estado { get; set; }
        [JsonIgnore]
        public virtual Imovel Imovel { get; set; }
    }
}
