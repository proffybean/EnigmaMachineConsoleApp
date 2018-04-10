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
            Plugboard plugboard = new Plugboard();
            Rotor rotor3 = new Rotor(rotorIII);
            rotor3.rotate = true;
            Rotor rotor2 = new Rotor(rotorII);
            rotor2.rotate = false;
            Rotor rotor1 = new Rotor(rotorI);
            rotor1.rotate = false;

            Reflector reflector = new Reflector();

            rotor3.SetDial('z');
            rotor2.SetDial('a');

            char firstChar = 'a';
            char next = plugboard.ConvertLetter(firstChar);

            char next2 = rotor3.ConvertLetter(next);
            int rotor2index = rotor3.GetNextRotorsIndex(next2);

            char next3 = rotor2.ConvertLetter(rotor2index);
            int rotor1index = rotor2.GetNextRotorsIndex(next3);

            char next4 = rotor1.ConvertLetter(rotor1index);
            int reflectorIndex = rotor1.GetNextRotorsIndex(next4);

            char next5 = reflector.ReflectLetter(reflectorIndex);
        }
    }
}
