using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vPR_All
{
    public string AccDocNo { get; set; } = null!;

    public DateTime AccBatchDate { get; set; }

    public DateTime AccEffectiveDate { get; set; }

    public string PartyCode { get; set; } = null!;

    public string? PartyTaxCode { get; set; }

    public string PartyName { get; set; } = null!;

    public string PartyAddress { get; set; } = null!;

    public string IssueBy { get; set; } = null!;

    public string AccDocType { get; set; } = null!;

    public DateTime AccPostDate { get; set; }

    public DateTime FiscalYear { get; set; }

    public int DocStatus { get; set; }

    public string? DocRefNo { get; set; }

    public int AccItemNo { get; set; }

    public string? AccSourceDocNo { get; set; }

    public int? AccSourceDocItem { get; set; }

    public int StockTransNo { get; set; }

    public int Qty { get; set; }

    public double Price { get; set; }

    public string UnitMea { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public double ExchangeRate { get; set; }

    public double Amount { get; set; }

    public string SaleProductCode { get; set; } = null!;

    public string SalesDescription { get; set; } = null!;
}
