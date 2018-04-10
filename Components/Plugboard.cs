using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.Interfaces;

namespace Components
{
    public class Plugboard : IPlugboard
    {
        public int NumberPairs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public char ConvertLetter(char c)
        {
            throw new NotImplementedException();
        }

        public Dictionary<char, char> GetWiring()
        {
            throw new NotImplementedException();
        }

        public void SetWiring(KeyValuePair<char, char> pair)
        {
            throw new NotImplementedException();
        }
    }
}
