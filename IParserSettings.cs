using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    interface IParserSettings
    {
        string BaseURL { get; set; } 
        string Prefix { get; set; }
        string University { get; set; }
        int StartPage { get; set; }
        int EndPage { get; set; }
    }
}
