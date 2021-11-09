using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyser.Models
{
    internal class Word
    {
        public string Value { get; set; }
        public int Count { get; set; }       
        public List<string> Lines { get; set; }
    }
}
