using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioProdutoAPI.Domain.Entities;

namespace DesafioProdutoAPI.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<Produto?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task<IEnumerable<Produto>> ObterPorCategoriaAsync(string categoria);
    Task AdicionarAsync(Produto produto);
    Task AtualizarAsync(Produto produto);
    Task RemoverAsync(Guid id);
}