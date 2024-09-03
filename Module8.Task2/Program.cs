namespace Module8.Task2
{
    internal class Program
    {
        const string path = "D:\\Личные документы";
        public static void ShowTotalSizeFolder(string _path)
        {
            long totalSize = 0;
            if (Directory.Exists(_path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                string[] files = Directory.GetFiles(path, ".", SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        totalSize += fileInfo.Length;
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверно указан путь к директории");
            }
            Console.WriteLine($"Размер папки равен: {totalSize} байт");
        }
        static void Main(string[] args)
        {
            try
            {
                ShowTotalSizeFolder(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
