using System.ComponentModel.DataAnnotations;

namespace imobiliaria.Models
{
    public class ContratoAluguel
    {
        [Key]
        [Required]
        public int idContratoAluguel { get; set; }
        [Required]
        public DateTime DataAssinatura { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataFim { get; set; }
        [Required]
        public decimal Valor { get; set; }
        public virtual Inquilino Inquilino { get; set; }
        [Required]
        public int IdInquilino { get; set; }
        public virtual Imovel Imovel { get; set; }
        [Required]
        public int IdImovel { get; set; }
    }
}
