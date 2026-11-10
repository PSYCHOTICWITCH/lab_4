using lab_4_project_2;

internal class Program()
{
    static void Main(string[] args)
    {
        int option = 1;
        while (option != 0)
        {
            Console.WriteLine("Введите номер задания (1 - 2) или 0 для выхода");
            while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 2)
            {
                Console.WriteLine("Неверный ввод. Введите число от 0 до 2.");
            }
            switch (option)
            {
                case 1:
                    {
                        double x_1 = 0;
                        double y_1 = 0;
                        Console.WriteLine("Введите координаты первого отрезка");
                        while (!double.TryParse(Console.ReadLine(), out x_1))
                        {
                            Console.WriteLine("Неверный ввод. Введите вещественное число.");
                        }
                        while (!double.TryParse(Console.ReadLine(), out y_1))
                        {
                            Console.WriteLine("Неверный ввод. Введите вещественное число.");
                        }
                        double x_2 = 0;
                        double y_2 = 0;
                        Console.WriteLine("Введите координаты второго отрезка");
                        while (!double.TryParse(Console.ReadLine(), out x_2))
                        {
                            Console.WriteLine("Неверный ввод. Введите вещественное число.");
                        }
                        while (!double.TryParse(Console.ReadLine(), out y_2))
                        {
                            Console.WriteLine("Неверный ввод. Введите вещественное число.");
                        }
                        LineSegment lineSegment_1 = new LineSegment(x_1, y_1);
                        LineSegment lineSegment_2 = new LineSegment(x_2, y_2);
                        Console.WriteLine(lineSegment_1.ToString());
                        Console.WriteLine(lineSegment_2.ToString());
                        if (LineSegment.IsIntersect(lineSegment_1, lineSegment_2))
                        {
                            Console.WriteLine("Отрезки пересекаются.");
                        }
                        else
                        {
                            Console.WriteLine("Отрезки не пересекаются.");
                        }
                        break;
                    }
                case 2:
                    {
                        double x_1 = 0;
                        double y_1 = 0;
                        Console.WriteLine("Введите координаты отрезка");
                        while (!double.TryParse(Console.ReadLine(), out x_1))
                        {
                            Console.WriteLine("Неверный ввод. Введите вещественное число.");
                        }
                        while (!double.TryParse(Console.ReadLine(), out y_1))
                        {
                            Console.WriteLine("Неверный ввод. Введите вещественное число.");
                        }

                        LineSegment lineSegment_1 = new LineSegment(x_1, y_1);
                        Console.WriteLine(lineSegment_1.ToString());

                        Console.WriteLine($"Длина отрезка {!lineSegment_1}");

                        Console.WriteLine($"Расширенный {lineSegment_1++.ToString()}");

                        double doubleLine = (double)lineSegment_1;
                        Console.WriteLine($"Явное приведение - {doubleLine.ToString()}");

                        int intLine = lineSegment_1;
                        Console.WriteLine($"Неявное приведение - {intLine.ToString()}");

                        int number = 0;
                        Console.WriteLine("Введите целое число");
                        while (!int.TryParse(Console.ReadLine(), out number))
                        {
                            Console.WriteLine("Неверный ввод. Введите целое число.");
                        }

                        Console.WriteLine($"Левосторонняя операция {lineSegment_1 - number}");
                        Console.WriteLine($"Правосторонняя операция {number - lineSegment_1}");

                        Console.WriteLine(lineSegment_1.ToString());
                        double x_2 = 0;
                        double y_2 = 0;
                        Console.WriteLine("Введите координаты второго отрезка");
                        while (!double.TryParse(Console.ReadLine(), out x_2))
                        {
                            Console.WriteLine("Неверный ввод. Введите вещественное число.");
                        }
                        while (!double.TryParse(Console.ReadLine(), out y_2))
                        {
                            Console.WriteLine("Неверный ввод. Введите вещественное число.");
                        }
                        LineSegment lineSegment_2 = new LineSegment(x_2, y_2);

                        Console.WriteLine(lineSegment_1.ToString());
                        Console.WriteLine(lineSegment_2.ToString());

                        if (lineSegment_1 < lineSegment_2)
                        {
                            Console.WriteLine("Отрезки пересекаются.");
                        }
                        else
                        {
                            Console.WriteLine("Отрезки не пересекаются.");
                        }
                        break;
                    }
            }
        }
    }
}