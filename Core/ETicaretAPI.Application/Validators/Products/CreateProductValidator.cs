using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator() 
        { 
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Litfen ürün adını boş bırakmayınız.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Ürün adı 2 karakterden az, 150 karakterden çok olamaz.");

            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini boş bırakmayınız.")
                .Must(s => s >= 0)
                    .WithMessage("Stok bilgisi 0'dan az olamaz.");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgisini boş bırakmayınız.")
                .Must(s => s >= 0)
                    .WithMessage("fFyat bilgisi 0'dan az olamaz.");

        }

    }
}
