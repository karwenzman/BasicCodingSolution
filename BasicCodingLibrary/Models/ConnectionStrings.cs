namespace BasicCodingLibrary.Models;

public class ConnectionStrings
{
    public string Default { get; set; } = "default value";
    public string RootDirectory { get; set; } = Directory.GetCurrentDirectory();
}
