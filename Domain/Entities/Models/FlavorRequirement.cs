using System;
using System.Collections.Generic;

namespace Domain.Entities.Models;

public partial class FlavorRequirement
{
    public int FlavorRequirementId { get; set; }

    public string FlavorRequirementName { get; set; } = null!;

    public bool? IsDeleted { get; set; }
}
