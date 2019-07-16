using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    public class HuffmanCode
    {
        readonly string _text;
        Dictionary<char, int> _frequencies;
        public HuffmanCode(string path)
        {
            _text = File.ReadAllText(path); 
            _frequencies = _text.ToDictionary<char, char, int>(a => a, b => _text.Count(c => c == b));
            _frequencies = _frequencies.OrderBy(x => x.Value).ToDictionary( y => y.Key, z => z.Value);
        }


      
    }
}
