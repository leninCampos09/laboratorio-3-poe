using laboratorio_3_poe.Models;
using RepoDb;

namespace laboratorio_3_poe.Data;

public sealed class SalesRepository
{
    public IReadOnlyList<SalesReportRow> GetSalesReport(DateTime startDate, DateTime endDate)
    {
        if (startDate.Date > endDate.Date)
            throw new ArgumentException("La fecha inicial no puede ser posterior a la fecha final.");

        const string sql = """
            SELECT p.ProductId, p.Name AS Product,
                   SUM(sd.Quantity) AS UnitsSold,
                   SUM(sd.Quantity * sd.UnitPrice) AS TotalAmount
            FROM dbo.SaleDetails AS sd
            INNER JOIN dbo.Products AS p ON p.ProductId = sd.ProductId
            INNER JOIN dbo.Sales AS s ON s.SaleId = sd.SaleId
            WHERE s.SoldAt >= @StartDate AND s.SoldAt < @EndDateExclusive
            GROUP BY p.ProductId, p.Name
            ORDER BY p.Name;
            """;
        using var connection = Database.OpenConnection();
        return connection.ExecuteQuery<SalesReportRow>(sql, new
        {
            StartDate = startDate.Date,
            EndDateExclusive = endDate.Date.AddDays(1)
        }).ToList();
    }

    public void RegisterSale(int employeeId, int productId, int quantity)
    {
        using var connection = Database.OpenConnection();
        using var transaction = connection.BeginTransaction();
        try
        {
            var product = connection.Query<Product>(new { ProductId = productId }, transaction: transaction).FirstOrDefault()
                ?? throw new InvalidOperationException("El producto seleccionado ya no existe.");
            if (quantity <= 0 || product.Stock < quantity)
                throw new InvalidOperationException("No hay existencias suficientes para completar la venta.");

            var affectedRows = connection.ExecuteNonQuery(
                "UPDATE dbo.Products SET Stock = Stock - @Quantity WHERE ProductId = @ProductId AND Stock >= @Quantity;",
                new { ProductId = productId, Quantity = quantity },
                transaction: transaction);
            if (affectedRows == 0)
                throw new InvalidOperationException("No hay existencias suficientes para completar la venta.");

            var saleId = Convert.ToInt32(connection.Insert(new Sale
            {
                EmployeeId = employeeId,
                SoldAt = DateTime.Now
            }, transaction: transaction));

            connection.Insert(new SaleDetail
            {
                SaleId = saleId,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = product.Price
            }, transaction: transaction);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
