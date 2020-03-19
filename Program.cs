using System;

namespace Delegate
{
    public class Word
    {
        public int index { get; set; }
        public string word { get; set; }

        public static Word[] filter(Word[] words, char c, IFilter filter)
        {
            return filter.filter(words, c);
        }

        public static Word[] counter(Word[] words, int i, ICounter counter)
        {
            return counter.counter(words, i);
        }
    }



    public interface ICounter
    {
        Word[] counter(Word[] words, int i);
    }

    public class CounterThanBigger : ICounter
    {
        public Word[] counter(Word[] words, int x)
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
        }
    }


    public class CounterThanSmaller : ICounter
    {
        public Word[] counter(Word[] words, int x)
        {
            var w = new Word[words.Length];
            int i = -1;
            foreach (var word in words)
            {
                if (word.word.Length < x)
                {
                    i++;
                    w[i] = word;
                }
            }
            return w;
        }
    }

    public interface IFilter
    {
        Word[] filter(Word[] words, char c);
    }

    public class Filter : IFilter
    {
        public Word[] filter(Word[] words, char c)
        {
            var w = new Word[words.Length];
            int i = -1;
            foreach (var word in words)
            {
                if (word.word[0] != c)
                    continue;
                i++;
                w[i] = word;


            }
            return w;
        }
    }

    public class FilterA : IFilter
    {
        public Word[] filter(Word[] words, char c)
        {
            var w = new Word[words.Length];
            int i = 0;
            foreach (var word in words)
            {
                if (word.word[word.word.Length - 1] != c)
                    continue;

                w[i] = word;
                i++;

            }
            return w;
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

            var startWith = Word.filter(words, 'p', new Filter());

            System.Console.WriteLine("Filtered By StartsWith p");
            foreach (Word s in startWith)
            {
                if (s != null)
                    Console.WriteLine(s.word);
            }

            var endWith = Word.filter(words, 's', new FilterA());

            System.Console.WriteLine("Filtered By EndWith s");
            foreach (Word s in endWith)
            {
                if (s != null)
                    Console.WriteLine(s.word);
            }

            var counterThanSmaller = Word.counter(words, 4, new CounterThanSmaller());

            System.Console.WriteLine("Smaller Than 4");
            foreach (Word s in counterThanSmaller)
            {
                if (s != null)
                    Console.WriteLine(s.word);
            }

            var counterThanBigger = Word.counter(words, 9, new CounterThanBigger());

            System.Console.WriteLine("Bigger Than 9");
            foreach (Word s in counterThanBigger)
            {
                if (s != null)
                    Console.WriteLine(s.word);
            }
        }
    }
} 