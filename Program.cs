using System;
using System.Collections.Generic;

namespace SumSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Исходные данные из примера
            int[] array = { 3, 5, -4, 8, 11, 1, -1, 6 };
            int targetSum = 10;

            Console.WriteLine("--- Анализ сложности алгоритмов поиска пары ---");
            Console.WriteLine($"Исходный массив: {string.Join(" ", array)}");
            Console.WriteLine($"Целевая сумма: {targetSum}\n");

            // 1. Тестирование наивного метода
            Console.WriteLine("Запуск \"наивного\" метода (O(N^2))...");
            int[] naiveResult = FindPairNaive(array, targetSum);
            PrintResult(naiveResult);

            // 2. Тестирование эффективного метода
            Console.WriteLine("Запуск эффективного метода (O(N))...");
            int[] efficientResult = FindPairEfficient(array, targetSum);
            PrintResult(efficientResult);
        }

        /// <summary>
        /// "Наивный" метод поиска пары чисел с помощью двух вложенных циклов.
        /// Временная сложность: O(N^2) — проверяет каждую пару.
        /// Память: O(1) — не требует выделения дополнительной памяти.
        /// </summary>
        public static int[] FindPairNaive(int[] array, int targetSum)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == targetSum)
                    {
                        return new int[] { array[i], array[j] };
                    }
                }
            }
            return new int[0]; // Если пара не найдена
        }

        /// <summary>
        /// Эффективный метод поиска с использованием хэш-таблицы (HashSet).
        /// Временная сложность: O(N) — проходит по массиву всего один раз.
        /// Память: O(N) — выделяет память под хранение посещенных чисел.
        /// </summary>
        public static int[] FindPairEfficient(int[] array, int targetSum)
        {
            HashSet<int> visitedNumbers = new HashSet<int>();

            foreach (int currentNum in array)
            {
                // Вычисляем число, которое нам необходимо найти для получения целевой суммы
                int requiredNum = targetSum - currentNum;

                // Если это число уже встречалось ранее, значит пара найдена
                if (visitedNumbers.Contains(requiredNum))
                {
                    return new int[] { requiredNum, currentNum };
                }

                // Добавляем текущее число в список посещенных
                visitedNumbers.Add(currentNum);
            }

            return new int[0]; // Если пара не найдена
        }

        // Вспомогательный метод для красивого вывода результата
        private static void PrintResult(int[] result)
        {
            if (result.Length == 2)
            {
                Console.WriteLine($"Найдена пара: {result[0]} и {result[1]}");
            }
            else
            {
                Console.WriteLine("Пара с такой суммой не найдена.");
            }
            Console.WriteLine();
        }
    }
}
