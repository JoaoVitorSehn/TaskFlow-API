using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrdemServicoService.Domain.Entities;

namespace TaskOrderService.Models
{
    public class OrdemServico
    {
        [Key]
        [Required]
        int Id { get; set; }

        [Required]
        int Numero { get; set; }

        [Required]
        [ForeignKey(nameof(Cliente))]
        public int ClienteId { get; set; }

        [Required]
        DateTime DataCriacao { get; set; }

        [Required]
        DateTime DataPrevisao { get; set; }

        [Required]
        string Descricao { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}