using System;
using System.Collections.Generic;

namespace Inovi.DataAccessLayer.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string? Status1 { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<QueryStatus> QueryStatuses { get; set; } = new List<QueryStatus>();
}
