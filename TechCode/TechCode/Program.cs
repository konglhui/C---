namespace TechCode
{
    internal class Program
    {
        public static void ListFunc()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                list.Add($"m{i}");
            }

            list.Insert(3, "abcd");
            list.Reverse();
            //list.RemoveAt(7); // 删除下标为7的值
            //list.Remove("m3"); //删除同一个值

            for (var i = 0; i < list.Count; i++)
            {
                var s = list[i];
                Console.WriteLine(s);
            }
        }

        public static void ArrayFunc()
        {
            string[] strs = new string[5] { "a", "b", "c", "d", "e" };
            strs[3] = "hello";
            string str = strs[4];
            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }

        public static void DictionaryFunc()
        {
            Dictionary<string, string> strs = new Dictionary<string, string>();
            for (int i = 0; i < 10; i++)
            {
                strs.Add($"m{i}", $"casd{i * i + 1 + 123012}asdfw");
            }

            for (int i = 0; i < 15; i++)
            {
                string findVal = $"m{i}";
                if (strs.ContainsKey(findVal))
                {
                    Console.WriteLine($"findVal   {findVal} -> {strs[findVal]}");
                }
                else
                {
                    Console.WriteLine($"Not Find Value : key is {findVal}");
                }
            }
        }

        public static void QueueFunc()
        {
            Queue<string> strs = new Queue<string>();
            strs.Enqueue("hello");
            strs.Enqueue("word");
            strs.Dequeue();
            while (true)
            {
                var str = strs.Dequeue();

                Console.WriteLine(str);
                if (strs.Count == 0)
                    break;
            }
        }

        private static void Main(string[] args)
        {
            //ListFunc();
            //ArrayFunc();
            //DictionaryFunc();
            QueueFunc();
            //Console.WriteLine("Hello, World!");
        }
    }
}