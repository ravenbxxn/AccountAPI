using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_ModuleMenu
{
    public string ModuleID { get; set; } = null!;

    public string MenuID { get; set; } = null!;

    public string? MenuName { get; set; }

    public string? MenuNameEN { get; set; }

    public string? WebAddress { get; set; }

    public string? HeadMenuID { get; set; }

    public int? Seq { get; set; }
}
