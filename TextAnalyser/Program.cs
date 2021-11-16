using System;
using System.IO;
using System.Linq;
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
            var answer = "";
            do
            {
                var filePath = "";
                var inputCorrect = false;
                do
                {
                    Console.Write("Enter a filepath: ");
                    filePath = Console.ReadLine();
                    inputCorrect = !(File.Exists(filePath) && Path.GetExtension(filePath) == ".txt");
                    if (inputCorrect)
                        Console.WriteLine("This file isn't correct");
                } while (inputCorrect);
                Console.WriteLine("Analyzing textFile: " + filePath);
                var words = textAnalyzer.AnalyseText(filePath);
                if (!words.Any())
                {
                    Console.WriteLine("This file don't have any words");
                    continue;
                }
                foreach (var word in words)
                {
                    Console.WriteLine($"Word \"{word.Value}\" was in text {word.Count} times");
                }
                Console.WriteLine("<---------!--------->");
                do
                {
                    Console.Write("Enter a word to see in which lines it is: ");
                    answer = Console.ReadLine();
                    var resultInfo = textAnalyzer.GetInfoAboutWord(answer);
                    if (resultInfo is null)
                    {
                        Console.WriteLine("This word doesn't present in text ^(");
                        continue;
                    }

                    foreach (var res in resultInfo)
                    {
                        Console.WriteLine(res);
                    }
                    Console.WriteLine("To exit enter a 'q'\n" +
                                      "To continue - everything that u want");
                        
                    answer = Console.ReadLine();
                } while (answer != "q"); 
                Console.WriteLine("To choose another file to analyze enter 'g'" +
                                  "\nTo exit from program enter 'q'");
                answer = Console.ReadLine();
            } while (!answer.Equals("q"));
        }
    }
}
