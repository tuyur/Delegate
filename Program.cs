using System;

namespace Delegate
{
    public delegate Word[] Counter(Word[] words, int x);

    public class Word
    {
        public int index { get; set; }
        public string word { get; set; }

        public static Word[] counter(Word[] words, int i, Counter counter)
        {
            return counter(words, i);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Word[] words = new Word[]{
                new Word { index = 0 , word = "proclaiming"},
                new Word { index = 1 , word = "brilliant"},
                new Word { index = 2 , word = "exhibition"},
                new Word { index = 3 , word = "ingenious"},
                new Word { index = 4 , word = "presents"},
                new Word { index = 4 , word = "car"}
            };

            var counterThanSmaller = Word.counter(words, 4, (Word[] words, int x) =>
           {
               var w = new Word[words.Length];
               int i = -1;
               foreach (var word in words)
               {
                   if (word.word.Length > x)
                   {
                       i++;
                       w[i] = word;
                   }
               }
               return w;
           });

            System.Console.WriteLine("Smaller Than 4");
            foreach (Word s in counterThanSmaller)
            {
                if (s != null)
                    Console.WriteLine(s.word);
            }


        }
    }
}