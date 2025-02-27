using System;
using System.Collections.Generic;

namespace PAW.Data.Models;

public partial class OfficeRequestDetail
{
    public int DetailId { get; set; }

    public int RequestId { get; set; }

    public string DetailType { get; set; } = null!;

    public string DetailText { get; set; } = null!;

    public string AddedBy { get; set; } = null!;

    public DateTime? AddedDate { get; set; }
}
