using DesafioProdutoAPI.Application.DTOs;
using DesafioProdutoAPI.HATEOAS;

namespace DesafioProdutoAPI.HATEOAS
{
    public class ProdutoDetalhesDTOHateoas : ProdutoDetalhesDTO
    {
        public List<LinkResource> Links { get; set; } = new();
    }
}
