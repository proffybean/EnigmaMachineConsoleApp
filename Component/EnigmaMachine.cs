using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.Interfaces;
using static Components.Constants;

namespace Components
{
    public class EnigmaMachine : IEnigmaMachine
    {
        private Plugboard plugboard;
        private Rotor rotor3;
        private Rotor rotor2;
        private Rotor rotor1;
        private Reflector reflector;

        public EnigmaMachine()
        {
            plugboard = new Plugboard();
            rotor3 = new Rotor(rotorIII, true, 21);
            rotor2 = new Rotor(rotorII, false, 4);
            rotor3.AdvanceAdjacentRotor += rotor2.RotateHandler;
            rotor1 = new Rotor(rotorI, false, 16);
            rotor2.AdvanceAdjacentRotor += rotor1.RotateHandler;
            reflector = new Reflector();
        }

        public char Encode(char c)
        {
            return ConvertCharacter(c);
        }

        public string Encode(string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in s.ToLower().ToCharArray())
            {
                if (!Char.IsLetter(c))
                    continue;
                sb.Append(ConvertCharacter(c));
            }

            return sb.ToString();
        }

        public void SetPlugboardPair(char a, char b)
        {
            plugboard.SetWiring(a, b);
        }

        public void SetRotorDial(int rotorNumber, char rotorSetting)
        {
            switch (rotorNumber)
            {
                case 1:
                    rotor1.SetDial(rotorSetting);
                    break;
                case 2:
                    rotor2.SetDial(rotorSetting);
                    break;
                case 3:
                    rotor3.SetDial(rotorSetting);
                    break;
                default:
                    break;
            }
        }

        public void SetRotorDials(char rotor1, char rotor2, char rotor3)
        {
            SetRotorDial(1, rotor1);
            SetRotorDial(2, rotor2);
            SetRotorDial(3, rotor3);
        }

        private char ConvertCharacter(char c)
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
