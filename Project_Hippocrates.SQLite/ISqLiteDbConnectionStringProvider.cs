namespace Project_Hippocrates.SQLite;

public interface ISqLiteDbConnectionStringProvider
{
    string ConnectionString { get; }
}