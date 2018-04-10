using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.Interfaces;

namespace Components
{
    public class Reflector : IReflector
    {
        private Dictionary<char, char> Wiring;

        public Reflector()
        {
            Wiring = new Dictionary<char, char>();
            this.SetWiring();
        }

        /// <summary>
        /// Notice, if a -> b, then b must -> a for decryption
        /// </summary>
        private void SetWiring()
        {
            Wiring.Add('a', 'q');
            Wiring.Add('b', 'y');
            Wiring.Add('c', 'h');
            Wiring.Add('d', 'o');
            Wiring.Add('e', 'g');
            Wiring.Add('f', 'n');
            Wiring.Add('g', 'e');
            Wiring.Add('h', 'c');
            Wiring.Add('i', 'v');
            Wiring.Add('j', 'p');
            Wiring.Add('k', 'u');
            Wiring.Add('l', 'z');
            Wiring.Add('m', 't');
            Wiring.Add('n', 'f');
            Wiring.Add('o', 'd');
            Wiring.Add('p', 'j');
            Wiring.Add('q', 'a');
            Wiring.Add('r', 'x');
            Wiring.Add('s', 'w');
            Wiring.Add('t', 'm');
            Wiring.Add('u', 'k');
            Wiring.Add('v', 'i');
            Wiring.Add('w', 's');
            Wiring.Add('x', 'r');
            Wiring.Add('y', 'b');
            Wiring.Add('z', 'l');
        }

        public Dictionary<char, char> GetWiring()
        {
            var Wiring = new Dictionary<char, char>();
            Wiring = this.Wiring;

            return Wiring;
        }

        public char ReflectLetter(char c)
        {
            return Wiring[c];
        }
    }
}
