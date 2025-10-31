using System.ComponentModel.DataAnnotations;

namespace CMCapitalTesteController.Models
{
    public class ProdutoBO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Preco { get; set; }
        public int Quantidade { get; set; } = 0;
    }
}
