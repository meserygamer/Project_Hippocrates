using System.IO;
using Project_Hippocrates.SQLite;

namespace Project_Hippocrates_AvaloniaUI.Android;

public class AndroidSqLiteDbConnectionStringProvider : ISqLiteDbConnectionStringProvider
{
    private readonly string _dbFileName;
    
    public AndroidSqLiteDbConnectionStringProvider(string dbFileName)
    {
        _dbFileName = dbFileName;
    }
    
    public string ConnectionString
    {
        get
        {
            string personalFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            return string.Concat("Data Source=", Path.Combine(personalFolderPath, _dbFileName));
        }
    }
}