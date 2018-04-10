using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.Interfaces;

namespace Components
{
    public class Rotor : IRotor
    {
        public int Offset { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public char ConvertLetter(char c)
        {
            throw new NotImplementedException();
        }

        public char ConvertLetter(int i)
        {
            throw new NotImplementedException();
        }

        public int GetDialOffset()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }

        public void SetDial(int i)
        {
            throw new NotImplementedException();
        }
    }
}
