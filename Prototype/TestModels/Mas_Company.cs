using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_Company
{
    public int CompanyId { get; set; }

    public string? CompanyTaxId { get; set; }

    public string? CompanyTaxBranch { get; set; }

    public string? CompanyName { get; set; }

    public string? CompanyNameEN { get; set; }

    public int? HeadCompanyId { get; set; }

    public string? CountryCode { get; set; }
}
