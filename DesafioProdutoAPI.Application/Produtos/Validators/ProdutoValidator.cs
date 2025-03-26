using FluentValidation;
using DesafioProdutoAPI.Application.DTOs;

namespace DesafioProdutoAPI.Application.Validators;

public class ProdutoValidator : AbstractValidator<ProdutoDTO>
{
    public ProdutoValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres");

        RuleFor(p => p.Categoria)
            .NotEmpty().WithMessage("A categoria é obrigatória")
            .MaximumLength(50).WithMessage("Máximo 50 caracteres");

        RuleFor(p => p.Preco)
            .GreaterThan(0).WithMessage("O preço deve ser maior que 0");

        RuleFor(p => p.QuantidadeEmEstoque)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser negativa");
    }
}