using System;
using System.Collections.Generic;

namespace Domain.Entities.Models;

public partial class Formula
{
    public int FormulaId { get; set; }

    public string FormulaName { get; set; } = null!;

    public string SearchKey { get; set; } = null!;

    public string? FormulaDescription { get; set; }

    public bool? IsDeleted { get; set; }
}
