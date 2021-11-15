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
            using var sr = new StreamReader(fileName);
                while (sr.Peek() >= 0)
                    yield return sr.ReadLine();
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
                    var wordExist = allWords.FirstOrDefault(w => w.Value.Equals(tempWord));
                    if (wordExist is null)
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
                        wordExist.Count += 1;
                        if (!wordExist.Lines.Contains(line))
                            wordExist.Lines.Add(line);
                    }
                }
            }
            return allWords;
        }
    }
}
