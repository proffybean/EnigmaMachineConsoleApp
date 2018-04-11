using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Interfaces
{
    public interface IEnigmaMachine
    {
        void SetPlugboardPair(char a, char b);
        void SetRotorDial(int rotorNumber, char rotorSetting);
        char Encode(char c);
        string Encode(string s);
    }
}
