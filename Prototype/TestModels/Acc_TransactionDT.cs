using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Acc_TransactionDT
{
    public string AccDocNo { get; set; } = null!;

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
