using System;
using System.IO;

namespace Module8.Task1
{

    internal class Program
    {
        const string path = "D:\\Module8Task1";
        public static void GetFoldersAndDelete(string _path)
        {
            if (Directory.Exists(_path))
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
                        Console.WriteLine($"Папку: *{directoryInfo.Name}* расположенную по адресу *{directoryInfo.Parent}* можно будет удалять");
                    }
                    Console.WriteLine($"Интервал равен: {(int)interval.TotalMinutes} минут");
                    Console.WriteLine();
                    GetFoldersAndDelete(dir);
                }
            }
            else 
            {
                Console.WriteLine("Неверно задан путь к папке");
            }
        }
        public static void GetFilesAndDelete(string _path)
        {
            if (Directory.Exists(_path))
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
                            Console.WriteLine($"Файл *{fileInfo.Name}* расположенный по адресу *{fileInfo.Directory}* можно будет удалить");
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
            else
            {
                Console.WriteLine("Неверно задан путь к папке");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Папки: ");
                GetFoldersAndDelete(path);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            try
            {
                Console.WriteLine("Файлы: ");
                GetFilesAndDelete(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
