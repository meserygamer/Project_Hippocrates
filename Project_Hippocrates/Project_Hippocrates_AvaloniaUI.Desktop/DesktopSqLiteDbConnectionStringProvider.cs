using Project_Hippocrates.SQLite;

namespace Project_Hippocrates_AvaloniaUI.Desktop;

public class DesktopSqLiteDbConnectionStringProvider : ISqLiteDbConnectionStringProvider
{
    public DesktopSqLiteDbConnectionStringProvider(string dbFileName)
    {
        ConnectionString = string.Concat("Data Source=", dbFileName);
    }

    public string ConnectionString { get; }
}