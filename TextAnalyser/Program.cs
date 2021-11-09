﻿using System;
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
            var textAnalyser = new TextAnalyser(textWorker, lineWorker);

            Console.WriteLine("Analysing textFile: " + args[0]);
            var words = textAnalyser.AnalyseText(args[0]);
            foreach (var word in words)
            {
                Console.WriteLine($"Word \"{word.Value}\" was in text {word.Count} times");
            }
            Console.WriteLine("<---------!--------->");
            while (true)
            {
                Console.Write("Enter a word to see in which lines it is: ");
                string word = Console.ReadLine();  
                var resultInfo = textAnalyser.GetInfoAboutWord(word);
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
