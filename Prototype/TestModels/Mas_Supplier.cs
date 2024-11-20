using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_Supplier
{
    public int SupplierID { get; set; }

    public string SupplierCode { get; set; } = null!;

    public string TaxNumber { get; set; } = null!;

    public string TaxBranch { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string? SupplierEName { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? EAddress1 { get; set; }

    public string? EAddress2 { get; set; }

    public string? Phone { get; set; }

    public string? FaxNumber { get; set; }

    public string? Email { get; set; }

    public string? Contact { get; set; }

    public string? WebLink { get; set; }

    public string? CountryCode { get; set; }

    public string? ZIPCode { get; set; }

    public string? GLAccountCode { get; set; }
}
