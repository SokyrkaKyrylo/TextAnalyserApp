using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyser.Models;

namespace TextAnalyser.Absrtact
{
    internal interface ITextWorker
    {
        public IEnumerable<Word> ProcessText(string filename);
    }
}
