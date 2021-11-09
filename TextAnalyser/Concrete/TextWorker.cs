using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TextAnalyser.Absrtact;
using TextAnalyser.Models;

namespace TextAnalyser
{
    internal class TextWorker : ITextWorker
    {
        private IEnumerable<string> GetLines(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                    yield return sr.ReadLine();
            }
        }

        public IEnumerable<Word> ProcessText(string filename)
        {
            var allWords = new List<Word>();
            foreach (var line in GetLines(filename))
            {
                var words = line.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    var tempWord = Regex.Replace(word, @"\W", "");
                    var wordExits = allWords.FirstOrDefault(w => w.Value.Equals(tempWord));
                    if (wordExits is null)
                    {
                        allWords.Add(new Word
                        {
                            Value = tempWord,
                            Count = 1,
                            Lines = new List<string>
                            {
                                line
                            }
                        });
                    }
                    else
                    {
                        wordExits.Count += 1;
                        if (!wordExits.Lines.Contains(line))
                            wordExits.Lines.Add(line);
                    }
                }
            }
            return allWords;
        }
    }
}
