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
                info.Add($"Word '{word.Value}' on pos " +
                    $"{String.Join(", ", GetPositionInLine(line.Value.ToLower(), word.Value.ToLower()))} in line number:{line.LineNumber} " +
                    $"\n|{line.Value}");
            }
            return info;
        }

        private int[] GetPositionInLine(string line, string word)
        {
            var list = new List<int>();
            int pos;
            while ((pos = line.IndexOf(word, StringComparison.Ordinal)) != -1)
            {
                list.Add(pos);
                line = line.Remove(0, pos+word.Length);
            }
            return list.ToArray();  
        }
    }
}
