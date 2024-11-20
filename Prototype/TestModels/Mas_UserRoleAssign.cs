using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_UserRoleAssign
{
    public string RoleID { get; set; } = null!;

    public string UserID { get; set; } = null!;

    public int? Active { get; set; }

    public DateTime? LastUpdate { get; set; }
}
