using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.Interfaces;

namespace Components
{
    /// <summary>
    /// Rotor wiring found from https://en.wikipedia.org/wiki/Enigma_rotor_details
    /// </summary>
    public class Rotor : IRotor
    {
        private Dictionary<char, char> _wiring2;
        private char[] _wiring;
        private int _dialOffset;
        public bool rotate;

        public Rotor(string rotorMapping)
        {
            InitWiring(rotorMapping);
            InitWiring2(rotorMapping);
        }

        public Rotor() : this("BDFHJLCPRTXVZNYEIWGAKMUSQO".ToLower()) { }

        public int Offset
        {
            get { return _dialOffset; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _dialOffset = value % 26;
            }
        }

        public char ConvertLetter(char c)
        {
            //ASCIIEncoding.ASCII.GetBytes(c);
            //int i = Encoding.ASCII.GetBytes(c);
            int i = Convert.ToByte(c) - Convert.ToByte('a');
            return ConvertLetter(i);
        }

        public char ConvertLetter(int i)
        {
            if (rotate) { Rotate(); }
            //int index = (i + (26 - Offset)) % 26;
            int index = (i + Offset) % 26;
            char letter = _wiring[index];
            return letter;
        }

        public char ReverseConvertLetter(char c)
        {
            int i = Array.IndexOf(_wiring, c);
            char convertedChar = (char)(i + Offset + Convert.ToByte('a'));
            return convertedChar;
        }

        public char ReverseConvertLetter(int i)
        {
            //char convertedChar = (char)(i + Offset + Convert.ToByte('a'));

            int characterNumber = Convert.ToByte('a') + (i + Offset) % 26;
            char convertedChar = (char)characterNumber;  // give T

            int locOnWheel = Array.IndexOf(_wiring, convertedChar); // where is T
            char initialChar = (char)(Convert.ToByte('a') + locOnWheel);
            return initialChar;
        }

        public int GetNextRotorsIndex(char convertedChar)
        {
            int i = Convert.ToByte(convertedChar) - Convert.ToByte('a');
            int index = (i + (26 - Offset)) % 26;

            return index;
        }

        /// <summary>
        /// To Be Used on return trip
        /// </summary>
        public int ReverseGetNextRotorsIndex(char initialChar)
        {
            int position = Convert.ToByte(initialChar) - Convert.ToByte('a');
            int location = (position + (26 - Offset)) % 26;

            return location;
        }

        public int GetDialOffset()
        {
            return this.Offset;
        }

        public void Rotate()
        {
            Offset = (Offset + 1) % 26;
        }

        public void SetDial(int offSet)
        {
            this.Offset = offSet;
        }

        public void SetDial(char c)
        {
            int i = Convert.ToByte(c) - Convert.ToByte('a');
            SetDial(i);
        }

        public char[] GetCurrentRotor()
        {
            char[] curRotor;
            curRotor = _wiring;

            return curRotor;
        }

        private void InitWiring2(string rotorMapping)
        {
            //string wire = "BDFHJLCPRTXVZNYEIWGAKMUSQO".ToLower();
            _wiring2 = new Dictionary<char, char>();

            int i = 0;
            foreach (char c in Enumerable.Range(97, 26))
            {
                _wiring2.Add((char)c, rotorMapping[i++]);
            }
        }

        private void InitWiring(string rotorMapping)
        {
            //string rotorMapping = mapping ?? "BDFHJLCPRTXVZNYEIWGAKMUSQO".ToLower();

            _wiring = new char[26];

            for (int i = 0; i < 26; i++)
            {
                _wiring[i] = rotorMapping[i];
            }
        }
    }
}
