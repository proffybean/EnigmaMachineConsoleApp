using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components;
using static Components.Constants;

namespace EnigmaMachineConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EnigmaMachine enigmaMachine = new EnigmaMachine();
            enigmaMachine.SetPlugboardPair('h', 's');
            enigmaMachine.SetPlugboardPair('a', 'e');
            enigmaMachine.SetPlugboardPair('d', 'j');
            enigmaMachine.SetPlugboardPair('p', 'q');
            enigmaMachine.SetPlugboardPair('g', 'm');
            enigmaMachine.SetRotorDials('a', 'a', 'z');
            Console.WriteLine(enigmaMachine.Encode("hello") ); 
        }
    }
}
