using System;
using System.Collections.Generic;

namespace Inovi.DataAccessLayer.Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string? Role { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
