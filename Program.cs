namespace multithreaded_recording
{
    class Program
    {
        static void Main(string[] args) 
        {
            FileCreator creator = new FileCreator();

            while (true)
            {
                Console.WriteLine("Введите действие:\n1 - Запись в файл\n2 - Чтение из файла\n3 - параллельная запись\n4 - удалить файл\n5 - выход");

                char choice = Console.ReadKey().KeyChar;

                Console.Clear();

                switch (choice)
                {
                    case '1':
                        creator.WritingToFile();
                        break;

                    case '2':
                        creator.ReadingFile();
                        Console.WriteLine();
                        break;

                    case '3':
                        creator.MultithreadedRecording();
                        break;

                    case '4':
                        creator.DeleteFile();
                        break;

                    case '5':
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}