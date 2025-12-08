using Course.FileManager.Core;
using Course.FileManager.Infrastructure;

namespace Course;

public class Program
{
    private static string currentDir = Directory.GetCurrentDirectory();

    private static void Main()
    {
        IFileService fileService = new FileService();
        IFolderService folderService = new FolderService();

        while(true)
        {
            Console.Write($"{currentDir}> ");
            string input = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input)) continue;

            string[] parts = input.Split(' ', 2);
            string command = parts[0].ToLower();
            string args = parts.Length > 1 ? parts[1] : "";

            try
            {
                switch(command)
                {
                    case "cd":
                        ChangeDirectory(args);
                        break;
                    case "dir":
                        ListDirectory(folderService, fileService);
                        break;
                    case "md":
                    case "mkdir":
                        folderService.CreateFolder(Path.Combine(currentDir, args));
                        break;
                    case "rd":
                    case "rmdir":
                        folderService.DeleteFolder(Path.Combine(currentDir, args));
                        break;
                    case "del":
                    case "erase":
                        fileService.DeleteFile(Path.Combine(currentDir, args));
                        break;
                    case "copy":
                        {
                            string[] argParts = args.Split(' ');
                            fileService.CopyFile(Path.Combine(currentDir, argParts[0]), Path.Combine(currentDir, argParts[1]));
                        }
                        break;
                    case "move":
                        {
                            string[] argParts = args.Split(' ');
                            fileService.MoveFile(Path.Combine(currentDir, argParts[0]), Path.Combine(currentDir, argParts[1]));
                        }
                        break;
                    case "ren":
                    case "rename":
                        {
                            string[] argParts = args.Split(' ');
                            fileService.RenameFile(Path.Combine(currentDir, argParts[0]), argParts[1]);
                        }
                        break;
                    case "type":
                        Console.WriteLine(fileService.ReadFile(Path.Combine(currentDir, args)));
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Команда не найдена");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static void ChangeDirectory(string path)
    {
        string newDir = Path.IsPathRooted(path) ? path : Path.Combine(currentDir, path);
        if(Directory.Exists(newDir))
            currentDir = Path.GetFullPath(newDir);
        else
            Console.WriteLine("Путь не найден");
    }

    private static void ListDirectory(IFolderService folderService, IFileService fileService)
    {
        foreach(var dir in folderService.GetDirectories(currentDir))
            Console.WriteLine($"<DIR> {Path.GetFileName(dir)}");
        foreach(var file in folderService.GetFiles(currentDir))
            Console.WriteLine(Path.GetFileName(file));
    }
}
