using System;

namespace EnigmaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] defaultIndex = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ' };
            char[] rotor1Array = { 'E', 'K', 'M', 'F', 'L', 'G', 'D', 'Q', 'V', 'Z', 'N', 'T', 'O', 'W', 'Y', 'H', 'X', 'U', 'S', 'P', 'A', 'I', 'B', 'R', 'C', 'J', ' ' };
            char[] rotor2Array = { 'A', 'J', 'D', 'K', 'S', 'I', 'R', 'U', 'X', 'B', 'L', 'H', 'W', 'T', 'M', 'C', 'Q', 'G', 'Z', 'N', 'P', 'Y', 'F', 'V', 'O', 'E', ' ' };
            char[] rotor3Array = { 'B', 'D', 'F', 'H', 'J', 'L', 'C', 'P', 'R', 'T', 'X', 'V', 'Z', 'N', 'Y', 'E', 'I', 'W', 'G', 'A', 'K', 'M', 'U', 'S', 'Q', 'O', ' ' };
            char[] reflectorArray = { 'E', 'J', 'M', 'Z', 'A', 'L', 'Y', 'X', 'V', 'B', 'W', 'F', 'C', 'R', 'Q', 'U', 'O', 'N', 'T', 'S', 'P', 'I', 'K', 'H', 'G', 'D', ' ' };

            Rotor rotor1 = new Rotor(rotor1Array);
            Rotor rotor2 = new Rotor(rotor2Array);
            Rotor rotor3 = new Rotor(rotor3Array);
            Rotor[] mainRotorArray = { rotor1, rotor2, rotor3 };
            //Console.WriteLine("Rotors Created");

            Rotor reflector = new Rotor(reflectorArray);
            //Console.WriteLine("Reflector Created");

            //rotor1.displayRotor();
            //rotor2.displayRotor();
            //rotor3.displayRotor();
            //reflector.displayRotor();

            setInitialRotorPositions(mainRotorArray);
            //Console.WriteLine("Rotators Set to Initial Position");

            //rotor1.displayRotor();
            //rotor2.displayRotor();
            //rotor3.displayRotor();
            //reflector.displayRotor();

            Console.Write("Enter String: ");
            String message = Console.ReadLine();
            message = message.ToUpperInvariant();

            System.Text.StringBuilder output = new System.Text.StringBuilder();

            //char[] messageChars = message.ToCharArray();
            int i = 0, j = 0;
            foreach(char c in message)
            {
                char character = c;
                //Console.WriteLine(character);
                character = rotor1.getCharAtPos(Array.IndexOf(defaultIndex, character)); // Return character from rotor1 at same index of chatacter in defaultArray
                character = rotor2.getCharAtPos(Array.IndexOf(defaultIndex, character)); // Return character from rotor2 at same index of character in defaultArray
                character = rotor3.getCharAtPos(Array.IndexOf(defaultIndex, character)); // Return character from rotor3 at same index of character in defaultArray
                character = reflector.getCharAtPos(Array.IndexOf(defaultIndex, character)); // Return character from reflector at same index of character in defaultArray
                character = defaultIndex[Array.IndexOf(rotor3.getRotorArray(), character)]; // Return character from defaultArray at same index of character in rotor3
                character = defaultIndex[Array.IndexOf(rotor2.getRotorArray(), character)]; // Return character from defaultArray at same index of character in rotor2
                character = defaultIndex[Array.IndexOf(rotor1.getRotorArray(), character)]; // Return character from defaultArray at same index of character in rotor1

                output.Append(character);

                i++;
                //Rotate Rotors
                rotor1.rotateRotor(); // Rotor 1 rotates every turn
                if(i == 27)
                {
                    i = 0;
                    rotor2.rotateRotor();
                    j++;
                }
                if(j == 27)
                {
                    j = 0;
                    rotor3.rotateRotor();
                }
            }

            Console.WriteLine("\"{0}\"", output);

        }

        private static void setInitialRotorPositions(Rotor[] rotors)
        {
            int position = 0;
            int i = 1;
            foreach(Rotor r in rotors)
            {
                Console.Write("Enter Initial Position for Rotor {0}: ", i);
                i++;
                try
                {
                    position = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    System.Environment.Exit(1);
                }

                while(position > 0)
                {
                    r.rotateRotor();
                    position--;
                }
                Console.WriteLine("Rotor Rotated.");
            }
        }
    }

}
