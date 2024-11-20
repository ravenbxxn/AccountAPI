using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_UserRoleAuthor
{
    public string RoleID { get; set; } = null!;

    public string ModuleID { get; set; } = null!;

    public string MenuID { get; set; } = null!;

    public string? Author { get; set; }
}
