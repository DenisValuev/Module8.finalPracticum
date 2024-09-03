using System;
using System.IO;

namespace Module8.Task1
{

    internal class Program
    {
        const string path = "D:\\Module8Task1";
        public static void GetFoldersAndDelete(string _path)
        {
            string[] dirs = Directory.GetDirectories(_path);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                Console.WriteLine($"Время последнего изменения: {directoryInfo.LastWriteTime}");
                TimeSpan interval = DateTime.Now.Subtract(directoryInfo.LastWriteTime);
                if ((int)interval.TotalMinutes > 30)
                {
                    Console.WriteLine($"Папка: *{directoryInfo.Name}*, расположенная по адресу *{directoryInfo.Parent}*, удалена");
                    directoryInfo.Delete(true);
                    continue;
                }
                Console.WriteLine($"Интервал равен: {(int)interval.TotalMinutes} минут");
                Console.WriteLine();
                GetFoldersAndDelete(dir);
            }
        }
        public static void GetFilesAndDelete(string _path)
        {
                string[] files = Directory.GetFiles(path, ".", SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        Console.WriteLine(file);
                        FileInfo fileInfo = new FileInfo(file);
                        Console.WriteLine($"Время последнего изменения: {fileInfo.LastWriteTime}");
                        TimeSpan interval = DateTime.Now.Subtract(fileInfo.LastWriteTime);
                        if ((int)interval.TotalMinutes > 30)
                        {
                            Console.WriteLine($"Файл *{fileInfo.Name}*, расположенный по адресу *{fileInfo.Directory}*, удален");
                            fileInfo.Delete();
                        }
                        Console.WriteLine($"Интервал равен: {(int)interval.TotalMinutes} минут");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Файлы отсутствуют!");
                }
        }
        static void Main(string[] args)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Папки: ");
                    GetFoldersAndDelete(path);
                }
                else
                {
                    Console.WriteLine("Неверно задан путь к папке");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Файлы: ");
                    GetFilesAndDelete(path);
                }
                else
                {
                    Console.WriteLine("Неверно задан путь к папке");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
