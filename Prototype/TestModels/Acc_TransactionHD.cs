using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Acc_TransactionHD
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
}
