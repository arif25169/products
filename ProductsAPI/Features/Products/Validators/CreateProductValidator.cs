using FluentValidation;
using ProductsAPI.Features.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAPI.Features.Products.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().OverridePropertyName("name");
            RuleFor(x => x.ProductNumber).NotEmpty().OverridePropertyName("productNumber");
            RuleFor(x => Convert.ToInt64(x.SafetyStockLevel)).GreaterThan(0).OverridePropertyName("safetyStockLevel");
            RuleFor(x => Convert.ToInt64(x.ReorderPoint)).GreaterThan(0).OverridePropertyName("reorderPoint"); ;
            RuleFor(x => x.StandardCost).GreaterThanOrEqualTo(0).OverridePropertyName("standardCost");
            RuleFor(x => x.ListPrice).GreaterThanOrEqualTo(0).OverridePropertyName("listPrice");
            RuleFor(x => x.SellStartDate).NotEmpty().OverridePropertyName("sellStartDate");
        }
    }
}