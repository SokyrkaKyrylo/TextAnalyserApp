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

        private ITextWorker _textWorker;

        private ILineWorker _sentanceWorker;

        public TextAnalyser(ITextWorker textWorker, ILineWorker sentanceWorker)
        {
            _textWorker = textWorker;
            _sentanceWorker = sentanceWorker;
        }

        public IEnumerable<Word> AnalyseText(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException();

            Words = _textWorker.ProcessText(filename);
            return Words;
        }

        public IEnumerable<string> GetInfoAboutWord(string wordToFound)
        {
            var word = Words.Where(w => w.Value.Equals(wordToFound)).FirstOrDefault();
            if (word is null)
                return null;

            return _sentanceWorker.ProcessLines(word);
        }

    }
}
