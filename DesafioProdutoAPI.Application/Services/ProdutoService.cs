using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using DesafioProdutoAPI.Application.DTOs;
using DesafioProdutoAPI.Domain.Entities;
using DesafioProdutoAPI.Domain.Interfaces;

namespace DesafioProdutoAPI.Application.Services;


public class ProdutoService
{
    private readonly IProdutoRepository _repositorio;
    private readonly IValidator<ProdutoDTO> _validador;

    public ProdutoService(IProdutoRepository repositorio, IValidator<ProdutoDTO> validador)
    {
        _repositorio = repositorio;
        _validador = validador;
    }

    public async Task<ProdutoDetalhesDTO> CriarProdutoAsync(ProdutoDTO dto)
    {
        var resultadoValidacao = await _validador.ValidateAsync(dto);
        if (!resultadoValidacao.IsValid)
        {
            throw new ValidationException(resultadoValidacao.Errors);
        }

        var produto = new Produto
        {
            Nome = dto.Nome,
            Categoria = dto.Categoria,
            Preco = dto.Preco,
            QuantidadeEmEstoque = dto.QuantidadeEmEstoque
        };

        await _repositorio.AdicionarAsync(produto);
        return MapToDetalhesDTO(produto);
    }

    public async Task<ProdutoDetalhesDTO> ObterPorIdAsync(Guid id)
    {
        var produto = await _repositorio.ObterPorIdAsync(id);
        if (produto == null) return null;

        return MapToDetalhesDTO(produto);
    }

    public async Task<IEnumerable<ProdutoDetalhesDTO>> ObterTodosAsync()
    {
        var produtos = await _repositorio.ObterTodosAsync();
        return produtos.Select(MapToDetalhesDTO);
    }

    public async Task<IEnumerable<ProdutoDetalhesDTO>> ObterPorCategoriaAsync(string categoria)
    {
        var produtos = await _repositorio.ObterPorCategoriaAsync(categoria);
        return produtos.Select(MapToDetalhesDTO);
    }

    public async Task<ProdutoDetalhesDTO> AtualizarProdutoAsync(Guid id, ProdutoDTO dto)
    {
        var resultadoValidacao = await _validador.ValidateAsync(dto);
        if (!resultadoValidacao.IsValid)
        {
            throw new ValidationException(resultadoValidacao.Errors);
        }

        var produtoExistente = await _repositorio.ObterPorIdAsync(id);
        if (produtoExistente == null) return null;

        produtoExistente.Nome = dto.Nome;
        produtoExistente.Categoria = dto.Categoria;
        produtoExistente.Preco = dto.Preco;
        produtoExistente.QuantidadeEmEstoque = dto.QuantidadeEmEstoque;

        await _repositorio.AtualizarAsync(produtoExistente);
        return MapToDetalhesDTO(produtoExistente);
    }

    public async Task<bool> RemoverProdutoAsync(Guid id)
    {
        var produto = await _repositorio.ObterPorIdAsync(id);
        if (produto == null) return false;

        await _repositorio.RemoverAsync(id);
        return true;
    }

    private static ProdutoDetalhesDTO MapToDetalhesDTO(Produto produto)
    {
        return new ProdutoDetalhesDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Categoria = produto.Categoria,
            Preco = produto.Preco,
            QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
            DataInclusao = produto.DataInclusao,
            Disponivel = produto.Disponivel
        };
    }
}