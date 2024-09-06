using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multithreaded_recording
{
    public class FileCreator
    {
        string path;

        public FileCreator()
        {
            path = "log.txt";
            FileChecking();
        }

        private void FileChecking()
        {
            if (File.Exists(path)) FileCreating();
        }

        private void FileCreating()
        {
            File.Create(path);
        }

        public void WritingToFile()
        {
            string message = "Поток 1: " + DateTime.Now + "\n";
            byte[] info = new UTF8Encoding(true).GetBytes(message);

            try
            {
                using (FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка ввода в файл: " + ex.Message);
            }
        }

        public void ReadingFile()
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка чтения: " + ex.Message);
            }
        }
        public void MultithreadedRecording()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    using (FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("Поток 1: " + DateTime.Now + "\n");
                        for (int j = 0; j < 5; j++)
                            fs.Write(info, 0, info.Length);
                        info = new UTF8Encoding(true).GetBytes("Поток 2: " + DateTime.Now + "\n");
                        for (int j = 0; j < 5; j++)
                            fs.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка многопоточной записи: " + ex.Message);
            }
        }

        public void DeleteFile()
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);

                    Console.WriteLine("Файл успешно удален.");
                }

                else 
                    Console.WriteLine("Файл не найден.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Ошибка удаления файла: " + ex.Message);
            }
        }
    }
}
