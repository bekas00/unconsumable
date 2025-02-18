using System;
using System.IO;
using System.Linq;

namespace create_pass
{
    internal class Program
    {
        private static readonly string ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+=<>?";
        static void Main(string[] args)
        {
            string generatedPassword = string.Empty;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Генератор паролей");
                Console.WriteLine("====================");
                Console.WriteLine($"Сгенерированный пароль: {generatedPassword}");
                Console.WriteLine();
                Console.WriteLine("1. Сгенерировать новый пароль");
                Console.WriteLine("2. Сохранить пароль");
                Console.WriteLine("3. Очистить экран");
                Console.WriteLine("4. Выйти");
                Console.WriteLine();

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        generatedPassword = GeneratePassword(8);
                        Console.WriteLine($"Новый сгенерированный пароль: {generatedPassword}");
                        break;

                    case "2":
                        if (string.IsNullOrEmpty(generatedPassword))
                        {
                            Console.WriteLine("Пароль не сгенерирован. Сначала Создайте пароль.");
                        }
                        else
                        {
                            SavePassword(generatedPassword);
                        }
                        break;

                    case "3":
                        Console.Clear();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу дял продолжения...");
                Console.ReadKey();
            }
        }
        private static string GeneratePassword(int length)
        {
            var random = new Random();
            return new string(Enumerable.Range(0, length)
                .Select(_ => ValidChars[random.Next(ValidChars.Length)])
                .ToArray());
        }
        private static void SavePassword(string password)
        {
            Console.Write("Введите имя файла для сохранения пароля: ");
            string fileName = Console.ReadLine();

            try
            {
                File.AppendAllText(fileName, password + Environment.NewLine);
                Console.WriteLine("пароль успешно сохранен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении пароля: {ex.Message}");
            }
        }
    }
}
