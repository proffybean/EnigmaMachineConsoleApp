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
        public static Plugboard plugboard;
        public static Rotor rotor3;
        public static Rotor rotor2;
        public static Rotor rotor1;
        public static Reflector reflector;

        static void Main(string[] args)
        {
            plugboard = new Plugboard();
            plugboard.SetWiring('h', 's');
            plugboard.SetWiring('a', 'e');
            plugboard.SetWiring('d', 'j');
            plugboard.SetWiring('p', 'q');
            plugboard.SetWiring('g', 'm');


            rotor3 = new Rotor(rotorIII);
            rotor3.rotate = true;
            rotor2 = new Rotor(rotorII);
            rotor2.rotate = false;
            rotor1 = new Rotor(rotorI);
            rotor1.rotate = false;

            reflector = new Reflector();

            rotor3.SetDial('d');
            rotor2.SetDial('c');
            rotor1.SetDial('b');

            //char lightBoardChar = ConvertCharacter('h');
            //lightBoardChar = ConvertCharacter('e');

            StringBuilder sb = new StringBuilder();
            sb.Append(ConvertCharacter('h'));
            sb.Append(ConvertCharacter('e'));
            sb.Append(ConvertCharacter('l'));
            sb.Append(ConvertCharacter('l'));
            sb.Append(ConvertCharacter('o'));
            string encrypted = sb.ToString();

            rotor3.SetDial('d');
            rotor2.SetDial('c');
            rotor1.SetDial('b');
            sb.Clear();
            foreach(char c in encrypted.ToCharArray())
            {
                sb.Append(ConvertCharacter(c));
            }
            //sb.Append(ConvertCharacter('z'));
            //sb.Append(ConvertCharacter('f'));
            //sb.Append(ConvertCharacter('e'));
            //sb.Append(ConvertCharacter('b'));
            //sb.Append(ConvertCharacter('m'));
            string text = sb.ToString();

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
