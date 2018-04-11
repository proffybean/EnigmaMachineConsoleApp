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

        public static char ConvertCharacter(char c)
        {
            char next = plugboard.ConvertLetter(c);

            char next2 = rotor3.ConvertLetter(next);
            int rotor2index = rotor3.GetNextRotorsIndex(next2);

            char next3 = rotor2.ConvertLetter(rotor2index);
            int rotor1index = rotor2.GetNextRotorsIndex(next3);

            char next4 = rotor1.ConvertLetter(rotor1index);
            int reflectorIndex = rotor1.GetNextRotorsIndex(next4);

            char next5 = reflector.ReflectLetter(reflectorIndex);
            int nextRotor1Index = reflector.GetNextRotorsIndex(next5);

            char initLetter1 = rotor1.ReverseConvertLetter(nextRotor1Index);
            int nextRotor2Index = rotor1.ReverseGetNextRotorsIndex(initLetter1);

            char initLetter2 = rotor2.ReverseConvertLetter(nextRotor2Index);
            int nextRotor3Index = rotor2.ReverseGetNextRotorsIndex(initLetter2);

            char initLetter3 = rotor3.ReverseConvertLetter(nextRotor3Index);
            int plugBoardIndex = rotor3.ReverseGetNextRotorsIndex(initLetter3);

            char lightBoardChar = plugboard.ConvertLetter(plugBoardIndex);

            return lightBoardChar;
        }
    }
}
