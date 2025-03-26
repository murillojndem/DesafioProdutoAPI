using DesafioProdutoAPI.Application.DTOs;
using DesafioProdutoAPI.Application.Services;
using DesafioProdutoAPI.Domain.Entities;
using DesafioProdutoAPI.Domain.Interfaces;
using FluentAssertions;
using FluentValidation;
using Moq;
using Xunit;

namespace DesafioProdutoAPI.Tests.Application.Services;

public class ProdutoServiceTests
{
    private readonly Mock<IProdutoRepository> _mockRepo;
    private readonly Mock<IValidator<ProdutoDTO>> _mockValidator;
    private readonly ProdutoService _service;

    public ProdutoServiceTests()
    {
        _mockRepo = new Mock<IProdutoRepository>();
        _mockValidator = new Mock<IValidator<ProdutoDTO>>();
        _service = new ProdutoService(_mockRepo.Object, _mockValidator.Object);
    }

    [Fact]
    public async Task CriarProdutoAsync_DeveRetornarProduto_QuandoDtoValido()
    {
        var dto = new ProdutoDTO
        {
            Nome = "Teste",
            Categoria = "Categoria",
            Preco = 10,
            QuantidadeEmEstoque = 5
        };

        _mockValidator.Setup(v => v.ValidateAsync(dto, default))
            .ReturnsAsync(new FluentValidation.Results.ValidationResult());

        var result = await _service.CriarProdutoAsync(dto);

        result.Should().NotBeNull();
        result.Nome.Should().Be(dto.Nome);
        _mockRepo.Verify(r => r.AdicionarAsync(It.IsAny<Produto>()), Times.Once);
    }

    [Fact]
    public async Task CriarProdutoAsync_DeveLancarExcecao_QuandoDtoInvalido()
    {
        var dto = new ProdutoDTO();
        var validationResult = new FluentValidation.Results.ValidationResult();
        validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("Nome", "Obrigatório"));

        _mockValidator.Setup(v => v.ValidateAsync(dto, default))
            .ReturnsAsync(validationResult);

        await Assert.ThrowsAsync<ValidationException>(() => _service.CriarProdutoAsync(dto));
    }

    [Fact]
    public async Task ObterPorIdAsync_DeveRetornarProduto_QuandoExistir()
    {
        var id = Guid.NewGuid();
        var produto = new Produto { Id = id };

        _mockRepo.Setup(r => r.ObterPorIdAsync(id))
            .ReturnsAsync(produto);

        var result = await _service.ObterPorIdAsync(id);

        result.Should().NotBeNull();
        result.Id.Should().Be(id);
    }
}