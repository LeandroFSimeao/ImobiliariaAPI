namespace imobiliaria.Data.Dtos
{
    public class ContratoDTO
    {
        public int idContratoAluguel { get; set; }
        public DateTime DataAssinatura { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal Valor { get; set; }
        public int IdInquilino { get; set; }
        public int IdImovel { get; set; }
    }
}
