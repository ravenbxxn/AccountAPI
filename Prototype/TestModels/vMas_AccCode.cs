using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vMas_AccCode
{
    public string AccCode { get; set; } = null!;

    public string? AccName { get; set; }

    public string? AccNameEN { get; set; }

    public int? AccTypeID { get; set; }

    public string? AccType { get; set; }

    public string? AccTypeName { get; set; }

    public string? AccTypeNameEN { get; set; }

    public string? AccSide { get; set; }

    public string? AccMainCode { get; set; }

    public string? AccMainName { get; set; }

    public string? AccMainNameEN { get; set; }
}
