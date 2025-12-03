using Course.FileManager.Core;

namespace Course.FileManager.Infrastructure;

public class FileService : IFileService
{
    public void CreateFile(string path, string content)
    {
        if (path == null) throw new ArgumentNullException("Пустой путь");
        File.WriteAllText(path, content);
    }

    public string ReadFile(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException("File not found");
        return File.ReadAllText(path);
    }
}