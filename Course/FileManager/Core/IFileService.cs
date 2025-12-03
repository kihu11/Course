namespace Course.FileManager.Core;

public interface IFileService
{
    void CreateFile(string path, string content);
    string ReadFile(string path);
}