using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioProdutoAPI.Domain.Entities;

public class Produto
{
    public Guid Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Categoria { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Preco { get; set; }

    [Range(0, int.MaxValue)]
    public int QuantidadeEmEstoque { get; set; }

    public DateTime DataInclusao { get; set; }

    public bool Disponivel => QuantidadeEmEstoque > 0;
}