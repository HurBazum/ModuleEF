namespace ModuleEF
{
    public static class ConnectionString
    {
        public static readonly string MsSqlConnection = @"Data Source=.\SQLEXPRESS;Database=EF;Trusted_Connection=True;Trust Server Certificate=true;";

        public static string GetConnectionString => MsSqlConnection;
    }
}