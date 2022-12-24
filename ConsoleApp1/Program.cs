using Microsoft.Data.SqlClient;

try
{
    SqlConnectionStringBuilder builder = new()
    {
        DataSource = "localhost",
        UserID = "sa",
        Password = "testpassword0?",
        InitialCatalog = "mylocaldbproject01",
        Encrypt = false
    };

    using SqlConnection connection = new(builder.ConnectionString);

    String sql = "SELECT * FROM  [mylocaldbproject01].[dbo].[mylocaltable01]";

    using SqlCommand command = new(sql, connection);
    connection.Open();
    using SqlDataReader reader = command.ExecuteReader();
    Console.WriteLine("ID\tName");
    while (reader.Read())
    {
        Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}");
    }
}
catch (SqlException e)
{
    Console.WriteLine(e.ToString());
}
Console.ReadLine();
