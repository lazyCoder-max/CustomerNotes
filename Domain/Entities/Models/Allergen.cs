using System;
using System.Collections.Generic;

namespace Domain.Entities.Models;

public partial class Allergen
{
    public int AllergenId { get; set; }

    public string AllergenName { get; set; } = null!;

    public bool? IsDeleted { get; set; }
}
