using System;
using System.Collections.Generic;

namespace Inovi.DataAccessLayer.Models;

public partial class User
{
    public int UserId { get; set; }

    public int? UserRoleId { get; set; }

    public string? FName { get; set; }

    public string? LName { get; set; }

    public string? EmailAddress { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Query> Queries { get; set; } = new List<Query>();

    public virtual UserRole? UserRole { get; set; }
}
