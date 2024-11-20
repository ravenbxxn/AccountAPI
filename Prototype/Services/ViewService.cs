using APIPrototype.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static APIPrototype.Models.View_Model;

namespace APIPrototype.Services
{
    public class ViewService
    {
        private readonly AppDbContext _db;

        public ViewService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<StockCardViewModel>> GetStockCardsAsync()
        {
            var query = @"SELECT a.TransID, d.AccDocNo, d.AccBatchDate, d.AccEffectiveDate, d.PartyCode, 
                             d.PartyTaxCode, d.PartyName, d.PartyAddress, d.IssueBy, d.AccDocType, d.AccPostDate, 
                             d.FiscalYear, d.DocStatus, a.WarehouseCode, a.StockProductCode, b.UnitStock, b.ProductName, 
                             b.ProductColor, b.ProductBrand, a.TransQty, a.TransPrice, a.TransCurrency, a.TransRate, 
                             a.TransQty * a.TransPrice * a.TransRate AS TransAmount, 
                             CASE WHEN a.TransType IN ('IN', 'TI') THEN a.TransQty ELSE 0 END AS QtyIN, 
                             CASE WHEN a.TransType IN ('OUT', 'TO') THEN Abs(a.TransQty) ELSE 0 END AS QtyOUT, 
                             c.AccSourceDocNo, c.AccSourceDocItem, c.SaleProductCode, c.SalesDescription, 
                             b.AssetAccCode, b.AssetAccName, b.AssetAccMainCode, b.AssetAccMainName
                      FROM dbo.Acc_StockTransaction AS a
                      INNER JOIN dbo.vMas_Product AS b ON a.StockProductCode = b.ProductCode
                      INNER JOIN dbo.Acc_TransactionDT AS c ON a.TransID = c.StockTransNo
                      INNER JOIN dbo.Acc_TransactionHD AS d ON c.AccDocNo = d.AccDocNo";

            return await _db.StockCardView.FromSqlRaw(query).ToListAsync();
        }

        public async Task<List<StockOnHandViewModel>> GetStockOnHandsAsync()
        {
            var query = @"SELECT 
                        a.WarehouseCode, 
                        a.StockProductCode, 
                        b.UnitStock, 
                        b.ProductName, 
                        b.ProductColor, 
                        b.ProductBrand, 
                        b.AssetAccCode, 
                        b.AssetAccName, 
                        b.AssetAccMainCode, 
                        b.AssetAccMainName, 
                        SUM(a.TransQty) AS SumQty, 
                        CAST(SUM(a.TransQty * a.TransPrice * a.TransRate) AS decimal(18, 2)) AS SumAmount, 
                        CAST(SUM(a.TransQty * a.TransPrice * a.TransRate) AS decimal(18, 2)) / NULLIF(SUM(a.TransQty), 0) AS AvgPrice, 
                        SUM(CASE WHEN a.TransType IN ('IN', 'TI') THEN a.TransQty ELSE 0 END) AS QtyIN, 
                        SUM(CASE WHEN a.TransType IN ('OUT', 'TO') THEN ABS(a.TransQty) ELSE 0 END) AS QtyOUT
                    FROM 
                        dbo.Acc_StockTransaction AS a 
                    INNER JOIN 
                        dbo.vMas_Product AS b ON a.StockProductCode = b.ProductCode
                    GROUP BY 
                        a.WarehouseCode, a.StockProductCode, b.UnitStock, b.ProductName, b.ProductColor, 
                        b.ProductBrand, b.AssetAccCode, b.AssetAccName, b.AssetAccMainCode, b.AssetAccMainName";

            return await _db.StockOnHandView.FromSqlRaw(query).ToListAsync();
        }

        public async Task<List<JVViewModel>> GetJVsAsync(string? JournalNo = null)
        {
            var query = @"SELECT a.EntryId, a.JournalNo, a.EntryDate, a.EffectiveDate, a.EntryBy, a.Description, a.TotalDebit, a.TotalCredit,
                                 b.Seq, b.AccCode, c.AccMainCode, d.AccName AS AccMainCodeName, b.AccName, b.AccDesc, b.Debit, b.Credit
                        FROM     
                                 dbo.Acc_JournalHD AS a INNER JOIN
                                 dbo.Acc_JournalDT AS b ON a.EntryId = b.EntryId INNER JOIN
                                 dbo.Mas_AccCode AS c ON b.AccCode = c.AccCode INNER JOIN
                                 dbo.Mas_AccCode AS d ON c.AccMainCode = d.AccCode
                        WHERE 
                                (@JournalNo IS NULL OR a.JournalNo = @JournalNo)";
            var journalNoParameter = new SqlParameter("@JournalNo", (object)JournalNo ?? DBNull.Value);

            return await _db.JVView.FromSqlRaw(query, journalNoParameter).ToListAsync();
        }

        public async Task<List<SumBalanceViewModel>> GetSumBalancesAsync(string? accMainCode = null, string? accMainName = null)
        {
            var query = @"SELECT 
                          dbo.vTrial_Balance.AccMainCode, 
                          dbo.vTrial_Balance.AccMainName, 
                          SUM(dbo.vTrial_Balance.Dr) AS Debit, 
                          SUM(dbo.vTrial_Balance.Cr) AS Credit, 
                          dbo.vMas_AccCode.AccType, 
                          dbo.vMas_AccCode.AccTypeName
                      FROM 
                          dbo.vTrial_Balance 
                      INNER JOIN 
                          dbo.vMas_AccCode ON dbo.vTrial_Balance.AccMainCode = dbo.vMas_AccCode.AccCode
                      WHERE 
                          (@AccMainCode IS NULL OR dbo.vTrial_Balance.AccMainCode = @AccMainCode) AND 
                          (@AccMainName IS NULL OR dbo.vTrial_Balance.AccMainName LIKE '%' + @AccMainName + '%')
                      GROUP BY 
                          dbo.vTrial_Balance.AccMainCode, 
                          dbo.vTrial_Balance.AccMainName, 
                          dbo.vMas_AccCode.AccType, 
                          dbo.vMas_AccCode.AccTypeName
                      ORDER BY 
                          dbo.vTrial_Balance.AccMainCode";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@AccMainCode", (object)accMainCode ?? DBNull.Value),
                new SqlParameter("@AccMainName", (object)accMainName ?? DBNull.Value),
            };

            return await _db.SumBalanceView.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
        }

        public async Task<List<TrailBalanceViewModel>> GetTrailBalancesAsync(string? accCode = null, string? accMainCode = null)
        {
            var query = @"SELECT 
                            YEAR(a.EffectiveDate) AS Period, 
                            c.AccCode, 
                            c.AccName, 
                            c.AccMainCode, 
                            d.AccName AS AccMainName, 
                            SUM(b.Debit) AS Dr, 
                            SUM(b.Credit) AS Cr
                        FROM     
                            dbo.Acc_JournalHD AS a 
                        INNER JOIN
                            dbo.Acc_JournalDT AS b ON a.EntryId = b.EntryId 
                        LEFT OUTER JOIN
                            dbo.Mas_AccCode AS c ON b.AccCode = c.AccCode 
                        LEFT OUTER JOIN
                            dbo.Mas_AccCode AS d ON c.AccMainCode = d.AccCode
                        WHERE 
                            (@AccCode IS NULL OR c.AccCode = @AccCode) AND 
                            (@AccMainCode IS NULL OR c.AccMainCode = @AccMainCode)
                        GROUP BY 
                            YEAR(a.EffectiveDate), 
                            c.AccCode, 
                            c.AccName, 
                            c.AccMainCode, 
                            d.AccName";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@AccCode", (object)accCode ?? DBNull.Value),
                new SqlParameter("@AccMainCode", (object)accMainCode ?? DBNull.Value),
            };

            return await _db.TrailBalanceView.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
        }

        public async Task<List<AccCodeViewModel>> GetAccCodesAsync(string? accCode = null, string? accMainCode = null, string? accTypeName = null)
        {
            var query = @"SELECT    
                                dbo.Mas_AccCode.AccCode, dbo.Mas_AccCode.AccName, dbo.Mas_AccCode.AccNameEN, dbo.Mas_AccCode.AccTypeID,
                                dbo.Mas_AccType.AccType, dbo.Mas_AccType.AccTypeName, dbo.Mas_AccType.AccTypeNameEN, dbo.Mas_AccType.AccSide,
                                dbo.Mas_AccCode.AccMainCode, Mas_AccCode_1.AccName AS AccMainName, Mas_AccCode_1.AccNameEN AS AccMainNameEN
                         FROM            
                                dbo.Mas_AccType INNER JOIN
                                dbo.Mas_AccCode ON dbo.Mas_AccType.AccTypeID = dbo.Mas_AccCode.AccTypeID LEFT OUTER JOIN
                                dbo.Mas_AccCode AS Mas_AccCode_1 ON dbo.Mas_AccCode.AccMainCode = Mas_AccCode_1.AccCode
                        WHERE 
                                (@AccCode IS NULL OR dbo.Mas_AccCode.AccCode = @AccCode) AND 
                                (@AccMainCode IS NULL OR dbo.Mas_AccCode.AccMainCode = @AccMainCode) AND 
                                (@AccTypeName IS NULL OR dbo.Mas_AccType.AccTypeName LIKE '%' + @AccTypeName + '%')";                                

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@AccCode", (object)accCode ?? DBNull.Value),
                new SqlParameter("@AccMainCode", (object)accMainCode ?? DBNull.Value),
                new SqlParameter("@AccTypeName", (object)accTypeName ?? DBNull.Value),
            };

            return await _db.AccCodeView.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
        }

        public async Task<List<WarehouseViewModel>> GetWarehousesAsync()
        {
            var query = @"SELECT     
                                     dbo.Mas_Warehouse.WarehouseID, dbo.Mas_Warehouse.WarehouseCode, dbo.Mas_Warehouse.Name, dbo.Mas_Warehouse.Location, dbo.Mas_Warehouse.Address, dbo.Mas_Warehouse.AssetAccCode, 
                                     dbo.vMas_AccCode.AccName AS AssetAccName, dbo.vMas_AccCode.AccNameEN AS AssetAccNameEN, dbo.vMas_AccCode.AccType AS AssetAccType, dbo.vMas_AccCode.AccTypeName AS AssetAccTypeName, 
                                     dbo.vMas_AccCode.AccTypeNameEN AS AssetAccTypeNameEN, dbo.vMas_AccCode.AccSide AS AssetAccSide, dbo.vMas_AccCode.AccMainCode AS AssetAccMainCode, 
                                     dbo.vMas_AccCode.AccMainName AS AssetAccMainName, dbo.vMas_AccCode.AccMainNameEN AS AssetAccMainNameEN, dbo.Mas_Warehouse.IncomeAccCode, vMas_AccCode_1.AccName AS IncomeAccName, 
                                     vMas_AccCode_1.AccNameEN AS IncomeAccNameEN, vMas_AccCode_1.AccType AS IncomeAccType, vMas_AccCode_1.AccTypeName AS IncomeAccTypeName, vMas_AccCode_1.AccTypeNameEN AS IncomeAccTypeNameEN, 
                                     vMas_AccCode_1.AccSide AS IncomeAccSide, vMas_AccCode_1.AccMainCode AS IncomeAccMainCode, vMas_AccCode_1.AccMainName AS IncomeAccMainName, vMas_AccCode_1.AccMainNameEN AS IncomeAccMainNameEN,
                                      dbo.Mas_Warehouse.ExpenseAccCode, vMas_AccCode_2.AccName AS ExpenseAccName, vMas_AccCode_2.AccNameEN AS ExpenseAccNameEN, vMas_AccCode_2.AccType AS ExpenseAccType, 
                                     vMas_AccCode_2.AccTypeName AS ExpenseAccTypeName, vMas_AccCode_2.AccTypeNameEN AS ExpenseAccTypeNameEN, vMas_AccCode_2.AccSide AS ExpenseAccSide, 
                                     vMas_AccCode_2.AccMainCode AS ExpenseAccMainCode, vMas_AccCode_2.AccMainName AS ExpenseAccMainName, vMas_AccCode_2.AccMainNameEN AS ExpenseAccMainNameEN
                        FROM         
                                     dbo.Mas_Warehouse LEFT OUTER JOIN
                                     dbo.vMas_AccCode AS vMas_AccCode_2 ON dbo.Mas_Warehouse.ExpenseAccCode = vMas_AccCode_2.AccCode LEFT OUTER JOIN
                                     dbo.vMas_AccCode AS vMas_AccCode_1 ON dbo.Mas_Warehouse.IncomeAccCode = vMas_AccCode_1.AccCode LEFT OUTER JOIN
                                     dbo.vMas_AccCode ON dbo.Mas_Warehouse.AssetAccCode = dbo.vMas_AccCode.AccCode";


            return await _db.WarehouseView.FromSqlRaw(query).ToListAsync();
        }

        public async Task<List<ProductTypeViewModel>> GetProductTypesAsync()
        {
            var query = @"SELECT     
                                     dbo.Mas_ProductType.ProductTypeID, dbo.Mas_ProductType.ProductTypeCode, dbo.Mas_ProductType.ProductTypeName, dbo.vMas_Warehouse.WarehouseID, dbo.vMas_Warehouse.WarehouseCode, 
                                     dbo.vMas_Warehouse.Name AS WarehouseName, dbo.vMas_Warehouse.Location AS WarehouseLocation, dbo.vMas_Warehouse.Address AS WarehouseAddress, dbo.vMas_Warehouse.AssetAccCode, 
                                     dbo.vMas_Warehouse.AssetAccName, dbo.vMas_Warehouse.AssetAccNameEN, dbo.vMas_Warehouse.AssetAccType, dbo.vMas_Warehouse.AssetAccTypeName, dbo.vMas_Warehouse.AssetAccTypeNameEN, 
                                     dbo.vMas_Warehouse.AssetAccSide, dbo.vMas_Warehouse.AssetAccMainCode, dbo.vMas_Warehouse.AssetAccMainName, dbo.vMas_Warehouse.AssetAccMainNameEN, dbo.vMas_Warehouse.IncomeAccCode, 
                                     dbo.vMas_Warehouse.IncomeAccName, dbo.vMas_Warehouse.IncomeAccNameEN, dbo.vMas_Warehouse.IncomeAccType, dbo.vMas_Warehouse.IncomeAccTypeName, dbo.vMas_Warehouse.IncomeAccTypeNameEN, 
                                     dbo.vMas_Warehouse.IncomeAccSide, dbo.vMas_Warehouse.IncomeAccMainCode, dbo.vMas_Warehouse.IncomeAccMainName, dbo.vMas_Warehouse.IncomeAccMainNameEN, dbo.vMas_Warehouse.ExpenseAccCode, 
                                     dbo.vMas_Warehouse.ExpenseAccName, dbo.vMas_Warehouse.ExpenseAccNameEN, dbo.vMas_Warehouse.ExpenseAccType, dbo.vMas_Warehouse.ExpenseAccTypeName, dbo.vMas_Warehouse.ExpenseAccTypeNameEN,
                                     dbo.vMas_Warehouse.ExpenseAccSide, dbo.vMas_Warehouse.ExpenseAccMainCode, dbo.vMas_Warehouse.ExpenseAccMainName, dbo.vMas_Warehouse.ExpenseAccMainNameEN, dbo.Mas_ProductType.IsMaterial, 
                                     dbo.Mas_ProductType.IsService, dbo.Mas_ProductType.RateVat, dbo.Mas_ProductType.RateWht, dbo.Mas_ProductType.VatType
                        FROM               
                                     dbo.vMas_Warehouse INNER JOIN
                                     dbo.Mas_ProductType ON dbo.vMas_Warehouse.WarehouseCode = dbo.Mas_ProductType.WarehouseCode";


            return await _db.ProductTypeView.FromSqlRaw(query).ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            var query = @"SELECT        
                                 dbo.Mas_Products.ProductID, dbo.Mas_Products.ProductCode, dbo.Mas_Products.ProductName, dbo.Mas_Products.Brand AS ProductBrand, dbo.Mas_Products.Color AS ProductColor, dbo.Mas_Products.Size AS ProductSize, 
                                 dbo.Mas_Products.SizeUnit AS ProductSizeUnit, dbo.Mas_Products.Volume AS ProductVolume, dbo.Mas_Products.VolumeUnit AS ProductVolumeUnit, dbo.Mas_Products.UnitStock, dbo.Mas_Products.ProductTypeCode, 
                                 dbo.vMas_ProductType.ProductTypeID, dbo.vMas_ProductType.ProductTypeName, dbo.vMas_ProductType.WarehouseID, dbo.vMas_ProductType.WarehouseCode, dbo.vMas_ProductType.WarehouseName, 
                                 dbo.vMas_ProductType.WarehouseLocation, dbo.vMas_ProductType.WarehouseAddress, dbo.vMas_ProductType.AssetAccCode, dbo.vMas_ProductType.AssetAccName, dbo.vMas_ProductType.AssetAccNameEN, 
                                 dbo.vMas_ProductType.AssetAccType, dbo.vMas_ProductType.AssetAccTypeName, dbo.vMas_ProductType.AssetAccTypeNameEN, dbo.vMas_ProductType.AssetAccSide, dbo.vMas_ProductType.AssetAccMainCode, 
                                 dbo.vMas_ProductType.AssetAccMainName, dbo.vMas_ProductType.AssetAccMainNameEN, dbo.vMas_ProductType.IncomeAccCode, dbo.vMas_ProductType.IncomeAccName, dbo.vMas_ProductType.IncomeAccNameEN, 
                                 dbo.vMas_ProductType.IncomeAccType, dbo.vMas_ProductType.IncomeAccTypeName, dbo.vMas_ProductType.IncomeAccTypeNameEN, dbo.vMas_ProductType.IncomeAccSide, dbo.vMas_ProductType.IncomeAccMainCode, 
                                 dbo.vMas_ProductType.IncomeAccMainName, dbo.vMas_ProductType.IncomeAccMainNameEN, dbo.vMas_ProductType.ExpenseAccCode, dbo.vMas_ProductType.ExpenseAccName, 
                                 dbo.vMas_ProductType.ExpenseAccNameEN, dbo.vMas_ProductType.ExpenseAccType, dbo.vMas_ProductType.ExpenseAccTypeName, dbo.vMas_ProductType.ExpenseAccTypeNameEN, 
                                 dbo.vMas_ProductType.ExpenseAccSide, dbo.vMas_ProductType.ExpenseAccMainCode, dbo.vMas_ProductType.ExpenseAccMainName, dbo.vMas_ProductType.ExpenseAccMainNameEN, dbo.vMas_ProductType.IsMaterial, 
                                 dbo.vMas_ProductType.IsService, dbo.vMas_ProductType.RateVat, dbo.vMas_ProductType.RateWht, dbo.vMas_ProductType.VatType
                        FROM            
                                 dbo.Mas_Products INNER JOIN
                                 dbo.vMas_ProductType ON dbo.Mas_Products.ProductTypeCode = dbo.vMas_ProductType.ProductTypeCode";

            return await _db.ProductView.FromSqlRaw(query).ToListAsync();
        }

    }

}
