namespace APIPrototype.Models
{
    public class View_Model
    {
        public class StockCardViewModel
        {
            public int TransID { get; set; }

            public string AccDocNo { get; set; } = string.Empty;

            public DateTime AccBatchDate { get; set; }

            public DateTime AccEffectiveDate { get; set; }

            public string PartyCode { get; set; } = string.Empty;

            public string? PartyTaxCode { get; set; }

            public string PartyName { get; set; } = string.Empty;

            public string PartyAddress { get; set; } = string.Empty;

            public string IssueBy { get; set; } = string.Empty;

            public string AccDocType { get; set; } = string.Empty;

            public DateTime AccPostDate { get; set; }

            public DateTime FiscalYear { get; set; }

            public int DocStatus { get; set; }

            public string WarehouseCode { get; set; } = string.Empty;

            public string StockProductCode { get; set; } = string.Empty;

            public string? UnitStock { get; set; } = string.Empty;

            public string ProductName { get; set; } = string.Empty;

            public string? ProductColor { get; set; }

            public string ProductBrand { get; set; } = string.Empty;

            public int TransQty { get; set; }

            public decimal TransPrice { get; set; }

            public string TransCurrency { get; set; } = string.Empty;

            public decimal TransRate { get; set; }

            public decimal TransAmount { get; set; }

            public int QtyIN { get; set; } 

            public int QtyOUT { get; set; } 

            public string? AccSourceDocNo { get; set; }

            public int? AccSourceDocItem { get; set; }

            public string SaleProductCode { get; set; } = string.Empty;

            public string SalesDescription { get; set; } = string.Empty;

            public string? AssetAccCode { get; set; }

            public string? AssetAccName { get; set; }

            public string? AssetAccMainCode { get; set; }

            public string? AssetAccMainName { get; set; }
        }

        public class StockOnHandViewModel
        {
            public string WarehouseCode { get; set; } = null!;

            public string StockProductCode { get; set; } = null!;

            public string? UnitStock { get; set; }

            public string ProductName { get; set; } = null!;

            public string? ProductColor { get; set; }

            public string ProductBrand { get; set; } = null!;

            public string? AssetAccCode { get; set; }

            public string? AssetAccName { get; set; }

            public string? AssetAccMainCode { get; set; }

            public string? AssetAccMainName { get; set; }

            public int? SumQty { get; set; }

            public decimal? SumAmount { get; set; }

            public decimal? AvgPrice { get; set; }

            public int? QtyIN { get; set; }

            public int? QtyOUT { get; set; }
        }

        public class JVViewModel
        {
            public int EntryId { get; set; }

            public string? JournalNo { get; set; }

            public DateTime? EntryDate { get; set; }

            public DateTime? EffectiveDate { get; set; }

            public string? EntryBy { get; set; }

            public string? Description { get; set; }

            public decimal? TotalDebit { get; set; }

            public decimal? TotalCredit { get; set; }

            public int Seq { get; set; }

            public string? AccCode { get; set; }

            public string? AccMainCode { get; set; }

            public string? AccMainCodeName { get; set; }

            public string? AccName { get; set; }

            public string? AccDesc { get; set; }

            public decimal? Debit { get; set; }

            public decimal? Credit { get; set; }
        }

        public class SumBalanceViewModel
        {
            public string? AccMainCode { get; set; }

            public string? AccMainName { get; set; }

            public decimal? Debit { get; set; }

            public decimal? Credit { get; set; }

            public string? AccType { get; set; }

            public string? AccTypeName { get; set; }
        }

        public class TrailBalanceViewModel
        {
            public int? Period { get; set; }

            public string? AccCode { get; set; }

            public string? AccName { get; set; }

            public string? AccMainCode { get; set; }

            public string? AccMainName { get; set; }

            public decimal? Dr { get; set; }

            public decimal? Cr { get; set; }
        }

        public class AccCodeViewModel
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

        public class WarehouseViewModel
        {
            public int WarehouseID { get; set; }

            public string WarehouseCode { get; set; } = null!;

            public string Name { get; set; } = null!;

            public string? Location { get; set; }

            public string? Address { get; set; }

            public string? AssetAccCode { get; set; }

            public string? AssetAccName { get; set; }

            public string? AssetAccNameEN { get; set; }

            public string? AssetAccType { get; set; }

            public string? AssetAccTypeName { get; set; }

            public string? AssetAccTypeNameEN { get; set; }

            public string? AssetAccSide { get; set; }

            public string? AssetAccMainCode { get; set; }

            public string? AssetAccMainName { get; set; }

            public string? AssetAccMainNameEN { get; set; }

            public string? IncomeAccCode { get; set; }

            public string? IncomeAccName { get; set; }

            public string? IncomeAccNameEN { get; set; }

            public string? IncomeAccType { get; set; }

            public string? IncomeAccTypeName { get; set; }

            public string? IncomeAccTypeNameEN { get; set; }

            public string? IncomeAccSide { get; set; }

            public string? IncomeAccMainCode { get; set; }

            public string? IncomeAccMainName { get; set; }

            public string? IncomeAccMainNameEN { get; set; }

            public string? ExpenseAccCode { get; set; }

            public string? ExpenseAccName { get; set; }

            public string? ExpenseAccNameEN { get; set; }

            public string? ExpenseAccType { get; set; }

            public string? ExpenseAccTypeName { get; set; }

            public string? ExpenseAccTypeNameEN { get; set; }

            public string? ExpenseAccSide { get; set; }

            public string? ExpenseAccMainCode { get; set; }

            public string? ExpenseAccMainName { get; set; }

            public string? ExpenseAccMainNameEN { get; set; }
        }

        public class ProductTypeViewModel
        {
            public int ProductTypeID { get; set; }

            public string ProductTypeCode { get; set; } = null!;

            public string ProductTypeName { get; set; } = null!;

            public int WarehouseID { get; set; }

            public string WarehouseCode { get; set; } = null!;

            public string WarehouseName { get; set; } = null!;

            public string? WarehouseLocation { get; set; }

            public string? WarehouseAddress { get; set; }

            public string? AssetAccCode { get; set; }

            public string? AssetAccName { get; set; }

            public string? AssetAccNameEN { get; set; }

            public string? AssetAccType { get; set; }

            public string? AssetAccTypeName { get; set; }

            public string? AssetAccTypeNameEN { get; set; }

            public string? AssetAccSide { get; set; }

            public string? AssetAccMainCode { get; set; }

            public string? AssetAccMainName { get; set; }

            public string? AssetAccMainNameEN { get; set; }

            public string? IncomeAccCode { get; set; }

            public string? IncomeAccName { get; set; }

            public string? IncomeAccNameEN { get; set; }

            public string? IncomeAccType { get; set; }

            public string? IncomeAccTypeName { get; set; }

            public string? IncomeAccTypeNameEN { get; set; }

            public string? IncomeAccSide { get; set; }

            public string? IncomeAccMainCode { get; set; }

            public string? IncomeAccMainName { get; set; }

            public string? IncomeAccMainNameEN { get; set; }

            public string? ExpenseAccCode { get; set; }

            public string? ExpenseAccName { get; set; }

            public string? ExpenseAccNameEN { get; set; }

            public string? ExpenseAccType { get; set; }

            public string? ExpenseAccTypeName { get; set; }

            public string? ExpenseAccTypeNameEN { get; set; }

            public string? ExpenseAccSide { get; set; }

            public string? ExpenseAccMainCode { get; set; }

            public string? ExpenseAccMainName { get; set; }

            public string? ExpenseAccMainNameEN { get; set; }

            public bool IsMaterial { get; set; }

            public bool IsService { get; set; }

            public decimal RateVat { get; set; }

            public decimal RateWht { get; set; }

            public string VatType { get; set; } = null!;
        }

        public class ProductViewModel
        {
            public int ProductID { get; set; }

            public string ProductCode { get; set; } = null!;

            public string ProductName { get; set; } = null!;

            public string ProductBrand { get; set; } = null!;

            public string? ProductColor { get; set; }

            public int? ProductSize { get; set; }

            public string? ProductSizeUnit { get; set; }

            public decimal? ProductVolume { get; set; }

            public string? ProductVolumeUnit { get; set; }

            public string? UnitStock { get; set; }

            public string ProductTypeCode { get; set; } = null!;

            public int ProductTypeID { get; set; }

            public string ProductTypeName { get; set; } = null!;

            public int WarehouseID { get; set; }

            public string WarehouseCode { get; set; } = null!;

            public string WarehouseName { get; set; } = null!;

            public string? WarehouseLocation { get; set; }

            public string? WarehouseAddress { get; set; }

            public string? AssetAccCode { get; set; }

            public string? AssetAccName { get; set; }

            public string? AssetAccNameEN { get; set; }

            public string? AssetAccType { get; set; }

            public string? AssetAccTypeName { get; set; }

            public string? AssetAccTypeNameEN { get; set; }

            public string? AssetAccSide { get; set; }

            public string? AssetAccMainCode { get; set; }

            public string? AssetAccMainName { get; set; }

            public string? AssetAccMainNameEN { get; set; }

            public string? IncomeAccCode { get; set; }

            public string? IncomeAccName { get; set; }

            public string? IncomeAccNameEN { get; set; }

            public string? IncomeAccType { get; set; }

            public string? IncomeAccTypeName { get; set; }

            public string? IncomeAccTypeNameEN { get; set; }

            public string? IncomeAccSide { get; set; }

            public string? IncomeAccMainCode { get; set; }

            public string? IncomeAccMainName { get; set; }

            public string? IncomeAccMainNameEN { get; set; }

            public string? ExpenseAccCode { get; set; }

            public string? ExpenseAccName { get; set; }

            public string? ExpenseAccNameEN { get; set; }

            public string? ExpenseAccType { get; set; }

            public string? ExpenseAccTypeName { get; set; }

            public string? ExpenseAccTypeNameEN { get; set; }

            public string? ExpenseAccSide { get; set; }

            public string? ExpenseAccMainCode { get; set; }

            public string? ExpenseAccMainName { get; set; }

            public string? ExpenseAccMainNameEN { get; set; }

            public bool IsMaterial { get; set; }

            public bool IsService { get; set; }

            public decimal RateVat { get; set; }

            public decimal RateWht { get; set; }

            public string VatType { get; set; } = null!;
        }
    }
}
