using System;
using System.Collections.Generic;

namespace Inovi.DataAccessLayer.Models;

public partial class Query
{
    public int QueryId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? UserId { get; set; }

    public string? AttachmentLink { get; set; }

    public string? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public string? Remarks { get; set; }

    public DateTime? RemarksOn { get; set; }

    public int? RemarksBy { get; set; }

    public virtual ICollection<QueryStatus> QueryStatuses { get; set; } = new List<QueryStatus>();

    public virtual User? User { get; set; }
}
