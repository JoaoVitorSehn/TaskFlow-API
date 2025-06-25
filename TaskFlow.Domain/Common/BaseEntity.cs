using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Domain.Common;

public class BaseEntity
{
    [Key]
    [Required]
    public Guid Id { get; set; }
}