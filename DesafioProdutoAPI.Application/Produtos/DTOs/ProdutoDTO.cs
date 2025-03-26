using System.Net.Mail;
using System.Text.Json.Serialization;

namespace DesafioProdutoAPI.Application.DTOs;

public class ProdutoDTO
{
    public string Nome { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }
}

public class ProdutoDetalhesDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public bool Disponivel { get; set; }
    public DateTime DataInclusao { get; set; }
}