using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Interfaces
{
    public interface IPlugboard
    {
        Dictionary<char, char> GetWiring();
        void SetWiring(KeyValuePair<char, char> pair);
        int NumberPairs { get; set; }
        char ConvertLetter(char c);
    }
}
