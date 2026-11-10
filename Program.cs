using lab_4_project_1;
using System.Xml.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int option = 1;
        while (option != 0) 
        {
            while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 5)
            {
                Console.WriteLine("Неверный ввод. Введите число от 0 до 5.");
            }
            switch (option) 
            {
                case 1: 
                    {
                        int size1 = 0;
                        int size2 = 0;
                        int element = 0;
                        List<int> list1 = new List<int>();
                        List<int> list2 = new List<int>();
                        Console.WriteLine("Введите размер первого списка:");
                        while (!int.TryParse(Console.ReadLine(), out size1) || size1 < 1)
                        {
                            Console.WriteLine("Неверный ввод. Введите положительное число.");
                        }
                        Console.WriteLine("Введите элементы первого списка:");
                        for (int i = 0; i < size1; i++)
                        {
                            while (!int.TryParse(Console.ReadLine(), out element))
                            {
                                Console.WriteLine("Неверный ввод. Введите целое число.");
                            }
                            list1.Add(element);
                        }
                        Console.WriteLine("Введите размер второго списка:");
                        while (!int.TryParse(Console.ReadLine(), out size2) || size2 < 1)
                        {
                            Console.WriteLine("Неверный ввод. Введите положительное число.");
                        }
                        Console.WriteLine("Введите элементы второго списка:");
                        for (int i = 0; i < size2; i++)
                        {
                            while (!int.TryParse(Console.ReadLine(), out element))
                            {
                                Console.WriteLine("Неверный ввод. Введите целое число.");
                            }
                            list2.Add(element);
                        }
                        Console.WriteLine($"Первый список: {ListWork.Show(list1)}");
                        Console.WriteLine($"Второй список: {ListWork.Show(list2)}");
                        Console.WriteLine($"Объединенный список: {ListWork.Show(ListWork.ListIntersection(list1, list2))}");
                        break;
                    }
                case 2:
                    {
                        int size = 0;
                        int element = 0;
                        LinkedList<int> list = new LinkedList<int>();
                        Console.WriteLine("Введите размер списка:");
                        while (!int.TryParse(Console.ReadLine(), out size) || size < 1)
                        {
                            Console.WriteLine("Неверный ввод. Введите положительное число.");
                        }
                        Console.WriteLine("Введите элементы первого списка:");
                        for (int i = 0; i < size; i++)
                        {
                            while (!int.TryParse(Console.ReadLine(), out element))
                            {
                                Console.WriteLine("Неверный ввод. Введите целое число.");
                            }
                            list.AddLast(element);
                        }
                        Console.WriteLine($"Список: {ListWork.Show(list)}");
                        Console.WriteLine($"Преобразованный список: {ListWork.Show(ListWork.ReverseAdd(list))}");
                        break;
                    }
                case 3:
                    {
                        HashSet<string> mallSet = ListWork.MakeMallSet();
                        List<HashSet<string>> studentData = ListWork.StudentData(mallSet);
                        ListWork.Show(studentData);
                        Console.WriteLine($"Торговые центры, посещенные всеми: " +
                            $"{ListWork.Show(ListWork.VisitedByAll(mallSet, studentData))}");
                        Console.WriteLine($"Торговые центры, посещенные хотя бы одним: " +
                            $"{ListWork.Show(ListWork.VisitedBySome(mallSet, studentData))}");
                        Console.WriteLine($"Торговые центры не посещенные никем: " +
                            $"{ListWork.Show(ListWork.VisitedByNobody(mallSet, studentData))}");
                        break;
                    }
                case 4:
                    {
                        string text = "";
                        while (string.IsNullOrEmpty(text))
                        {
                            Console.WriteLine("Введите текст:");
                            text = Console.ReadLine();
                        }
                        Console.WriteLine($"Найдено уникальных букв: {ListWork.CountLetters(text)}");
                        break;
                    }
                case 5:
                    Console.WriteLine(":c");
                    break;
                case 0:
                    {
                        Console.WriteLine("Выход из программы.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Неверный ввод.");
                        break;
                    }
            }
        }
        
    }
}