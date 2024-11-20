using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_SalesProductHD
{
    public int SalesProductIDHD { get; set; }

    public string SalesProductCode { get; set; } = null!;

    public string SalesProductName { get; set; } = null!;

    public DateTime BeginSalesDate { get; set; }

    public DateTime EndSalesDate { get; set; }
}
