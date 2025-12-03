using Course.FileManager.Core;
using Course.FileManager.Infrastructure;

namespace Course;

public class Program
{
    private static void Main(string[] args)
    {
        IFileService fileService = new FileService();
        IFolderService folderService = new FolderService();

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("0. Выход");
            Console.WriteLine("1. Создать текстовый файл");
            Console.WriteLine("2. Прочитать файл");
            Console.WriteLine("3. Создать папку");

            var input = Console.ReadLine();

            switch (input)
            {
                case "0": return;
                case "1":
                    CreateFile(fileService);
                    break;
                case "2":
                    ReadFile(fileService);
                    break;
                case "3":
                    CreateFolder(folderService);
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    break;
            }
        }

        static void CreateFile(IFileService fileService)
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();

            Console.WriteLine("Введите содержимое фалйа");
            string content = Console.ReadLine();

            fileService.CreateFile(path, content);
        }

        static void ReadFile(IFileService fileService)
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();
            try
            {
                string text = fileService.ReadFile(path);
                Console.WriteLine("Содержимое файла");
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        void CreateFolder(IFolderService folderService)
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();
            
            Console.WriteLine("Введите имя папки");
            string name = Console.ReadLine();

            string fullPath = Path.Combine(path, name);
            try
            {
                folderService.CreateFolder(fullPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                throw;
            }
        }
    }
}
//переместить, редактировать?, удалить, переиминовать, копировать, посмореть свойства и для папок

//сделать ввод не список возможностей и как cmd(cd, dir ...)