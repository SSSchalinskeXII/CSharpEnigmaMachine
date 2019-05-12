using System;
using System.Collections.Generic;
using System.Text;

namespace EnigmaMachine
{
    class Rotor
    {
        private char[] rotorPositions;

        public Rotor(char[] pos)
        {
            this.rotorPositions = pos;
        }

        public char getCharAtPos(int i)
        {
            return rotorPositions[i];
        }

        public char[] getRotorArray()
        {
            return rotorPositions;
        }
        public void rotateRotor()
        {
            char tempVar = '%';
            for (int i = 0; i < rotorPositions.Length; i++)
            {
                if (i == 0)
                {
                    tempVar = rotorPositions[0];
                }
                if (i == rotorPositions.Length - 1)
                {
                    rotorPositions[i] = tempVar;
                }
                else
                {
                    rotorPositions[i] = rotorPositions[i + 1];
                }
            }
        }

        public void displayRotor()
        {
            foreach (char c in rotorPositions)
            {
                Console.Write(c);
            }
            Console.WriteLine("");
        }
    }
}
