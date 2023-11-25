using System;
using System.Collections.Generic;

namespace Inovi.DataAccessLayer.Models;

public partial class QueryStatus
{
    public int Id { get; set; }

    public int? QueryId { get; set; }

    public int? StatusId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual Query? Query { get; set; }

    public virtual Status? Status { get; set; }
}
