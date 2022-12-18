using LinqTasks.Models.Home;
using System.Text.RegularExpressions;

namespace LinqTasks.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (context.ProgrammingTasks.Any())
            {
                return;
            }

            var languges = new Language[]
            {
                new Language { Name = "C#"}
            };

            var difficulties = new Difficulty[]
            {
                new Difficulty { Name = "Level 1" },
                new Difficulty { Name = "Level 2" }
            };

            context.Languages.AddRange(languges);
            context.Difficulties.AddRange(difficulties);
            context.SaveChanges();

            var programmingTasks = new ProgrammingTask[]
            {
                // Task 1 Level 1
                new ProgrammingTask
                {
                    Description = "Выведите все числа от 10 до 50 через запятую.",
                    Code =
                        "Console.WriteLine(string\r\n" +
                        "    .Join(\",\",\r\n" +
                        "        Enumerable\r\n" +
                        "            .Range(10, 41)));",
                    Result = string
                        .Join(",",
                            Enumerable
                                .Range(10, 41)),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 2 Level 1
                new ProgrammingTask
                {
                    Description = "Выведите только те числа от 10 до 50, которые делятся на 3.",
                    Code =
                        "Console.WriteLine(string\r\n" +
                        "    .Join(\",\",\r\n" +
                        "        Enumerable\r\n" +
                        "            .Range(10, 41);\r\n"+
                        "            .Where(number => number % 3 == 0)));",
                    Result = string
                        .Join(",",
                            Enumerable
                                .Range(10, 41)
                                .Where(number => number % 3 == 0)),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 3 Level 1
                new ProgrammingTask
                {
                    Description = "Вывести слово \"Linq\" 10 раз",
                    Code =
                        "Console.WriteLine(string\r\n" +
                        "    .Join(\",\",\r\n" +
                        "        Enumerable\r\n" +
                        "            .Repeat(\"Linq\", 10)));",
                    Result = string
                        .Join(",",
                            Enumerable
                                .Repeat("Linq", 10)),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 4 Level 1
                new ProgrammingTask
                {
                    Description = "Выведите все слова с буквой 'а' в строке \"aaa;abb;ccc;dap\".",
                    Code =
                        "Console.WriteLine(string\r\n" +
                        "    .Join(',', Regex\r\n" +
                        "        .Split(\"aaa;abb;ccc;dap\", @\"\\W+\")\r\n" +
                        "        .Where(word => word\r\n"+
                        "            .Contains('a'))));",
                    Result = string
                        .Join(',', Regex
                            .Split("aaa;abb;ccc;dap", @"\W+")
                            .Where(word => word
                                .Contains('a'))),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 5 Level 1
                new ProgrammingTask
                {
                    Description = "Выведите количество букв 'a' в словах с этой буквой в строке \"aaa;abb;ccc;dap\" через запятую.",
                    Code =
                        "Console.WriteLine(string\r\n" +
                        "    .Join(',', Regex\r\n" +
                        "        .Split(\"aaa;abb;ccc;dap\", @\"\\W+\")\r\n" +
                        "        .Where(word => word\r\n" +
                        "            .Contains('a'))\r\n" +
                        "        .Select(word => word\r\n" +
                        "            .Count(letter => letter == 'a'))));",
                    Result = string
                        .Join(',', Regex
                            .Split("aaa;abb;ccc;dap", @"\W+")
                            .Where(word => word
                                .Contains('a'))
                            .Select(word => word
                                .Count(letter => letter == 'a'))),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 6 Level 1
                new ProgrammingTask
                {
                    Description = "Выведите true, если слово \"abb\" присутствует в строке \"aaa;xabbx;abb;ccc;dap\", иначе false.",
                    Code =
                        "Console.WriteLine(string\r\n" +
                        "    .Join(',', Regex\r\n" +
                        "        .Split(\"aaa;xabbx;abb;ccc;dap\", @\"\\W+\")\r\n" +
                        "        .Contains(\"abb\")));",
                    Result = string
                        .Join(',', Regex
                            .Split("aaa;xabbx;abb;ccc;dap", @"\W+")
                            .Contains("abb")),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 7 Level 1
                new ProgrammingTask
                {
                    Description = "Получить самое длинное слово в строке \"aaa;xabbx;abb;ccc;dap\".",
                    Code =
                        "Console.WriteLine(Regex\r\n" +
                        "    .Split(\"aaa;xabbx;abb;ccc;dap\", @\"\\W+\")\r\n" +
                        "    .Select((word, index) => Tuple.Create(word.Length, -index, word))\r\n" +
                        "    .Max()!\r\n" +
                        "    .Item3);",
                    Result = Regex
                        .Split("aaa;xabbx;abb;ccc;dap", @"\W+")
                        .Select((word, index) => Tuple.Create(word.Length, -index, word))
                        .Max()!
                        .Item3,
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 8 Level 1
                new ProgrammingTask
                {
                    Description = "Вычислить среднюю длину слова в строке \"aaa;xabbx;abb;ccc;dap\".",
                    Code =
                        "Console.WriteLine(Regex\r\n" +
                        "    .Split(\"aaa;xabbx;abb;ccc;dap\", @\"\\W+\")\r\n" +
                        "    .Average(word => word.Length)\r\n" +
                        "    .ToString());",
                    Result = Regex
                        .Split("aaa;xabbx;abb;ccc;dap", @"\W+")
                        .Average(word => word.Length)
                        .ToString(),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 9 Level 1
                new ProgrammingTask
                {
                    Description = "Выведите самое короткое слово, перевернутое в строке \"aaa;xabbx;abb;ccc;dap;zh\".",
                    Code =
                        "Console.WriteLine(new string(Regex\r\n" +
                        "    .Split(\"aaa;xabbx;abb;ccc;dap;zh\", @\"\\W+\")\r\n" +
                        "    .Select((word, index) => Tuple.Create(word.Length, index, word))\r\n" +
                        "    .Min()!\r\n" +
                        "    .Item3\r\n" +
                        "    .Reverse()\r\n" +
                        "    .ToArray()));",
                    Result = new string(Regex
                        .Split("aaa;xabbx;abb;ccc;dap;zh", @"\W+")
                        .Select((word, index) => Tuple.Create(word.Length, index, word))
                        .Min()!
                        .Item3
                        .Reverse()
                        .ToArray()),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                // Task 10 Level 1
                new ProgrammingTask
                {
                    Description = "Выведите true, если в первом слове, начинающемся с \"aa\", все буквы равны \"b\", иначе false \"baaa;aabb;aaa;xabbx;abb;ccc;dap;zh\".",
                    Code =
                        "Console.WriteLine((Regex\r\n" +
                        "    .Split(\"baaa;aabb;aaa;xabbx;abb;ccc;dap;zh\", @\"\\W+\")\r\n" +
                        "    .FirstOrDefault(word => word.StartsWith(\"aa\"))\r\n" +
                        "    ?? \"NotOnlyLettersB\")\r\n" +
                        "    .Skip(2)\r\n" +
                        "    .All(letter => letter == 'b')\r\n" +
                        "    .ToString));",
                    Result = (Regex
                        .Split("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh", @"\W+")
                        .FirstOrDefault(word => word.StartsWith("aa"))
                        ?? "NotOnlyLettersB")
                        .Skip(2)
                        .All(letter => letter == 'b')
                        .ToString(),
                    LanguageId = 1,
                    DifficultyId = 1
                },
                 // Task 1 Level 2
                new ProgrammingTask
                {
                    Description = "Дан IEnumerable<string> lines (Например {\"\", \"02\", \"-12\", \"\", \"10\"}). Необходимо получить массив целых чисел (int[])",
                    Code =
                        "return lines\r\n" +
                        "    .Where(line => !string.IsNullOrEmpty(line))\r\n" +
                        "    .Select(int.Parse)\r\n" +
                        "    .ToArray();",
                    LanguageId = 1,
                    DifficultyId = 2
                },
                 // Task 2 Level 2
                new ProgrammingTask
                {
                    Description = "Дан IEnumerable<string> lines. В каждой строке написаны две координаты точки (X, Y), разделенные пробелом" +
                        " (Например {\"1 2\", \"0 2\", \"-1 2\", \"8 22\", \"1 0\"}). Необходимо получить список точек List<Point>." +
                        " Постарайтесь не использовать функцию преобразования строки в число более одного раза.",
                    Code =
                        "return lines\r\n" +
                        "    .Select(line => line.Split()\r\n" +
                        "        .Select(int.Parse)\r\n" +
                        "        .ToList())\r\n" +
                        "    .Select(coordinates => new Point(coordinates[0], coordinates[1]))\r\n" +
                        "    .ToList();",
                    LanguageId = 1,
                    DifficultyId = 2
                },
                 // Task 3 Level 2
                new ProgrammingTask
                {
                    Description = "Есть массив школьных классов Classroom[] classes." +
                        " В каждом классе есть список учеников List<string> Students." +
                        " Необходимо получить массив всех учеников всех классов string[].",
                    Code =
                        "return lines\r\n" +
                        "    .SelectMany(list => list.Students)\r\n" +
                        "    .ToArray();",
                    LanguageId = 1,
                    DifficultyId = 2
                },
                 // Task 4 Level 2
                new ProgrammingTask
                {
                    Description = "Текст задан массивом строк string[] textLines. " +
                        "Необходимо составить лексикографически упорядоченный список всех встречающихся в этом тексте слов. " +
                        "Слова нужно сравнивать регистронезависимо, а выводить в нижнем регистре.",
                    Code =
                        "return textLines\r\n" +
                        "    .SelectMany(line => Regex.Split(line.ToLower(), @\"\\W+\"))\r\n" +
                        "    .Distinct()\r\n" +
                        "    .OrderBy(word => word)\r\n" +
                        "    .ToArray();",
                    LanguageId = 1,
                    DifficultyId = 2
                },
                 // Task 5 Level 2
                new ProgrammingTask
                {
                    Description = "Дан текст \"text\", нужно составить список всех встречающихся в тексте слов, " +
                        "упорядоченный сначала по возрастанию длины слова, а потом лексикографически. " +
                        "Запрещено использовать ThenBy и ThenByDescending.",
                    Code =
                        "return Regex\r\n" +
                        "    .Split(text.ToLower(), @\"\\W+\")\r\n" +
                        "    .Where(word => !string.IsNullOrEmpty(word))\r\n" +
                        "    .Distinct()\r\n" +
                        "    .OrderBy(word => Tuple.Create(word.Length, word))\r\n" +
                        "    .ToList();",
                    LanguageId = 1,
                    DifficultyId = 2
                },
                 // Task 6 Level 2
                new ProgrammingTask
                {
                    Description = "Дан список слов List<string> words, нужно найти самое длинное слово из этого списка, " +
                        "а из всех самых длинных — лексикографически первое слово. " +
                        "Не используйте методы сортировки — сложность сортировки O(N * log(N)), однако эту задачу можно решить за O(N).",
                    Code =
                        "return words\r\n" +
                        "    .Select(word => Tuple.Create(-word.Length, word))\r\n" +
                        "    .Min()\r\n" +
                        "    .Item2;",
                    LanguageId = 1,
                    DifficultyId = 2
                },
                 // Task 7 Level 2
                new ProgrammingTask
                {
                    Description = "Выведите true, если в первом слове, начинающемся с \"aa\", все буквы равны \"b\", иначе false \"baaa;aabb;aaa;xabbx;abb;ccc;dap;zh\"",
                    Code = 
                        "return Regex\r\n" +
                        "    .Split(text.ToLower(), @\"\\W+\")\r\n" +
                        "    .Where(str => !string.IsNullOrEmpty(str))\r\n" +
                        "    .GroupBy(word => word)\r\n" +
                        "    .Select(wordList => Tuple.Create(wordList.Key, wordList.Count()))\r\n" +
                        "    .OrderBy(tuple => Tuple.Create(-1 * tuple.Item2, tuple.Item1))\r\n" +
                        "    .Take(count)\r\n" +
                        "    .ToArray();",
                    LanguageId = 1,
                    DifficultyId = 2
                }
            };

            context.ProgrammingTasks.AddRange(programmingTasks);
            context.SaveChanges();
        }
    }
}
