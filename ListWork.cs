using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace lab_4_project_1
{
    internal class ListWork
    {
        public static List<int> ListIntersection(List<int> L1, List<int> L2)
        {
            List<int> L = new List<int>();
            foreach (int item in L1)
            {
                foreach (int item2 in L2)
                {
                    if (item.Equals(item2) && !L.Contains(item))
                    {
                        L.Add(item);
                    }
                }
            }
            return L;
        }

        public static LinkedList<int> ReverseAdd(LinkedList<int> L)
        {
            LinkedListNode<int> current = L.Last;
            while (current != null) 
            { 
                L.AddLast(current.Value);
                current = current.Previous;
            }
            return L;
        }

        public static int CountLetters(string text)
        {
            HashSet<char> uniqueLetters = new HashSet<char>();
            if (RussianCheck(text))
            {
                foreach (char c in text)
                {
                    uniqueLetters.Add(char.ToLower(c));
                }
            }
            else
            {
                Console.WriteLine("Текст не соответствует требованиям.");
            }
            return uniqueLetters.Count;
        }

        private static bool RussianCheck(string text)
        {
            foreach (char c in text)
            {
                if (!((c >= 'А' && c <= 'я') || (c == 'Ё') || (c == 'ё')))
                {
                    return false;
                }
            }
            return true;
        }

        public static HashSet<string> MakeMallSet()
        {
            string mall = "";
            int size = 0;
            HashSet<string> set = new HashSet<string>();
            Console.WriteLine("Введите количество торговых центров:");
            while (!int.TryParse(Console.ReadLine(), out size) || size < 1)
            {
                Console.WriteLine("Неверный ввод. Введите положительное число.");
            }
            Console.WriteLine("Введите названия торговых центров:");
            for (int i = 0; i < size; i++)
            {
                mall = Console.ReadLine();
                while (string.IsNullOrEmpty(mall) || set.Contains(mall))
                {
                    if (set.Contains(mall))
                    {
                        Console.WriteLine("Название уже введено.");
                    }
                    Console.WriteLine("Введите текст:");
                    mall = Console.ReadLine();
                }
                set.Add(mall);
            }
            return set;
        }

        public static List<HashSet<string>> StudentData(HashSet<string> malls) 
        {
            int amount = 0;
            string name = "";
            List<HashSet<string>> students = new List<HashSet<string>>();
            Console.WriteLine("Введите количество студентов:");
            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1)
            {
                Console.WriteLine("Неверный ввод. Введите положительное число.");
            }
            if (malls.Count > 0) 
            {
                int mallsAmount = 0;
                for (int i = 0; i < amount; i++)
                {
                    HashSet<string> set = new HashSet<string>();
                    Console.WriteLine($"Введите количество торговых центров, посещенных студентом {i + 1}:");
                    while (!int.TryParse(Console.ReadLine(), out mallsAmount) || mallsAmount < 1)
                    {
                        Console.WriteLine("Неверный ввод. Введите положительное число.");
                    }
                    Console.WriteLine($"Введите в названия торговых центров, которые посещал студент {i + 1}:");
                    VerticalShow(malls);
                    for (int j = 0; j < mallsAmount; j++)
                    {
                        name = Console.ReadLine();
                        while (string.IsNullOrEmpty(name) || !malls.Contains(name) || set.Contains(name))
                        {
                            if (!malls.Contains(name))
                            {
                                Console.WriteLine("Торгового центра не существует.");
                            }
                            else if (set.Contains(name))
                            {
                                Console.WriteLine("Название уже введено.");
                            }
                            else
                            {
                                Console.WriteLine("Введите текст:");
                            }
                            name = Console.ReadLine();
                        }
                        set.Add(name);
                    }
                    students.Add(set);
                }
            }
            else
            {
                Console.WriteLine("Список торговых центров пуст!");
            }
            return students;
        }

        public static HashSet<string> VisitedByAll(HashSet<string> allMalls, List<HashSet<string>> students)
        {
            
            if (allMalls.Count < 1)
            {
                Console.WriteLine("Список торговых центров пуст!");
                return new HashSet<string>();
            }
            if (students.Count < 1)
            {
                Console.WriteLine("Список студентов пуст!");
                return new HashSet<string>();
            }
            HashSet<string> result = new HashSet<string>(students[0]);
            for (int i = 1; i < students.Count; i++)
            {
                result.IntersectWith(students[i]);
            }
            return result;
        }

        public static HashSet<string> VisitedBySome(HashSet<string> allMalls, List<HashSet<string>> students)
        {
            if (allMalls.Count < 1)
            {
                Console.WriteLine("Список торговых центров пуст!");
                return new HashSet<string>();
            }
            if (students.Count < 1)
            {
                Console.WriteLine("Список студентов пуст!");
                return new HashSet<string>();
            }
            HashSet<string> result = new HashSet<string>(students[0]);
            for (int i = 1; i < students.Count; i++)
            {
                result.UnionWith(students[i]);
            }
            return result;
        }

        public static HashSet<string> VisitedByNobody(HashSet<string> allMalls, List<HashSet<string>> students)
        {
            HashSet<string> result = allMalls;
            if (allMalls.Count > 0)
            {
                if (students.Count > 0)
                {
                    HashSet<string> visited = VisitedBySome(allMalls, students);
                    result.ExceptWith(visited);
                }
                else
                {
                    Console.WriteLine("Список студентов пуст!");
                }
            }
            else
            {
                Console.WriteLine("Список торговых центров пуст!");
            }
            return result;
        }

        public static void Show(List<HashSet<string>> L)
        {
            string outString = "";
            int number = 1;
            if (L.Count > 0)
            {
                foreach (HashSet<string> item in L)
                {
                    outString = $"{number++} | ";
                    foreach (string name in item)
                    {
                        outString += $"{name} ";
                    }
                    Console.WriteLine(outString);
                }
            }
            else
            {
                outString = "Список пуст!";
            }
        }
        public static string Show(List<int> L)
        {
            string outString = "";
            if (L.Count > 0) 
            {
                foreach (int item in L)
                {
                    outString += $"{item} ";
                }
            }
            else
            {
                outString = "Список пуст!";
            }
            return outString;
        }

        public static string Show(HashSet<string> S)
        {
            string outString = "";
            if (S.Count > 0)
            {
                foreach (string item in S)
                {
                    outString += $"{item} ";
                }
            }
            else
            {
                outString = "Список пуст!";
            }
            return outString;
        }

        public static string Show(LinkedList<int> L)
        {
            string outString = "";
            LinkedListNode<int> current = L.First;
            if (L.Count > 0)
            {
                while (current != null)
                {
                    outString += $"{current.Value} ";
                    current = current.Next;
                }
            }
            else
            {
                outString = "Список пуст!";
            }
            return outString;
        }

        public static void VerticalShow(HashSet<string> S)
        {
            int number = 1;
            if (S.Count > 0)
            {
                foreach (string item in S)
                {
                    Console.WriteLine($"{number++} - {item}");
                }
            }
            else
            {
                Console.WriteLine("Список пуст!");
            }
        }
    }
}
