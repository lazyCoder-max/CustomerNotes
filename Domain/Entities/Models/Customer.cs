using System;
using System.Collections.Generic;

namespace Domain.Entities.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int CustomerNumber { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string SearchKey { get; set; } = null!;

    public int? CustomerGroup { get; set; }

    public int? Territory { get; set; }

    public string? Salesperson { get; set; }

    public string? CustomerRank { get; set; }

    public string? CSR { get; set; }

    public string? CustomerStatus { get; set; }

    public bool? IsMicroRequired { get; set; }

    public bool? IsKosherRequired { get; set; }

    public bool? IsHallalRequired { get; set; }

    public bool? IsOrganicCompRequired { get; set; }

    public bool? IsOrganicCertRequired { get; set; }

    public bool? IsAllergenRequired { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsMicroAnnual { get; set; }

    public virtual ICollection<CustomerFormulaTest> CustomerFormulaTests { get; } = new List<CustomerFormulaTest>();

    public virtual ICollection<CustomerFormula> CustomerFormulas { get; } = new List<CustomerFormula>();
}
