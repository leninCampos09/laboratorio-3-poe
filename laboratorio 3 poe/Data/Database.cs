using Microsoft.Data.SqlClient;
using RepoDb;

namespace laboratorio_3_poe.Data;

public static class Database
{
    private static readonly string ConnectionString = Environment.GetEnvironmentVariable("VENTAS_CONNECTION_STRING")
        ?? "Data Source=LENINCAMPOS09;Initial Catalog=ElectronicaVentas;Integrated Security=True;Trust Server Certificate=True";

    private static readonly object InitializationLock = new();
    private static bool _initialized;

    public static SqlConnection OpenConnection()
    {
        EnsureInitialized();
        var connection = new SqlConnection(ConnectionString);
        connection.Open();
        return connection;
    }

    private static void EnsureInitialized()
    {
        if (_initialized) return;
        lock (InitializationLock)
        {
            if (_initialized) return;
            GlobalConfiguration.Setup().UseSqlServer();
            _initialized = true;
        }
    }
}
