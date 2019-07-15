using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    class AbitSettings : IParserSettings
    {
        public AbitSettings(string number, int start, int end)
        {
            University = number;
            StartPage = start;
            EndPage = end;
        }
        public string BaseURL { get; set; } = "https://abit-poisk.org.ua";
        public string Prefix { get; set; } = "rate2019/direction";
        public string University { get; set; } = "538076";
        public int StartPage { get; set; } = 1;
        public int EndPage { get; set; } = 5;
    }
}
