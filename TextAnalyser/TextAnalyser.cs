using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyser.Absrtact;
using TextAnalyser.Models;

namespace TextAnalyser
{
    internal class TextAnalyser
    {      
        public IEnumerable<Word> Words  { get; private set; }

        private readonly ITextWorker _textWorker;

        private readonly ILineWorker _lineWorker;

        public TextAnalyser(ITextWorker textWorker, ILineWorker lineWorker)
        {
            _textWorker = textWorker;
            _lineWorker = lineWorker;
        }

        public IEnumerable<Word> AnalyseText(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException();

            Words = _textWorker.ProcessText(filename).OrderByDescending(w => w.Count);
            return Words;
        }

        public IEnumerable<string> GetInfoAboutWord(string wordToFound)
        {
            var word = Words.FirstOrDefault(w => w.Value.Equals(wordToFound));
            if (word is null)
                return null;

            return _lineWorker.ProcessLines(word);
        }

    }
}
