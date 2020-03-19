using System;

namespace Delegate
{
    public delegate bool Counter(int x, int y);

    public class Word
    {
        public int index { get; set; }
        public string word { get; set; }

        public static string compare(int x, int y, Counter counter)
        {
            if (counter(x, y))
                return String.Format(" {0} , {1} den büyüktür", x, y);
            else
                return String.Format(" {0} , {1} den küçük veya eşittir", x, y);

        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            var compareString = Word.compare(3, 4, (x, y) => x == y);
            System.Console.WriteLine(compareString);



        }
    }
}