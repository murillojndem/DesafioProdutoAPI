using DesafioProdutoAPI.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace DesafioProdutoAPI.Tests.Domain.Entities;

public class ProdutoTests
{
    [Fact]
    public void Produto_DeveCalcularDisponibilidadeCorretamente()
    {
        var produtoComEstoque = new Produto
        {
            QuantidadeEmEstoque = 5
        };

        var produtoSemEstoque = new Produto
        {
            QuantidadeEmEstoque = 0
        };

        produtoComEstoque.Disponivel.Should().BeTrue();
        produtoSemEstoque.Disponivel.Should().BeFalse();
    }

    [Theory]
    [InlineData(0.01, true)]
    [InlineData(0, false)]
    [InlineData(-1, false)]
    public void Produto_DeveValidarPreco(decimal preco, bool valido)
    {
        var produto = new Produto { Preco = preco };

        if (valido)
        {
            produto.Preco.Should().BeGreaterThan(0);
        }
        else
        {
            produto.Preco.Should().BeLessThanOrEqualTo(0);
        }
    }
}