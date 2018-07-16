using System;
using System.Collections.Generic;
using System.Text;

namespace CrosswordSolver
{
    // credit to https://www.dotnetperls.com/word-search, I repurposed a bit of code from the example
    // on that page in order to get the directional search working.
    enum WordType : byte
    {
        FullWord,
        PartialWord,
        FullWordAndPartialWord
    }
    class PuzzleSolver
    {
        // This is where I initialized the dictionary you gave me. I made it an actual C# Dictionary in order to store keyValues with
        // each word
        // Note: I amended your dictionary provided to include trebuchet along with catapult because 
        // everyone knows trebuchets are a superior seige weapon, r/trebuchetmemes 
        public static Dictionary<string, int> _found = new Dictionary<string, int>(StringComparer.Ordinal);
        public static Dictionary<string, WordType> _words = new Dictionary<string, WordType>(400000, StringComparer.Ordinal){
             {"OX",WordType.FullWord},
             {"CAT", WordType.FullWord },
             {"TOY", WordType.FullWord },
             {"AT", WordType.FullWord },
             {"DOG", WordType.FullWord },
             {"CATAPULT", WordType.FullWord },
                                            };
        // warning: the following data types are used as mutable value
        public static List<string> input = new List<string>();
        public static List<string> foundWords = new List<string>();

        // This is the bread and butter, where the puzzle solver searches through the input for matches to the "known words".
        public static int FindWords(char[,] puzzle)
        {

            /*string[] myArray = puzzle;
            // Put into 2D array.
            
            char[,] array = new char[height, width];
            for (int i = 0; i < width; i++)
            {
                for (int a = 0; a < height; a++)
                {
                    array[a, i] = myArray[a][i];
                }
            }*/
            char[,] array = puzzle;
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            // Start at each square in the 2D array.
            for (int i = 0; i < width; i++)
            {
                for (int a = 0; a < height; a++)
                {
                    // Search all directions.
                    for (int d = 0; d < 8; d++)
                    {
                        SearchAt(array, i, a, width, height, "", d);
                    }
                }
            }
            int TCount = 0;
            
            foreach (var c in array)
            {
                if (c == 'T')
                {
                    TCount++;
                }
                

                /*inputstring = stringArray[i].ToString();
                count = count + inputstring.Split('T').Length - 1;*/
            }
            int wordCount= 0;
            foreach (var item in _found)
            {
                Console.WriteLine("{0} was found {1} time(s).", item.Key, item.Value);
                wordCount += item.Value;
            }
            int grandTotal = 0;
            grandTotal = TCount + wordCount;
            Console.Write("T was found {0} time(s). \n", TCount);
            Console.WriteLine("A total of {0} words were found.",grandTotal);
            return grandTotal;
        }
        static void SearchAt(char[,] array,
                int i,
                int a,
                int width,
                int height,
                string build,
                int direction)
        {
            // Don't go past around array bounds
            if (i >= width ||
                i < 0 ||
                a >= height ||
                a < 0)
            {
                return;
            }
            // Get letter.
            char letter = array[a, i];
            // Append
            string pass = build + letter;
            switch (direction)
            {
                case 0:
                    SearchAt(array, i + 1, a, width, height, pass, direction);
                    break;
                case 1:
                    SearchAt(array, i, a + 1, width, height, pass, direction);
                    break;
                case 2:
                    SearchAt(array, i + 1, a + 1, width, height, pass, direction);
                    break;
                case 3:
                    SearchAt(array, i - 1, a, width, height, pass, direction);
                    break;
                case 4:
                    SearchAt(array, i, a - 1, width, height, pass, direction);
                    break;
                case 5:
                    SearchAt(array, i - 1, a - 1, width, height, pass, direction);
                    break;
                case 6:
                    SearchAt(array, i - 1, a + 1, width, height, pass, direction);
                    break;
                case 7:
                    SearchAt(array, i + 1, a - 1, width, height, pass, direction);
                    break;
            }
            // See if full word.
            WordType value;
            if (_words.TryGetValue(pass, out value))
            {
                // Handle all full words.
                if (value == WordType.FullWord ||
                    value == WordType.FullWordAndPartialWord)
                {
                    // Don't display same word twice.
                    if (!_found.ContainsKey(pass))
                    {
                        _found.Add(pass, 1);
                    }
                    else
                    {
                        _found[pass] = _found[pass] + 1;
                    }
                    
                }
                // Handle all partial words.
                if (value == WordType.PartialWord ||
                    value == WordType.FullWordAndPartialWord)
                {
                    // Continue in one direction.  
                }
                
                
            }
            
        }
    }
}
