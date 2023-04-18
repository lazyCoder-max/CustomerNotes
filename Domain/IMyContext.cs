using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public interface IMyContext
    {
        DbSet<Allergen> Allergens { get; set; }
        DbSet<CustomerFormula> CustomerFormulas { get; set; }
        DbSet<CustomerFormulaTest> CustomerFormulaTests { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<FlavorRequirement> FlavorRequirements { get; set; }
        DbSet<Formula> Formulas { get; set; }
        DbSet<MicroChemistry> MicroChemistries { get; set; }
    }
}