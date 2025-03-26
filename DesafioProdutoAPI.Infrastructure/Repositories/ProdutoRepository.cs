using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProdutoAPI.Domain.Entities;
using DesafioProdutoAPI.Domain.Interfaces;

namespace DesafioProdutoAPI.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private static readonly List<Produto> _produtos = new();

    public Task<Produto> ObterPorIdAsync(Guid id)
    {
        return Task.FromResult(_produtos.FirstOrDefault(p => p.Id == id));
    }

    public Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        return Task.FromResult(_produtos.AsEnumerable());
    }

    public Task<IEnumerable<Produto>> ObterPorCategoriaAsync(string categoria)
    {
        var produtos = _produtos.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(produtos.AsEnumerable());
    }

    public Task AdicionarAsync(Produto produto)
    {
        produto.Id = Guid.NewGuid();
        produto.DataInclusao = DateTime.Now;
        _produtos.Add(produto);
        return Task.CompletedTask;
    }

    public Task AtualizarAsync(Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == produto.Id);
        if (index >= 0)
        {
            _produtos[index] = produto;
        }
        return Task.CompletedTask;
    }

    public Task RemoverAsync(Guid id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            _produtos.Remove(produto);
        }
        return Task.CompletedTask;
    }
}