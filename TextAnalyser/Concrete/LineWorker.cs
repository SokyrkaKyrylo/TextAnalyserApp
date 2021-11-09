using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyser.Absrtact;
using TextAnalyser.Models;

namespace TextAnalyser.Concrete
{
    internal class LineWorker : ILineWorker
    {        
        public IEnumerable<string> ProcessLines(Word word)
        {
            var info = new List<string>();
            foreach (var line in word.Lines)
            {
                info.Add($"Word {word.Value} on pos " +
                    $"{String.Join(", ", GetPositionInSentance(line.ToLower(), word.Value.ToLower()))} in line {line}");
            }
            return info;
        }

        private int[] GetPositionInSentance(string sentance, string word)
        {
            var list = new List<int>();
            int pos;
            while ((pos = sentance.IndexOf(word)) != -1)
            {
                list.Add(pos);
                sentance = sentance.Remove(0, pos+word.Length);
            }
            return list.ToArray();  
        }
    }
}
