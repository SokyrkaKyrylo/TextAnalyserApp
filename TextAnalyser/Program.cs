using System;
using TextAnalyser.Absrtact;
using TextAnalyser.Concrete;

namespace TextAnalyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITextWorker textWorker = new TextWorker();
            ILineWorker sentanceWorker = new LineWorker();
            var textAnaylser = new TextAnalyser(textWorker, sentanceWorker);

            Console.WriteLine("Analysing textFile: " + args[0]);
            var words = textAnaylser.AnalyseText(args[0]);
            foreach (var word in words)
            {
                Console.WriteLine($"Word \"{word.Value}\" was in text {word.Count} times");
            }
            Console.WriteLine("<---------!--------->");
            while (true)
            {
                Console.Write("Enter a word to see in which lines it is: ");
                string word = Console.ReadLine();  
                var resultInfo = textAnaylser.GetInfoAboutWord(word);
                foreach (var res in resultInfo)
                {
                    Console.WriteLine(res);
                }
            }
        }
    }
}
