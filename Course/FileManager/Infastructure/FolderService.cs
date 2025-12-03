using Course.FileManager.Core;

namespace Course.FileManager.Infrastructure;

public class FolderService : IFolderService
{
    public void CreateFolder(string path)
    {
        if (path == null) throw new ArgumentNullException("Пустой путь");
        Directory.CreateDirectory(path);
    }
}