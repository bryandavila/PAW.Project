using System;
using System.Collections.Generic;

namespace PAW.Data.Models;

public partial class OfficeRequest
{
    public int Id { get; set; }

    public string RequestType { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string RequesterName { get; set; } = null!;

    public string RequesterEmail { get; set; } = null!;

    public string? Priority { get; set; }

    public string? Status { get; set; }

    public string? AssignedTo { get; set; }

    public DateOnly? RequestDate { get; set; }

    public DateOnly? CompletionDate { get; set; }
}
