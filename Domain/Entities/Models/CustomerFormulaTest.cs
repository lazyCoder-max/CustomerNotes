using System;
using System.Collections.Generic;

namespace Domain.Entities.Models;

public partial class CustomerFormulaTest
{
    public int CustomerNumber { get; set; }

    public string FormulaName { get; set; } = null!;

    public string TestNumber { get; set; } = null!;

    public virtual Customer CustomerNumberNavigation { get; set; } = null!;
}
