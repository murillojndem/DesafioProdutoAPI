using Microsoft.AspNetCore.Mvc;
using DesafioProdutoAPI.Application.Services;
using DesafioProdutoAPI.Application.DTOs;
using FluentValidation;
using DesafioProdutoAPI.HATEOAS;

namespace DesafioProdutoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _servico;
    private readonly ILogger<ProdutoController> _logger;

    public ProdutoController(ProdutoService servico, ILogger<ProdutoController> logger)
    {
        _servico = servico;
        _logger = logger;
    }

    private ProdutoDetalhesDTOHateoas ComHateoas(ProdutoDetalhesDTO dto)
    {
        var hateoas = new ProdutoDetalhesDTOHateoas
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Categoria = dto.Categoria,
            Preco = dto.Preco,
            QuantidadeEmEstoque = dto.QuantidadeEmEstoque,
            Disponivel = dto.Disponivel,
            DataInclusao = dto.DataInclusao
        };
        hateoas.AddHateoasLinks(Url);
        return hateoas;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] ProdutoDTO dto)
    {
        try
        {
            if (string.IsNullOrEmpty(dto.Nome))
                return BadRequest("Nome é obrigatório");

            var resultado = await _servico.CriarProdutoAsync(dto);
            var resultadoComLinks = ComHateoas(resultado);

            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultadoComLinks);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar produto");
            return StatusCode(500, new { Error = "Erro interno", Details = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        try
        {
            var produto = await _servico.ObterPorIdAsync(id);
            if (produto == null) return NotFound();

            var resultadoComLinks = ComHateoas(produto);
            return Ok(resultadoComLinks);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar produto");
            return StatusCode(500, new { Error = "Erro interno", Details = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var produtos = await _servico.ObterTodosAsync();
        var resultado = produtos.Select(ComHateoas).ToList();
        return Ok(resultado);
    }

    [HttpGet("categoria/{categoria}")]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> ObterPorCategoria(string categoria)
    {
        var produtos = await _servico.ObterPorCategoriaAsync(categoria);
        var resultado = produtos.Select(ComHateoas).ToList();
        return Ok(resultado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] ProdutoDTO dto)
    {
        try
        {
            var resultado = await _servico.AtualizarProdutoAsync(id, dto);
            if (resultado == null) return NotFound();

            var resultadoComLinks = ComHateoas(resultado);
            return Ok(resultadoComLinks);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar produto");
            return StatusCode(500, "Ocorreu um erro interno");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        var sucesso = await _servico.RemoverProdutoAsync(id);
        if (!sucesso) return NotFound();

        return NoContent();
    }
}
