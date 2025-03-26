using DesafioProdutoAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DesafioProdutoAPI.HATEOAS
{
    public static class ProdutoHateoasExtensions
    {
        public static void AddHateoasLinks(this ProdutoDetalhesDTOHateoas produto, IUrlHelper urlHelper)
        {
            produto.Links ??= new List<LinkResource>();

            produto.Links.Add(new LinkResource(
                href: urlHelper.Action(nameof(ProdutoController.ObterPorId), "Produto", new { id = produto.Id })!,
                rel: "self",
                method: "GET"
            ));

            produto.Links.Add(new LinkResource(
                href: urlHelper.Action(nameof(ProdutoController.Atualizar), "Produto", new { id = produto.Id })!,
                rel: "update",
                method: "PUT"
            ));

            produto.Links.Add(new LinkResource(
                href: urlHelper.Action(nameof(ProdutoController.Remover), "Produto", new { id = produto.Id })!,
                rel: "delete",
                method: "DELETE"
            ));
        }
    }
}
