using Project_Hippocrates.SQLite;

namespace Project_Hippocrates_AvaloniaUI.Desktop;

public class DesktopSqLiteDbConnectionStringProvider : ISqLiteDbConnectionStringProvider
{
    public DesktopSqLiteDbConnectionStringProvider(string dbFileName)
    {
        ConnectionString = dbFileName;
    }

    public string ConnectionString { get; }
}