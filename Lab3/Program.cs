using System;
namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("*** CARS ".PadRight(79, '*'));
                DatabaseManager.GetInstance().PrintTable();
                Console.WriteLine("1 - Добавить\n2 - Изменить\n3 - Удалить\n4 - Выход");
                Console.Write("Выберите пункт меню: ");
                int selectedMenuId = Convert.ToInt32(Console.ReadLine());
                switch (selectedMenuId)
                {
                    case 1:
                    {
                        DatabaseManager.GetInstance().Add();
                        break;
                    }
                    case 2:
                    {
                        DatabaseManager.GetInstance().Update();
                        break;
                    }
                    case 3:
                    {
                        DatabaseManager.GetInstance().Delete();
                        break;
                    }
                    case 4:
                    {
                        Environment.Exit(0);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Выбран неверный пункт меню!");
                        break;
                    }
                }
            }
        }
    }
}