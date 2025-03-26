namespace DesafioProdutoAPI.HATEOAS
{
    public class LinkResource
    {
        public string Href { get; set; } = string.Empty;  // URL
        public string Rel { get; set; } = string.Empty;   // "self", "update", "delete", etc.
        public string Method { get; set; } = string.Empty; // "GET", "POST", "PUT", "DELETE", etc.

        public LinkResource(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
