using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_Promotion
{
    public int PromoCodeID { get; set; }

    public string PromoCode { get; set; } = null!;

    public string PromoName { get; set; } = null!;

    public decimal PercentDiscountRate { get; set; }

    public decimal DiscountCash { get; set; }

    public string? ExpenseAccCode { get; set; }
}
