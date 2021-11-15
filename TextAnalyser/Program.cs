using System;
using System.IO;
using TextAnalyser.Absrtact;
using TextAnalyser.Concrete;

namespace TextAnalyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITextWorker textWorker = new TextWorker();
            ILineWorker lineWorker = new LineWorker();
            var textAnalyzer = new TextAnalyser(textWorker, lineWorker);
            string filePath = "";
            while (true)
            {
                Console.Write("Enter a filepath: ");
                filePath = Console.ReadLine();
                if (File.Exists(filePath))
                    break;
                Console.WriteLine("This file does not exits! Try again");
            }
            Console.WriteLine("Analyzing textFile: " + filePath);
            var words = textAnalyzer.AnalyseText(filePath);
            foreach (var word in words)
            {
                Console.WriteLine($"Word \"{word.Value}\" was in text {word.Count} times");
            }
            Console.WriteLine("<---------!--------->");
            while (true)
            {
                Console.WriteLine("To exit enter a 'q'");
                Console.Write("Enter a word to see in which lines it is: ");
                string word = Console.ReadLine();  
                if (word.Equals("q")) 
                    break;
                var resultInfo = textAnalyzer.GetInfoAboutWord(word);
                if (resultInfo is null)
                {
                    Console.WriteLine("This word doesn't present in text ^(");
                    continue;
                } 
                foreach (var res in resultInfo)
                {
                    Console.WriteLine(res);
                }
            }
        }
    }
}
